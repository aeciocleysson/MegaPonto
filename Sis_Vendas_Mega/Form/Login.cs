using Sis_Vendas_Mega.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Sis_Vendas_Mega
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private DataContext _context;

        private void Logar()
        {
            _context = new DataContext();

            if (string.IsNullOrEmpty(txtUsuario.Text.Trim()) || string.IsNullOrEmpty(txtSenha.Text.Trim()))
            {
                MessageBox.Show("Os campos Login e Senha devem ser preenchidos.", "Alerta", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                txtUsuario.Focus();
            }
            else
            {
                var user = _context.Usuarios.FirstOrDefault(c => c.Login == txtUsuario.Text.Trim() && c.Senha == txtSenha.Text.Trim().ToLower());
                var principal = new FrmPrincipal();

                if (user != null)
                {
                    if (user.Login == txtUsuario.Text.Trim() && user.Senha == txtSenha.Text.Trim().ToLower())
                    {
                        switch (user.NivelAcesso)
                        {
                            case 2:
                                principal.menuUtilitario.Visible = false;
                                principal.menuCadastrar.Visible = false;
                                principal.menuTrocas.Visible = false;
                                break;
                            case 3:
                                principal.menuUtilitario.Visible = false;
                                principal.menuCadastrar.Visible = false;
                                principal.scoreEntry.Visible = false;
                                principal.menuTrocas.Visible = true;
                                break;
                        }

                        Hide();
                        principal.Show();
                    }
                    else
                    {
                        MessageBox.Show("Login ou Senha inválido!", "Alerta", MessageBoxButtons.OK,
                        MessageBoxIcon.None);
                    }
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado!", "Erro", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        #region Botões
        private void btnLogar_Click(object sender, EventArgs e)
        {
            Logar();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtSenha.Focus();
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Logar();
            }
        }

        #endregion
    }
}
