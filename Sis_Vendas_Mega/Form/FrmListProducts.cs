using Sis_Vendas_Mega.Data;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sis_Vendas_Mega
{
    public partial class FrmListProducts : Form
    {
        private DataContext _context;
        public FrmListProducts()
        {
            InitializeComponent();
            _context = new DataContext();
            GetAll();
        }

        private void GetAll()
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

            dgvProducts.DataSource = products;
            dgvProducts.Columns[1].Width = 150;
            dgvProducts.Columns[2].Width = 300;
        }

        private void GetAll(string texto)
        {
            //var result = _context.Products
            //                     .Where(w => w.IsDelete == 0 && w..Name.Contains(texto))
            //                     .Select(s => new
            //                     {
            //                         Codigo = s.Id,
            //                         Data = s.Inserted,
            //                         CodFornecedor = s.ProviderId,
            //                         Fornecedor = s.Provider.Name
            //                     }).OrderByDescending(o => o.Data).ToList();

            //dgvProducts.DataSource = result;

            //dgvProducts.Columns[0].HeaderText = "Código";
            //dgvProducts.Columns[1].HeaderText = "Data";
            //dgvProducts.Columns[2].HeaderText = "Cód. Fornec";
            //dgvProducts.Columns[3].HeaderText = "Fornecedor";

            //dgvProducts.Columns[3].Width = 300;
        }

        private void txtSeach_TextChanged(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSeach.Text.Trim()))
            {
                GetAll();
            }
            else
            {
                GetAll(txtSeach.Text);
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void dgvRegisters_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.Rows.Count == 0)
                return;
            else
                DialogResult = DialogResult.OK;

            Close();
        }
    }
}
