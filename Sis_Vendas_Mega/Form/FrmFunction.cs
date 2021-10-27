using Sis_Vendas_Mega.Data;
using Sis_Vendas_Mega.Model;
using Sis_Vendas_Mega.ViewModel;
using System.Linq;
using System.Windows.Forms;

namespace Sis_Vendas_Mega
{
    public partial class FrmFunction : Form
    {
        private DataContext _context;
        public FrmFunction()
        {
            InitializeComponent();
            _context = new DataContext();
            ClearFields();
            GetAll();
        }

        public void Insert(FunctionViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(txtDescricao.Text.Trim()))
            {
                viewModel.Description = txtDescricao.Text;

                var model = new Function(description: viewModel.Description);

                _context.Add(model);
                _context.SaveChanges();

                MessageBox.Show("Função cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                GetAll();
            }
            else
            {
                MessageBox.Show("Descrição é obrigatório!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ClearFields()
        {
            txtCode.Clear();
            txtDescricao.Clear();
            txtDescricao.Focus();
            txtDescricao.Select();
        }

        public void GetAll()
        {
            var result = _context.Functions
                .Select(s => new
                {
                    Codigo = s.Id,
                    Descricao = s.Description,
                    s.Inserted
                }).ToList();

            dgvFunctions.DataSource = result;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            var viewMpdel = new FunctionViewModel();
            Insert(viewMpdel);
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            GetAll();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
