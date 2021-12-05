using System;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
using Sis_Vendas_Mega.Data;
using System.Linq;
using Sis_Vendas_Mega.ViewModel;
using Sis_Vendas_Mega.Infrastructure;
using Sis_Vendas_Mega.Model;

namespace Sis_Vendas_Mega
{
    public partial class Score : Form
    {
        private DataContext _context;
        private DateTime date = DateTime.Today;
        public Score()
        {
            _context = new DataContext();
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR", false);
            ClearFields();
            GetAll();
            lblDateDay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void timerAtual_Tick(object sender, EventArgs e)
        {
            this.lblHoraAtual.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void ClearFields()
        {
            txtCodeEmployee.Clear();
            txtCodeEmployee.Focus();
            txtCodeEmployee.Select();
        }

        public void InsertInput(long code)
        {
            var employee = _context.Employees.SingleOrDefault(w => w.Code == code);

            if (!string.IsNullOrEmpty(txtCodeEmployee.Text.Trim()) && employee != null)
            {
                var viewModel = new ScoreViewModel();
                var logViewModel = new LogScoreViewModel();

                var scoreEntryTime = _context.Scores.Any(a => a.EmployeeId == employee.Id && a.Code == employee.Code && a.Inserted == date);

                if (!scoreEntryTime)
                {
                    viewModel.EmployeeId = employee.Id;
                    viewModel.Code = employee.Code;
                    viewModel.EntryTime = TimeSpan.Parse(lblHoraAtual.Text);

                    var model = new Model.Score(entryTime: viewModel.EntryTime,
                        employeeId: viewModel.EmployeeId,
                        code: viewModel.Code);

                    logViewModel.Log = (int)StatusLog.ELog.InicioTrabalho;
                    logViewModel.EmployeeId = employee.Id;

                    var logModel = new LogScore(log: logViewModel.Log, employeeId: logViewModel.EmployeeId);

                    _context.Add(model);
                    _context.SaveChanges();

                    _context.Add(logModel);
                    _context.SaveChanges();

                    GetAll();
                    ClearFields();
                    return;
                }

                var logScore = _context.LogScores.Where(w => w.EmployeeId == employee.Id && w.Inserted == DateTime.Today).Max(w => w.Log);

                var scoreOutLanch = _context.Scores.Where(a => a.EmployeeId == employee.Id && a.Code == employee.Code && a.Inserted == date 
                                                          /*a.OutLanch != DateTime.Now*/ && logScore == 1).SingleOrDefault();

                if (scoreOutLanch != null)
                {
                    viewModel.OutLanch = TimeSpan.Parse(lblHoraAtual.Text);
                    viewModel.Id = scoreOutLanch.Id;

                    var result = _context.Scores.Find(viewModel.Id);

                    result.UpdateOutLanch(outLanch: viewModel.OutLanch);

                    logViewModel.Log = (int)StatusLog.ELog.SaidaAlmoco;
                    logViewModel.EmployeeId = employee.Id;

                    var logModel = new LogScore(log: logViewModel.Log, employeeId: logViewModel.EmployeeId);

                    _context.Scores.Update(result);
                    _context.SaveChanges();

                    _context.Add(logModel);
                    _context.SaveChanges();

                    GetAll();
                    ClearFields();
                    return;
                }

                var scoreReturnLanch = _context.Scores.Where(a => a.EmployeeId == employee.Id && a.Code == employee.Code && a.Inserted == date 
                                                             /*a.ReturnLunch != DateTime.Now*/ && logScore == 2).SingleOrDefault();

                if (scoreReturnLanch != null)
                {
                    viewModel.ReturnLunch = TimeSpan.Parse(lblHoraAtual.Text);
                    viewModel.Id = scoreReturnLanch.Id;
                    viewModel.Code = scoreReturnLanch.Code;
                    viewModel.FullRange = (viewModel.ReturnLunch - scoreReturnLanch.OutLanch);

                    var result = _context.Scores.Find(viewModel.Id);

                    result.UpdateReturnLanch(returnLanch: viewModel.ReturnLunch, fullRange: viewModel.FullRange);

                    logViewModel.Log = (int)StatusLog.ELog.RetornoAlmoco;
                    logViewModel.EmployeeId = employee.Id;

                    var logModel = new LogScore(log: logViewModel.Log, employeeId: logViewModel.EmployeeId);

                    _context.Scores.Update(result);
                    _context.SaveChanges();

                    _context.Add(logModel);
                    _context.SaveChanges();

                    GetAll();
                    ClearFields();
                    return;
                }

                var scoreDepartureTime = _context.Scores.Where(a => a.EmployeeId == employee.Id && a.Code == employee.Code && a.Inserted == date 
                                                               /*a.DepartureTime != DateTime.Now*/ && logScore == 3).SingleOrDefault();

                if (scoreDepartureTime != null)
                {
                    viewModel.DepartureTime = TimeSpan.Parse(lblHoraAtual.Text);
                    viewModel.Worked = (viewModel.DepartureTime - scoreDepartureTime.EntryTime - scoreDepartureTime.FullRange);
                    viewModel.Id = scoreDepartureTime.Id;

                    viewModel.Minutes = viewModel.Worked.TotalMinutes;

                    var result = _context.Scores.Find(viewModel.Id);

                    result.UpdateDepartureTime(departureTime: viewModel.DepartureTime,
                        worked: viewModel.Worked,
                        minutes: viewModel.Minutes);

                    logViewModel.Log = (int)StatusLog.ELog.FinalizouTrabalho;
                    logViewModel.EmployeeId = employee.Id;

                    var logModel = new LogScore(log: logViewModel.Log, employeeId: logViewModel.EmployeeId);

                    _context.Scores.Update(result);
                    _context.SaveChanges();

                    _context.Add(logModel);
                    _context.SaveChanges();

                    GetAll();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show($"{employee.Name}, você já marcou os pontos do dia!", "Alerta", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    ClearFields();
                }
            }
            else
            {
                MessageBox.Show("Funcionário não encontrado!", "Alerta", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                ClearFields();
            }
        }

        public void GetAll()
        {
            var employees = _context.Scores
                .Where(w => w.Inserted == date)
                .Select(s => new
                {
                    Código = s.Id,
                    Data = s.Inserted,
                    Funcionário = s.Employee.Name,
                    Entrada = s.EntryTime,
                    SaidaAlmoço = s.OutLanch,
                    RetornoAlmoço = s.ReturnLunch,
                    Intervalo = s.FullRange,
                    Saida = s.DepartureTime,
                    Total = s.Worked
                }).OrderBy(o => o.Data)
                .ToList();

            dgvScore.DataSource = employees;
            dgvScore.Columns[0].HeaderText = "Cód";
            dgvScore.Columns[4].HeaderText = "Saída Almoço";
            dgvScore.Columns[5].HeaderText = "Ret. Almoço";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCodeEmployee_KeyPress(object sender, KeyPressEventArgs e)
        {
            long isNumber;

            if (e.KeyChar == 13)
            {
                if (long.TryParse(txtCodeEmployee.Text, out isNumber))
                {
                    InsertInput(Convert.ToInt64(txtCodeEmployee.Text));
                }
                else
                {
                    MessageBox.Show("Esse campo só aceita número!", "Alerta", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    ClearFields();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
