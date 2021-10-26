using System;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
using Sis_Vendas_Mega.Data;
using System.Linq;
using Sis_Vendas_Mega.ViewModel;

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

        public void InsertInput(int code)
        {
            var employee = _context.Employees.SingleOrDefault(w => w.Code == code);

            if (!string.IsNullOrEmpty(txtCodeEmployee.Text.Trim()) && employee != null)
            {
                var viewModel = new ScoreViewModel();

                var scoreEntryTime = _context.Scores.Any(a => a.EmployeeId == employee.Id && a.Code == employee.Code && a.Inserted == date);

                if (!scoreEntryTime)
                {
                    viewModel.EntryTime = Convert.ToDateTime(lblHoraAtual.Text);
                    viewModel.EmployeeId = employee.Id;
                    viewModel.Code = employee.Code;

                    var model = new Model.Score(entryTime: viewModel.EntryTime,
                        employeeId: viewModel.EmployeeId,
                        code: viewModel.Code);

                    _context.Add(model);
                    _context.SaveChanges();
                    GetAll();
                    ClearFields();
                    return;
                }

                var scoreOutLanch = _context.Scores.Where(a => a.EmployeeId == employee.Id && a.Inserted == date && a.OutLanch == null).SingleOrDefault();

                if (scoreOutLanch != null)
                {
                    viewModel.OutLanch = Convert.ToDateTime(lblHoraAtual.Text);
                    viewModel.Id = scoreOutLanch.Id;

                    var result = _context.Scores.Find(viewModel.Id);

                    result.UpdateOutLanch(outLanch: viewModel.OutLanch);

                    _context.Scores.Update(result);
                    _context.SaveChanges();
                    GetAll();
                    ClearFields();
                    return;
                }

                var scoreReturnLanch = _context.Scores.Where(a => a.EmployeeId == employee.Id && a.Code == employee.Code && a.Inserted == date && a.ReturnLunch == null).SingleOrDefault();

                if (scoreReturnLanch != null)
                {
                    viewModel.ReturnLunch = Convert.ToDateTime(lblHoraAtual.Text);
                    viewModel.Id = scoreReturnLanch.Id;
                    viewModel.Code = scoreReturnLanch.Code;

                    var result = _context.Scores.Find(viewModel.Id);

                    result.UpdateReturnLanch(returnLanch: viewModel.ReturnLunch);

                    _context.Scores.Update(result);
                    _context.SaveChanges();
                    GetAll();
                    ClearFields();
                    return;
                }

                var scoreDepartureTime = _context.Scores.Where(a => a.EmployeeId == employee.Id && a.Code == employee.Code && a.Inserted == date && a.DepartureTime == null).SingleOrDefault();

                if (scoreDepartureTime != null)
                {
                    viewModel.DepartureTime = Convert.ToDateTime(lblHoraAtual.Text);
                    viewModel.Worked = (viewModel.DepartureTime - scoreDepartureTime.EntryTime);
                    viewModel.Id = scoreDepartureTime.Id;
                    
                    var result = _context.Scores.Find(viewModel.Id);

                    result.UpdateDepartureTime(departureTime: viewModel.DepartureTime,
                        worked: viewModel.Worked);

                    _context.Scores.Update(result);
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
            int isNumber;

            if (e.KeyChar == 13)
            {
                if (int.TryParse(txtCodeEmployee.Text, out isNumber))
                {
                    InsertInput(Convert.ToInt32(txtCodeEmployee.Text));
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
