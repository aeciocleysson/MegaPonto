using Sis_Vendas_Mega.Data;
using Sis_Vendas_Mega.ViewModel;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Sis_Vendas_Mega
{
    public partial class FrmHours : Form
    {
        private DataContext _context;
        public FrmHours()
        {
            InitializeComponent();
            _context = new DataContext();
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
                          Codigo = s.Id,
                          Data = s.Inserted,
                          Dia = s.Inserted.ToString("dddd", new CultureInfo("pt-BR")),
                          Entrada = s.EntryTime.ToString("HH:mm"),
                          Almoco = s.OutLanch.ToString("HH:mm"),
                          Retorno = s.ReturnLunch.ToString("HH:mm"),
                          Saida = s.DepartureTime.ToString("HH:mm")
                      })
                      .OrderBy(o => o.Data)
                      .ToList();               

                dgvHours.DataSource = employee;

                dgvHours.Columns[0].HeaderText = "Id";
                dgvHours.Columns[1].HeaderText = "Data";
                dgvHours.Columns[2].HeaderText = "Dia";
                dgvHours.Columns[3].HeaderText = "Entrada";
                dgvHours.Columns[4].HeaderText = "Saida Almoço";
                dgvHours.Columns[5].HeaderText = "Ret. Almoço";
                dgvHours.Columns[6].HeaderText = "Saida";
            }
            else
            {
                MessageBox.Show("Selecione um Funcionário.", "Alerta", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        public void UpdateHour(HoursViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                viewModel.Id = Convert.ToInt32(txtId.Text);

                viewModel.EntryTime = Convert.ToDateTime(txtEntrada.Text);
                viewModel.OutLanch = Convert.ToDateTime(txtSaidaAlmoco.Text);
                viewModel.ReturnLunch = Convert.ToDateTime(txtRetorno.Text);
                viewModel.DepartureTime = Convert.ToDateTime(txtSaida.Text);
            }
        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {
            SelectEmployee();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            var score = new Model.Score();

            GetById(score.EmployeeId, score.Inserted, score.Inserted);
        }

        private void dgvHours_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvHours.Rows[e.RowIndex];

                txtId.Text = row.Cells[0].Value.ToString();
                txtData.Text = row.Cells[1].Value.ToString();
                txtEntrada.Text = row.Cells[3].Value.ToString();
                txtSaidaAlmoco.Text = row.Cells[4].Value.ToString();
                txtRetorno.Text = row.Cells[5].Value.ToString();
                txtSaida.Text = row.Cells[6].Value.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var viewModel = new HoursViewModel();
            UpdateHour(viewModel);
        }
    }
}
