using System;
using System.Windows.Forms;

namespace Sis_Vendas_Mega
{
    public partial class FrmPrincipal : Form
    {
        private readonly string p;

        public FrmPrincipal()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        public FrmPrincipal(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            FormCloseButtonDisabler.DisableCloseButton(this.Handle.ToInt32());
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja fechar o sistema?", "Fechar o sistema", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cadastrarFuncionario_Click(object sender, EventArgs e)
        {
            var employee = new FrmFuncionario();
            employee.MdiParent = this;
            employee.Show();
        }

        private void scoreEntry_Click(object sender, EventArgs e)
        {
            var score = new Score();
            score.MdiParent = this;
            score.Show();
        }

        private void CadatrarUsuario_Click(object sender, EventArgs e)
        {
            var user = new FrmUser();
            user.MdiParent = this;
            user.Show();
        }

        private void cadastroFuncao_Click(object sender, EventArgs e)
        {
            var function = new FrmFunction();
            function.MdiParent = this;
            function.Show();
        }

        private void registroMensal_Click(object sender, EventArgs e)
        {
            var registro = new FrmListScore();
            registro.MdiParent = this;
            registro.Show();
        }

        private void manutencaoHorario_Click(object sender, EventArgs e)
        {
            var hours = new FrmHours();
            hours.MdiParent = this;
            hours.Show();
        }

        private void menuProvider_Click(object sender, EventArgs e)
        {
            var provider = new FrmProvider();
            provider.MdiParent = this;
            provider.Show();
        }

        private void menuProduct_Click(object sender, EventArgs e)
        {
            var product = new FrmProduct();
            product.MdiParent = this;
            product.Show();
        }

        private void menuRegister_Click(object sender, EventArgs e)
        {
            var register = new FrmRegister();
            register.MdiParent = this;
            register.Show();
        }

        private void menuTrocasAll_Click(object sender, EventArgs e)
        {
            var trocas = new FrmTrocasAll();
            trocas.MdiParent = this;
            trocas.Show();
        }
    }
}
