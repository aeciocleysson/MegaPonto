using Sis_Vendas_Mega.Data;
using Sis_Vendas_Mega.Model;
using Sis_Vendas_Mega.ViewModel;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sis_Vendas_Mega
{
    public partial class FrmUser : Form
    {
        private DataContext _context;
        public FrmUser()
        {
            _context = new DataContext();
            InitializeComponent();
            ClearFields();
            GetAll();
        }

        private void ClearFields()
        {
            txtCodeUser.Clear();
            txtName.Clear();
            txtLogin.Clear();
            txtSenha.Clear();
            txtName.Focus();
            txtName.Select();
            rbTotal.Checked = false;
            rbPonto.Checked = false;
        }

        public void GetAll()
        {
            var employees = _context.Usuarios
                .Select(s => new
                {
                    s.Id,
                    s.Nome
                }).OrderBy(o => o.Nome)
                .ToList();

            dgvUser.DataSource = employees;

            dgvUser.Columns[0].HeaderText = "Código";
            dgvUser.Columns[1].HeaderText = "Nome";
            dgvUser.Columns[1].Width = 200;
        }

        public void InsertUser(UsuarioViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(txtName.Text.Trim()) && !string.IsNullOrEmpty(txtLogin.Text.Trim()) && !string.IsNullOrEmpty(txtSenha.Text.Trim()))
            {
                if(rbTotal.Checked || rbPadrao.Checked || rbPonto.Checked)
                {
                    viewModel.Nome = txtName.Text;
                    viewModel.Login = txtLogin.Text;
                    viewModel.Senha = txtSenha.Text.ToLower();

                    if (rbTotal.Checked)
                        viewModel.NivelAcesso = 1;
                    else if (rbPonto.Checked)
                        viewModel.NivelAcesso = 2;
                    else if (rbPadrao.Checked)
                        viewModel.NivelAcesso = 3;

                    var model = new Usuario(nome: viewModel.Nome,
                        login: viewModel.Login,
                        senha: viewModel.Senha,
                        nivelAcesso: viewModel.NivelAcesso);

                    _context.Usuarios.Add(model);
                    _context.SaveChanges();

                    MessageBox.Show("Usuário cadastrado com sucesso!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    GetAll();
                }
                else
                {
                   MessageBox.Show("Escolha um permissão", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Os campos: Nome, Login e Senha devem ser peenchidos!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var viewModel = new UsuarioViewModel();
            InsertUser(viewModel);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
