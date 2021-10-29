using Sis_Vendas_Mega.Data;
using Sis_Vendas_Mega.Model;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Sis_Vendas_Mega
{
    public partial class FrmListScore : Form
    {
        private DataContext _context;
        public FrmListScore()
        {
            InitializeComponent();
            _context = new DataContext();
        }

        public void ClearFilds()
        {
            txtCode.Clear();
            txtName.Clear();
        }

        public void SelectEmployee()
        {
            var employees = new FrmListEmployees();
            employees.ShowDialog();

            if (employees.DialogResult == DialogResult.OK)
            {
                var dataGrid = employees.dgvEmployees.Rows[employees.dgvEmployees.CurrentRow.Index];

                txtCode.Text = dataGrid.Cells[0].Value.ToString();
                txtName.Text = dataGrid.Cells[1].Value.ToString();
            }
        }

        private static string TranslateDay(string dayInStringFormat, string culture)
        {
            try
            {
                return CultureInfo.CreateSpecificCulture(culture).DateTimeFormat
                    .GetDayName((DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayInStringFormat));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void GetById(int id, DateTime dtInicio, DateTime dtFim)
        {
            if (!string.IsNullOrEmpty(txtCode.Text))
            {
                id = Convert.ToInt32(txtCode.Text);
                dtInicio = Convert.ToDateTime(dpDtInicio.Value.ToString("dd/MM/yyyy"));
                dtFim = Convert.ToDateTime(dpDtFim.Value.ToString("dd/MM/yyyy"));

                var employee = _context.Scores
                      .Where(w => w.EmployeeId == id &&
                             w.Inserted >= dtInicio &&
                             w.Inserted <= dtFim)
                      .Select(s => new
                      {
                          s.Inserted,
                          s.Inserted.DayOfWeek,
                          s.Employee.Name,
                          s.EntryTime,
                          s.OutLanch,
                          s.ReturnLunch,
                          s.DepartureTime,
                          s.Worked
                      })
                      .OrderBy(o => o.Inserted)
                      .ToList();

                dgvScoreMonth.DataSource = employee;

                dgvScoreMonth.Columns[0].HeaderText = "Dia";
                dgvScoreMonth.Columns[1].HeaderText = "Desc";
                dgvScoreMonth.Columns[2].HeaderText = "Funcionário";
                dgvScoreMonth.Columns[3].HeaderText = "Entrada";
                dgvScoreMonth.Columns[4].HeaderText = "Saida Almoço";
                dgvScoreMonth.Columns[5].HeaderText = "Retorno Almoço";
                dgvScoreMonth.Columns[6].HeaderText = "Saída";
                dgvScoreMonth.Columns[7].HeaderText = "Total";

                dgvScoreMonth.Columns[2].Width = 250;
                dgvScoreMonth.Columns[3].Width = 135;
                dgvScoreMonth.Columns[4].Width = 135;
                dgvScoreMonth.Columns[5].Width = 135;
                dgvScoreMonth.Columns[6].Width = 135;
                dgvScoreMonth.Columns[7].Width = 135;
            }
            else
            {
                MessageBox.Show("Selecione um Funcionário.", "Alerta", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            SelectEmployee();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            var score = new Model.Score();

            GetById(score.EmployeeId, score.Inserted, score.Inserted);
        }
    }

    public static class DateTimeExtension
    {
        public static string GetDayOfWeek(this DateTime uiDateTime, CultureInfo culture = null)
        {
            if (culture == null)
            {
                culture = Thread.CurrentThread.CurrentUICulture;
            }

            return culture.DateTimeFormat.GetDayName(uiDateTime.DayOfWeek);
        }
    }
}
