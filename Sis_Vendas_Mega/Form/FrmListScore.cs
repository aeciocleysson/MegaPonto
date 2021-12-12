using Sis_Vendas_Mega.Data;
using Sis_Vendas_Mega.Relatorio;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Sis_Vendas_Mega
{
    public partial class FrmListScore : Form
    {
        private DataContext _context;
        private const double totalHorasMes = 220;
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
                          Inserted = s.Inserted,
                          Dia = s.Inserted.ToString("dddd", new CultureInfo("pt-BR")),
                          Name = s.Employee.Name,
                          EntryTime = s.EntryTime,
                          OutLanch = s.OutLanch,
                          ReturnLunch = s.ReturnLunch,
                          FullRange = s.FullRange,
                          DepartureTime = s.DepartureTime,
                          Worked = s.Worked
                      })
                      .OrderBy(o => o.Inserted)
                      .ToList();

                var totalHours = _context.Scores
                    .Where(w => w.EmployeeId == id &&
                           w.Inserted >= dtInicio &&
                           w.Inserted <= dtFim)
                    .Sum(w => w.Minutes / 60);

                dgvScoreMonth.DataSource = employee;

                dgvScoreMonth.Columns[0].HeaderText = "Data";
                dgvScoreMonth.Columns[1].HeaderText = "Dia";
                dgvScoreMonth.Columns[2].HeaderText = "Funcionário(a)";
                dgvScoreMonth.Columns[3].HeaderText = "Entrada";
                dgvScoreMonth.Columns[4].HeaderText = "Saida Almoço";
                dgvScoreMonth.Columns[5].HeaderText = "Retorno Almoço";
                dgvScoreMonth.Columns[6].HeaderText = "Intervalo";
                dgvScoreMonth.Columns[7].HeaderText = "Saída";
                dgvScoreMonth.Columns[8].HeaderText = "Total";

                dgvScoreMonth.Columns[2].Width = 250;
                dgvScoreMonth.Columns[3].Width = 135;
                dgvScoreMonth.Columns[4].Width = 135;
                dgvScoreMonth.Columns[5].Width = 135;
                dgvScoreMonth.Columns[6].Width = 135;
                dgvScoreMonth.Columns[7].Width = 135;
                dgvScoreMonth.Columns[8].Width = 135;

                dgvScoreMonth.Columns[2].Visible = false;

                txtSaldoMes.Text = totalHours.ToString("#.##");

                if (string.IsNullOrEmpty(txtSaldoMes.Text))
                {
                    txtSaldoMes.Text = "0.00";
                    txtSaldoPositivo.Text = "0.00";
                    txtSaldoNegativo.Text = "0.00";
                }
                else
                {
                    var total = Convert.ToDouble(txtSaldoMes.Text) - totalHorasMes;

                    if (total > totalHorasMes)
                        txtSaldoPositivo.Text = total.ToString();
                    else
                        txtSaldoNegativo.Text = total.ToString();
                }
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

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            var data = GerarDadosRelatorio();

            var relat = new FrmRelatorioMensal(data, txtSaldoMes.Text, dpDtInicio.Value, dpDtFim.Value);
            relat.ShowDialog();
        }

        private DataTable GerarDadosRelatorio()
        {
            var dt = new DataTable();

            dt.Columns.Add("Inserted");
            dt.Columns.Add("Employee");
            dt.Columns.Add("EntryTime");
            dt.Columns.Add("OutLanch");
            dt.Columns.Add("ReturnLunch");
            dt.Columns.Add("DepartureTime");
            dt.Columns.Add("Worked");

            foreach (DataGridViewRow item in dgvScoreMonth.Rows)
            {
                dt.Rows.Add(item.Cells["Inserted"].Value.ToString(),
                            item.Cells["Name"].Value.ToString(),
                            item.Cells["EntryTime"].Value.ToString(),
                            item.Cells["OutLanch"].Value.ToString(),
                            item.Cells["ReturnLunch"].Value.ToString(),
                            item.Cells["DepartureTime"].Value.ToString(),
                            item.Cells["Worked"].Value.ToString());
            }

            return dt;
        }
    }
}
