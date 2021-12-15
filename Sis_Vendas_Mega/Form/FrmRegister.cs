using Sis_Vendas_Mega.Data;
using Sis_Vendas_Mega.ViewModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sis_Vendas_Mega
{
    public partial class FrmRegister : Form
    {
        private DataContext _context;
        public FrmRegister()
        {
            InitializeComponent();
            _context = new DataContext();
            GetAllProducts();
        }

        private void GetAllProducts()
        {
            var products = _context.Products
                                   .Where(w => w.IsDelete == 0)
                                   .Select(s => new
                                   {
                                       Codigo = s.Id,
                                       Marca = s.Brand,
                                       Descricao = s.Description
                                   }).OrderBy(o => o.Marca)
                                   .ToList();

            var col = new DataGridViewCheckBoxColumn();
            var textboxColumn = new DataGridViewTextBoxColumn();

            col.HeaderText = "Check";
            col.Width = 50;
            col.Name = "Selecione";

            textboxColumn.Name = "quantidade";
            textboxColumn.HeaderText = "Qtd.";
            textboxColumn.Width = 50;

            dgvProducts.DataSource = products;
            dgvProducts.Columns.Insert(0, col);
            dgvProducts.Columns[1].HeaderText = "Codigo";
            dgvProducts.Columns[2].HeaderText = "Marca";
            dgvProducts.Columns[3].HeaderText = "Descrição";
            dgvProducts.Columns.Insert(4, textboxColumn);

            dgvProducts.Columns[1].Width = 50;
            dgvProducts.Columns[3].Width = 250;
        }

        public void SelectProvider()
        {
            var provider = new FrmListProvider();
            provider.ShowDialog();

            if (provider.DialogResult == DialogResult.OK)
            {
                var dataGrid = provider.dgvProviders.Rows[provider.dgvProviders.CurrentRow.Index];

                txtCode.Text = dataGrid.Cells[0].Value.ToString();
                txtName.Text = dataGrid.Cells[1].Value.ToString();
            }
        }

        private void Insert(RegisterViewModel viewModel)
        {

        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            SelectProvider();
        }
    }
}
