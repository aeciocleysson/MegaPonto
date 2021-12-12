using Sis_Vendas_Mega.Data;
using Sis_Vendas_Mega.Model;
using Sis_Vendas_Mega.ViewModel;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Sis_Vendas_Mega
{
    public partial class FrmProduct : Form
    {
        private DataContext _context;
        public FrmProduct()
        {
            InitializeComponent();
            _context = new DataContext();
            ClearFields();
            GetAll();
        }

        private void ClearFields()
        {
            txtCode.Clear();
            txtpesquisar.Clear();
            txtBrand.Clear();
            txtDescription.Clear();
            txtDescription.Focus();
            txtDescription.Select();
        }

        private void GetAll()
        {
            var products = _context.Products
                                   .Where(w => w.IsDelete == 0)
                                   .Select(s => new
                                   {
                                       s.Id,
                                       s.Brand,
                                       s.Description,
                                       s.Inserted
                                   })
                                   .ToList();

            dgvProducts.DataSource = products;

            dgvProducts.Columns[0].HeaderText = "Código";
            dgvProducts.Columns[1].HeaderText = "Marca";
            dgvProducts.Columns[2].HeaderText = "Descrição";
            dgvProducts.Columns[3].HeaderText = "Data Cadastro";

            dgvProducts.Columns[2].Width = 300;
        }

        private void GetAll(string texto)
        {
            var products = _context.Products
                                   .Where(w => w.IsDelete == 0 && w.Description.Contains(texto) || 
                                               w.IsDelete == 0 && w.Brand.Contains(texto))
                                   .Select(s => new
                                   {
                                       s.Id,
                                       s.Brand,
                                       s.Description,
                                       s.Inserted
                                   })
                                   .ToList();

            dgvProducts.DataSource = products;

            dgvProducts.Columns[0].HeaderText = "Código";
            dgvProducts.Columns[1].HeaderText = "Marca";
            dgvProducts.Columns[2].HeaderText = "Descrição";
            dgvProducts.Columns[3].HeaderText = "Data Cadastro";

            dgvProducts.Columns[2].Width = 300;
        }


        public void Insert(ProductViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(txtBrand.Text) && !string.IsNullOrEmpty(txtDescription.Text))
            {
                if (string.IsNullOrEmpty(txtCode.Text))
                {
                    viewModel.Brand = txtBrand.Text;
                    viewModel.Description = txtDescription.Text;

                    var model = new Product(brand: viewModel.Brand,
                        description: viewModel.Description);

                    _context.Add(model);
                    _context.SaveChanges();

                    MessageBox.Show("Produto cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    GetAll();
                }
                else
                {
                    viewModel.Id = Convert.ToInt32(txtCode.Text);

                    var model = _context.Products.Find(viewModel.Id);

                    viewModel.Brand = txtBrand.Text;
                    viewModel.Description = txtDescription.Text;

                    model.Update(brand: viewModel.Brand, 
                        description: viewModel.Description);

                    _context.Update(model);
                    _context.SaveChanges();

                    MessageBox.Show("Produto atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    GetAll();
                }
            }
            else
            {
                MessageBox.Show("Marca e Descrição deve ser preenchidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Delete(ProductViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(txtCode.Text))
            {
                viewModel.Id = Convert.ToInt32(txtCode.Text);

                var model = _context.Products.Find(viewModel.Id);

                viewModel.IsDelete = 1;

                model.Delete(isDelete: viewModel.IsDelete);

                _context.Update(model);
                _context.SaveChanges();

                MessageBox.Show("Produto excluido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                GetAll();
            }
            else
            {
                MessageBox.Show("Selecione umProduto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var viewModel = new ProductViewModel();
            Delete(viewModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var viewModel = new ProductViewModel();
            Insert(viewModel);
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvProducts.Rows[e.RowIndex];

                txtCode.Text = row.Cells[0].Value.ToString();
                txtBrand.Text = row.Cells[1].Value.ToString();
                txtDescription.Text = row.Cells[2].Value.ToString();
            }
        }

        private void txtpesquisar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtpesquisar.Text.Trim()))
            {
                GetAll();
            }
            else
            {
                GetAll(txtpesquisar.Text);
            }
        }
    }
}
