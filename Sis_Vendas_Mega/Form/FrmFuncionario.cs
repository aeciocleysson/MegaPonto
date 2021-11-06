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
            txtNome.Select();
            mtbDataNascimento.Clear();
        }

        public void Insert(EmployeeViewModel viewModel)
        {
            _context = new DataContext();

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtCodeFunction.Text) &&
                    !string.IsNullOrEmpty(mtbDataNascimento.Text))
                {
                    viewModel.Name = txtNome.Text;
                    viewModel.Code = Convert.ToInt64($"{mtbDataNascimento.Text.Replace("/", "")}{DateTime.Today.ToString("dd/MM/yy").Replace("/", "")}");
                    viewModel.DataNascimento = mtbDataNascimento.Text;
                    viewModel.FunctionId = Convert.ToInt32(txtCodeFunction.Text);

                    var model = new Employee(name: viewModel.Name,
                        code: viewModel.Code,
                        dataNascimento: viewModel.DataNascimento,
                        functionId: viewModel.FunctionId);

                    _context.Employees.Add(model);
                    _context.SaveChanges();

                    MessageBox.Show("Funcionário cadastrado com sucesso!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    GetAll();
                }
                else
                {
                    MessageBox.Show("O Nome, Função e data Nascimento são obrigatórios!", "Alerta", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    GetAll();
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtNome.Text) && !string.IsNullOrEmpty(txtCodeFunction.Text) && !string.IsNullOrEmpty(mtbDataNascimento.Text))
                {
                    viewModel.Id = Convert.ToInt32(txtCodigo.Text);
                    viewModel.Name = txtNome.Text;
                    viewModel.DataNascimento = mtbDataNascimento.Text;
                    viewModel.FunctionId = Convert.ToInt32(txtCodeFunction.Text);

                    var model = _context.Employees.Find(viewModel.Id);

                    model.Update(name: viewModel.Name,
                         functionId: viewModel.FunctionId,
                         dataNascimento: viewModel.DataNascimento);

                    _context.Employees.Update(model);
                    _context.SaveChanges();

                    MessageBox.Show("Funcionário atualizado com sucesso!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    GetAll();
                }
                else
                {
                    MessageBox.Show("O Nome, Função e Data de Nascimento são obrigatórios!", "Alerta", MessageBoxButtons.OK,
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
                    s.DataNascimento,
                    s.FunctionId,
                    s.Function.Description,
                    s.Code,
                    s.Inserted
                }).OrderBy(o => o.Name)
                .ToList();

            dgvEmployees.DataSource = employees;

            dgvEmployees.Columns[0].HeaderText = "Código";
            dgvEmployees.Columns[1].HeaderText = "Nome";
            dgvEmployees.Columns[2].HeaderText = "Dt. Nascimento";
            dgvEmployees.Columns[3].HeaderText = "Cd. Função";
            dgvEmployees.Columns[4].HeaderText = "Função";
            dgvEmployees.Columns[5].HeaderText = "Matricula";
            dgvEmployees.Columns[6].HeaderText = "Dt. Cadastro";
            dgvEmployees.Columns[1].Width = 300;
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
                mtbDataNascimento.Text = row.Cells[2].Value.ToString();
                txtCodeFunction.Text = row.Cells[3].Value.ToString();
                txtFunction.Text = row.Cells[4].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var viewModel = new EmployeeViewModel();
            Delete(viewModel);
        }
    }
}
