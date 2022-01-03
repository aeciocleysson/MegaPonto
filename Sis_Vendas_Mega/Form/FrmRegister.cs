using Sis_Vendas_Mega.Data;
using Sis_Vendas_Mega.Model;
using Sis_Vendas_Mega.ViewModel;
using System;
using System.Collections.Generic;
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
            ClearFields();
        }

        private void ClearFields()
        {
            txtCodeRegister.Clear();
            txtCode.Clear();
            txtName.Clear();
        }

        private void NewRegister()
        {
            txtCodeRegister.Clear();
            txtCode.Clear();
            txtName.Clear();
            GetAllProducts();
            dgvRegisters.DataSource = null;
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

            dgvProducts.DataSource = products;
            dgvProducts.Columns[1].HeaderText = "Codigo";
            dgvProducts.Columns[2].HeaderText = "Marca";
            dgvProducts.Columns[3].HeaderText = "Descrição";
            dgvProducts.Columns[2].Width = 100;
            dgvProducts.Columns[3].Width = 250;
        }

        private void GetByDate(DateTime date)
        {
            var code = _context.Registers.Where(w => w.IsDelete == 0).OrderBy(o => o.Id).Last();

            var result = _context.RegisterItens
                .Where(w => w.IsDelete == 0 && w.Inserted == date && w.RegisterId == code.Id)
                .Select(s => new
                {
                    s.Id,
                    Produto = s.ProductId,
                    Marca = s.Product.Brand,
                    Descricao = s.Product.Description,
                    Qtd = s.Quantidade
                }).OrderBy(o => o.Id).ToList();

            dgvRegisters.DataSource = result;

            txtCodeRegister.Text = code.Id.ToString();
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

        private void InsertRegister(RegisterViewModel viewModel, RegisterItensViewModel viewModelItens)
        {
            viewModel.ProviderId = Convert.ToInt32(txtCode.Text);

            var model = new Register(providerId: viewModel.ProviderId);

            _context.AddRange(model);
            _context.SaveChanges();

            var result = _context.Registers.Where(w => w.IsDelete == 0).OrderBy(o => o.Id).Last();

            viewModelItens.RegisterId = result.Id;
            var listItens = new List<RegisterItens>();

            foreach (DataGridViewRow item in dgvProducts.Rows)
            {
                if (item.Cells[0].Value != null)
                {
                    viewModelItens.ProductId = Convert.ToInt32(item.Cells[1].Value.ToString());
                    viewModelItens.Quantidade = Convert.ToInt32(item.Cells[0].Value.ToString());

                    var modelItens = new RegisterItens(registerId: viewModelItens.RegisterId, quantidade: viewModelItens.Quantidade, productId: viewModelItens.ProductId);
                    listItens.Add(modelItens);
                }
                else
                {
                    continue;
                }
            }

            _context.AddRange(listItens);
            _context.SaveChanges();
            GetAllProducts();
            GetByDate(Convert.ToDateTime(dtData.Value.Date));
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCode.Text))
            {
                var viewModel = new RegisterViewModel();
                var itens = new RegisterItensViewModel();
                InsertRegister(viewModel, itens);
            }
            else
            {
                MessageBox.Show("Selecione um Fornecedor!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
            GetAllProducts();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SelectProvider();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewRegister();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
        }
    }
}
