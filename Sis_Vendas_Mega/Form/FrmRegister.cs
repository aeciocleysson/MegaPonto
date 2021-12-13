using Sis_Vendas_Mega.Data;
using System;
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
            dgvProducts.Columns.Insert(0,col);
            dgvProducts.Columns[1].HeaderText = "Codigo";
            dgvProducts.Columns[2].HeaderText = "Marca";
            dgvProducts.Columns[3].HeaderText = "Descrição";
            dgvProducts.Columns.Insert(4,textboxColumn);

            dgvProducts.Columns[1].Width = 50;
            dgvProducts.Columns[3].Width = 250;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvProducts.Rows.Count; i++)
            {
                dgvProducts.Rows[i].Cells[3].Value = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvProducts.Rows)
            {
                bool checkSelect = Convert.ToBoolean(item.Cells["Selecione"].Value);
                if (checkSelect)
                {
                    int result = dgvRegisters.Rows.Add();

                    dgvRegisters.Rows[result].Cells[0].Value = item.Cells[2].Value.ToString();
                    dgvRegisters.Rows[result].Cells[1].Value = item.Cells[3].Value.ToString();
                    dgvRegisters.Rows[result].Cells[2].Value = item.Cells[4].Value.ToString();
                    dgvRegisters.Rows[result].Cells[3].Value = item.Cells[1].Value.ToString();
                }
            }
        }
    }
}
