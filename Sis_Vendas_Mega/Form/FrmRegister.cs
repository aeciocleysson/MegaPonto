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

            var textboxColumn = new DataGridViewTextBoxColumn();

            textboxColumn.Name = "Quantidade";
            textboxColumn.HeaderText = "Qtd.";
            textboxColumn.Width = 50;

            dgvProducts.DataSource = products;
            //dgvProducts.Columns[0].HeaderText = "Codigo";
            //dgvProducts.Columns[1].HeaderText = "Marca";
            //dgvProducts.Columns[2].HeaderText = "Descrição";
            //dgvProducts.Columns.Insert(3, textboxColumn);

            dgvProducts.Columns[1].Width = 50;
            dgvProducts.Columns[3].Width = 250;
        }

        private void GetByDate(DateTime date)
        {

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

        private void InsertRegister(RegisterViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(txtCode.Text))
            {

                viewModel.ProviderId = Convert.ToInt32(txtCode.Text);

                var model = new Register(providerId: viewModel.ProviderId);

                _context.AddRange(model);
                _context.SaveChanges();

                GetAllProducts();
            }
            else
            {
                MessageBox.Show("Selecione um ornecedor!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertItens(RegisterItensViewModel viewModel)
        {
            var result = _context.Registers.Where(w => w.IsDelete == 0).OrderBy(o => o.Id).Last();

            viewModel.RegisterId = result.Id;
            var listItens = new List<RegisterItens>();

            for (int i = 0; i <= dgvProducts.Rows.Count - 1; i++)
            {
                var a = dgvProducts.Rows[i].Cells[0].Value;
                var b = dgvProducts.Rows[i].Cells[1].Value;
                var c = dgvProducts.Rows[i].Cells[2].Value;
                var d = dgvProducts.Rows[i].Cells[3].Value;
            }

            //foreach (DataGridViewRow item in dgvProducts.Rows)
            //{
            //    //if (item.Cells[0].Value != null)
            //    //{
            //    var c = item.Cells[1].Value.ToString();
            //    var d = item.Cells[2].Value.ToString();
            //    //var e = item.Cells[3].Value.ToString();
            //    var f = item.Cells[4].Value.ToString();
            //    var g = item.Cells[5].Value.ToString();

            //    //viewModel.ProductId = Convert.ToInt32(item.Cells[1].Value.ToString());
            //    //    viewModel.Quantidade = Convert.ToInt32(item.Cells[2].Value.ToString());

            //    //    var model = new RegisterItens(registerId: viewModel.RegisterId, quantidade: viewModel.Quantidade, productId: viewModel.ProductId);

            //    //listItens.Add(model);
            //    //}
            //    //else
            //    //{
            //    //    continue;
            //    //}
            //}
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            SelectProvider();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var viewModel = new RegisterViewModel();
            InsertRegister(viewModel);

            var itens = new RegisterItensViewModel();
            InsertItens(itens);
        }
    }
}
