using Sis_Vendas_Mega.Data;
using Sis_Vendas_Mega.Model;
using Sis_Vendas_Mega.ViewModel;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Sis_Vendas_Mega
{
    public partial class FrmFuncionario : Form
    {
        private DataContext _context;
        public FrmFuncionario()
        {
            InitializeComponent();
            ClearFields();
            GetAll();
        }

        private void ClearFields()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtNome.Focus();
            txtCodeFunction.Clear();
            txtFunction.Clear();
            txtCode.Clear();
            txtNome.Select();
        }

        public void Insert(EmployeeViewModel viewModel)
        {
            _context = new DataContext();

            if (string.IsNullOrEmpty(txtCode.Text))
            {
                if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtCodeFunction.Text) && !string.IsNullOrEmpty(txtCode.Text))
                {
                    viewModel.Name = txtNome.Text;
                    viewModel.Code = Convert.ToInt32(txtCode.Text.Replace(".", "").Replace(",", ""));
                    viewModel.FunctionId = Convert.ToInt32(txtCodeFunction.Text);

                    var model = new Employee(name: viewModel.Name,
                        code: viewModel.Code,
                        functionId: viewModel.FunctionId);

                    _context.Employees.Add(model);
                    _context.SaveChanges();

                    MessageBox.Show("Funcionário cadastrado com sucesso!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    GetAll();
                }
                else
                {
                    MessageBox.Show("O Nome, Função e Código são obrigatórios!", "Alerta", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    GetAll();
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtCodeFunction.Text) && !string.IsNullOrEmpty(txtCode.Text))
                {
                    viewModel.Id = Convert.ToInt32(txtCodigo.Text);
                    viewModel.Name = txtNome.Text;
                    viewModel.Code = Convert.ToInt32(txtCode.Text.Replace(".", "").Replace(",", ""));
                    viewModel.FunctionId = Convert.ToInt32(txtCodeFunction.Text);

                    var model = _context.Employees.Find(viewModel.Id);

                    model.Update(name: viewModel.Name,
                         functionId: viewModel.FunctionId,
                         code: viewModel.Code);

                    _context.Employees.Update(model);
                    _context.SaveChanges();

                    MessageBox.Show("Funcionário atualizado com sucesso!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    GetAll();
                }
                else
                {
                    MessageBox.Show("O Nome, Função e Código são obrigatórios!", "Alerta", MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
                    GetAll();
                }
            }
        }

        public void GetAll()
        {
            _context = new DataContext();

            var employees = _context.Employees
                .Where(w => w.IsDelete == 0)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.FunctionId,
                    s.Function.Description,
                    s.Code,
                    s.Inserted,
                    s.UpdateAt
                }).OrderBy(o => o.Name)
                .ToList();

            dgvEmployees.DataSource = employees;

            dgvEmployees.Columns[0].HeaderText = "Código";
            dgvEmployees.Columns[1].HeaderText = "Nome";
            dgvEmployees.Columns[2].HeaderText = "Cód. Função";
            dgvEmployees.Columns[3].HeaderText = "Função";
            dgvEmployees.Columns[4].HeaderText = "QR Code";
            dgvEmployees.Columns[5].HeaderText = "Dt. Cadastro";
            dgvEmployees.Columns[6].HeaderText = "Dt. Atualização";
            dgvEmployees.Columns[1].Width = 300;
            dgvEmployees.Columns[3].Width = 250;
        }

        public void Delete(EmployeeViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                if (MessageBox.Show("Deseja realmente excluir esse usuário?", "Alerta", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    ClearFields();
                else
                {
                    viewModel.Id = Convert.ToInt16(txtCodigo.Text);
                    viewModel.IsDelete = 1;

                    var model = _context.Employees.Find(viewModel.Id);

                    model.Delete(isDelete: viewModel.IsDelete);
                    _context.Employees.Update(model);
                    _context.SaveChanges();

                    MessageBox.Show("Funcionário deletado com sucesso!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    GetAll();
                }
            }
            else
            {
                MessageBox.Show("Selecione um funcionário!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                GetAll();
            }
        }

        public void SelectFunction()
        {
            var functions = new FrmListFunction();
            functions.ShowDialog();

            if (functions.DialogResult == DialogResult.OK)
            {
                var dataGrid = functions.gvFunctions.Rows[functions.gvFunctions.CurrentRow.Index];

                txtCodeFunction.Text = dataGrid.Cells[0].Value.ToString();
                txtFunction.Text = dataGrid.Cells[1].Value.ToString();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var employee = new EmployeeViewModel();
            Insert(employee);
        }

        private void brnCancelar_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnListFunction_Click(object sender, EventArgs e)
        {
            SelectFunction();
        }

        private void dgvEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvEmployees.Rows[e.RowIndex];

                txtCodigo.Text = row.Cells[0].Value.ToString();
                txtNome.Text = row.Cells[1].Value.ToString();
                txtCodeFunction.Text = row.Cells[2].Value.ToString();
                txtFunction.Text = row.Cells[3].Value.ToString();
                txtCode.Text = row.Cells[4].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var viewModel = new EmployeeViewModel();
            Delete(viewModel);
        }
    }
}
