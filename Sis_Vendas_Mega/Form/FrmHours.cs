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
            CleanFields();
        }

        private void CleanFields()
        {
            txtCode.Clear();
            txtName.Clear();
            txtName.Focus();
            txtName.Select();
            txtId.Clear();
            txtData.Clear();
            txtEntrada.Clear();
            txtSaidaAlmoco.Clear();
            txtRetorno.Clear();
            txtSaida.Clear();
            dgvHours.DataSource = null;
            rbManual.Checked = false;
            rbCorrecao.Checked = false;
            btnPesquisar.Enabled = true;
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
                          Entrada = s.EntryTime,
                          Almoco = s.OutLanch,
                          Retorno = s.ReturnLunch,
                          Saida = s.DepartureTime
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

        public void UpdateOrInsertHour(ScoreViewModel viewModel)
        {
            if (rbManual.Checked)
            {
                if (!string.IsNullOrEmpty(txtCode.Text))
                {
                    if (!txtData.Text.Equals("  /  /") && !txtEntrada.Text.Equals(":") && !txtSaidaAlmoco.Text.Equals(":") &&
                        !txtRetorno.Text.Equals(":") && !txtSaida.Text.Equals(":"))
                    {
                        var employee = _context.Employees.Find(Convert.ToInt32(txtCode.Text));

                        viewModel.Inserted = Convert.ToDateTime(txtData.Text);
                        viewModel.EntryTime = TimeSpan.Parse(txtEntrada.Text);
                        viewModel.OutLanch = TimeSpan.Parse(txtSaidaAlmoco.Text);
                        viewModel.ReturnLunch = TimeSpan.Parse(txtRetorno.Text);
                        viewModel.DepartureTime = TimeSpan.Parse(txtSaida.Text);
                        viewModel.FullRange = (viewModel.ReturnLunch - viewModel.OutLanch);
                        viewModel.Worked = (viewModel.DepartureTime - viewModel.EntryTime - viewModel.FullRange);
                        viewModel.Minutes = viewModel.Worked.TotalMinutes;
                        viewModel.EmployeeId = employee.Id;
                        viewModel.Code = employee.Code;

                        var model = new Model.Score();
                        model.InsertHoursManual(inserted: viewModel.Inserted,
                            entryTime: viewModel.EntryTime,
                            outLanch: viewModel.OutLanch,
                            returnLanch: viewModel.ReturnLunch,
                            departureTime: viewModel.DepartureTime,
                            fullRange: viewModel.FullRange,
                            worked: viewModel.Worked,
                            minutes: viewModel.Minutes,
                            employeeId: viewModel.EmployeeId,
                            code: viewModel.Code);

                        _context.Scores.Add(model);
                        _context.SaveChanges();

                        MessageBox.Show("Registro inserido com sucesso.", "Sucesso", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                        CleanFields();
                    }
                    else
                    {
                        MessageBox.Show("Preencha os campos obrigátorios.", "Alerta", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione um funcionário.", "Alerta", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }

            }
            else if (rbCorrecao.Checked)
            {
                if (!string.IsNullOrEmpty(txtId.Text))
                {
                    viewModel.Id = Convert.ToInt32(txtId.Text);
                    var result = _context.Scores.Find(viewModel.Id);

                    viewModel.EntryTime = TimeSpan.Parse(txtEntrada.Text);
                    viewModel.OutLanch = TimeSpan.Parse(txtSaidaAlmoco.Text);
                    viewModel.ReturnLunch = TimeSpan.Parse(txtRetorno.Text);
                    viewModel.DepartureTime = TimeSpan.Parse(txtSaida.Text);
                    viewModel.FullRange = (viewModel.ReturnLunch - viewModel.OutLanch);
                    viewModel.Worked = (viewModel.DepartureTime - viewModel.EntryTime - viewModel.FullRange);
                    viewModel.Minutes = viewModel.Worked.TotalMinutes;
                    viewModel.EmployeeId = Convert.ToInt32(txtCode.Text);

                    result.UpdateHours(entryTime: viewModel.EntryTime,
                        outLanch: viewModel.OutLanch,
                        returnLanch: viewModel.ReturnLunch,
                        departureTime: viewModel.DepartureTime,
                        worked: viewModel.Worked,
                        fullRange: viewModel.FullRange,
                        minutes: viewModel.Minutes);

                    _context.Scores.Update(result);
                    _context.SaveChanges();

                    MessageBox.Show("Editado com sucesso!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CleanFields();
                }
                else
                {
                    MessageBox.Show("Selecione um registro para editar.", "Alerta", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione uma Ação.", "Alerta", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
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
            var viewModel = new ScoreViewModel();
            UpdateOrInsertHour(viewModel);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CleanFields();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rbManual_CheckedChanged(object sender, EventArgs e)
        {
            btnPesquisar.Enabled = false;
            txtData.Enabled = true;
        }

        private void rbCorrecao_CheckedChanged(object sender, EventArgs e)
        {
            txtData.Enabled = false;
            btnPesquisar.Enabled = true;
        }

        private void txtData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtEntrada.Focus();
            }
        }

        private void txtEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSaidaAlmoco.Focus();
            }
        }

        private void txtSaidaAlmoco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtRetorno.Focus();
            }
        }

        private void txtRetorno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSaida.Focus();
            }
        }

        private void txtSaida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSave.Focus();
            }
        }
    }
}
