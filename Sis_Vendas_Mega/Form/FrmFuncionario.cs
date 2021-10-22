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
            txtNome.Select();
        }

        public void Insert(EemployeeViewModel viewModel)
        {
            _context = new DataContext();

            if (!string.IsNullOrEmpty(txtNome.Text))
            {
                viewModel.Name = txtNome.Text;

                var model = new Employee(name: viewModel.Name);

                _context.Employees.Add(model);
                _context.SaveChanges();

                MessageBox.Show("Funcionário cadastrado com sucesso!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                GetAll();
            }
            else
            {
                MessageBox.Show("O Nome é obrigatórios!", "Alerta", MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                txtNome.Focus();
            }
        }

        public void GetAll()
        {
            _context = new DataContext();

            var employees = _context.Employees
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    s.Inserted,
                    s.UpdateAt
                }).OrderBy(o => o.Name)
                .ToList();

            dgvEmployees.DataSource = employees;

            dgvEmployees.Columns[0].HeaderText = "Código";
            dgvEmployees.Columns[1].HeaderText = "Nome";
            dgvEmployees.Columns[2].HeaderText = "Dt Cadastro";
            dgvEmployees.Columns[3].HeaderText = "Dt Atualização";
            dgvEmployees.Columns[1].Width = 300;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var employee = new EemployeeViewModel();
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
    }
}
