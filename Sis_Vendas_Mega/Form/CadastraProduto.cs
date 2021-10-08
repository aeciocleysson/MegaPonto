using Sis_Vendas_Mega.Data;
using Sis_Vendas_Mega.Model;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sis_Vendas_Mega
{
    public partial class frmCadastraProduto : Form
    {
        public frmCadastraProduto()
        {
            InitializeComponent();
        }

        private DataContext _context;

        private async Task InsertAsync()
        {
            _context = new DataContext();

            if (!string.IsNullOrEmpty(txtNome.Text.Trim()))
            {

                var produto = new Produto();

                produto.Nome = txtNome.Text;
          

                await _context.Produtos.AddAsync(produto);
                await _context.SaveChangesAsync();

                MessageBox.Show("Cliente cadastrado com sucesso!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);         
            }
            else
            {
                MessageBox.Show("Campos Nome, Endereço, Cidade e Bairro são obrigatórios!", "Alerta", MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                txtNome.Focus();

            }
        }

        private async void btnSalvar_Click(object sender, System.EventArgs e)
        {
            await InsertAsync();
        }
    }
}
