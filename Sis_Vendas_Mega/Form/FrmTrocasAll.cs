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
    public partial class FrmTrocasAll : Form
    {
        private DataContext _context;
        public FrmTrocasAll()
        {
            InitializeComponent();
            _context = new DataContext();
        }
        private void ClearFieldsProducts()
        {
            txtCodeProduct.Clear();
            txtNameProduct.Clear();
            txtQuantiti.Clear();
        }
        public void SelectProvider()
        {
            var provider = new FrmListProvider();
            provider.ShowDialog();

            if (provider.DialogResult == DialogResult.OK)
            {
                var dataGrid = provider.dgvProviders.Rows[provider.dgvProviders.CurrentRow.Index];

                txtCodeProvider.Text = dataGrid.Cells[0].Value.ToString();
                txtNameProvider.Text = dataGrid.Cells[1].Value.ToString();
            }
        }

        public void SelectRegisters()
        {
            var register = new FrmListRegisters();
            register.ShowDialog();

            if (register.DialogResult == DialogResult.OK)
            {
                var dataGrid = register.dgvRegisters.Rows[register.dgvRegisters.CurrentRow.Index];

                txtCodeExchange.Text = dataGrid.Cells[0].Value.ToString();
                dtData.Text = dataGrid.Cells[1].Value.ToString();
                txtCodeProvider.Text = dataGrid.Cells[2].Value.ToString();
                txtNameProvider.Text = dataGrid.Cells[3].Value.ToString();
            }

            GetAll(Convert.ToInt32(txtCodeExchange.Text));
        }

        public void SelectProducts()
        {
            var provider = new FrmListProducts();
            provider.ShowDialog();

            if (provider.DialogResult == DialogResult.OK)
            {
                var dataGrid = provider.dgvProducts.Rows[provider.dgvProducts.CurrentRow.Index];

                txtCodeProduct.Text = dataGrid.Cells[0].Value.ToString();
                txtNameProduct.Text = dataGrid.Cells[2].Value.ToString();

                txtQuantiti.Focus();
                txtQuantiti.Select();
            }
        }

        private void GetAll(int id)
        {
            var result = _context.RegisterItens
                                 .Where(w => w.IsDelete == 0 && w.RegisterId == id)
                                 .Select(s => new
                                 {
                                     s.Id,
                                     s.Product.Description,
                                     s.Quantidade
                                 }).ToList();

            dgvRegister.Columns.Remove("Codigo");
            dgvRegister.Columns.Remove("Descricao");
            dgvRegister.Columns.Remove("Quantidade");
            dgvRegister.DataSource = result;

            dgvRegister.Columns[0].HeaderText = "Código";
            dgvRegister.Columns[1].HeaderText = "Descrição";
            dgvRegister.Columns[2].HeaderText = "Quantidade";
            dgvRegister.Columns[1].Width = 300;
        }

        private void InsertGrid()
        {
            if (!string.IsNullOrEmpty(txtCodeProduct.Text) && !string.IsNullOrEmpty(txtQuantiti.Text))
            {
                dgvRegister.Rows.Add(txtCodeProduct.Text, txtNameProduct.Text, txtQuantiti.Text);
                ClearFieldsProducts();
            }
            else
            {
                MessageBox.Show("Insira um produto e a quantidade.");
            }
        }

        public void InsertOrUpdate(RegisterViewModel registerViewModel, RegisterItensViewModel viewModelItens)
        {
            if (!string.IsNullOrEmpty(txtCodeProvider.Text))
            {
                registerViewModel.ProviderId = Convert.ToInt32(txtCodeProvider.Text);

                var registerModel = new Register(providerId: registerViewModel.ProviderId);

                _context.Add(registerModel);
                _context.SaveChanges();

                var result = _context.Registers.Where(w => w.IsDelete == 0).OrderBy(o => o.Id).Last();

                viewModelItens.RegisterId = result.Id;

                var listItens = new List<RegisterItens>();

                foreach (DataGridViewRow item in dgvRegister.Rows)
                {
                    if (item.Cells[2].Value != null && Convert.ToInt32(item.Cells[2].Value) > 0)
                    {
                        viewModelItens.ProductId = Convert.ToInt32(item.Cells[0].Value.ToString());
                        viewModelItens.Quantidade = Convert.ToInt32(item.Cells[2].Value.ToString());

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
            }
            else
            {
                MessageBox.Show("Selecione um Fornecedor!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvAllRegister_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvRegister.Rows[e.RowIndex].Cells[2].ReadOnly = false;
        }

        private void btnExchange_Click(object sender, EventArgs e)
        {
            SelectRegisters();
        }

        private void btnProvider_Click(object sender, EventArgs e)
        {
            SelectProvider();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            SelectProducts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            InsertGrid();
        }

        private void txtQuantiti_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                InsertGrid();
            }
        }
        private void btnProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 121)
            {
                SelectProducts();
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                var viewModel = new RegisterViewModel();
                var itens = new RegisterItensViewModel();
                InsertOrUpdate(viewModel, itens);
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
          
        }

        private void contextMenuGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvRegister.SelectedRows.Count > 0)
                dgvRegister.Rows.RemoveAt(dgvRegister.CurrentRow.Index);
            else
                contextMenuGrid.Hide();
        }

        private void dgvRegister_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                contextMenuGrid.Show();
            else
                contextMenuGrid.Hide();
        }
    }
}
