using Sis_Vendas_Mega.Data;
using Sis_Vendas_Mega.Relatorio;
using System;
using System.Data;
using System.Globalization;

using System.Linq;
using System.Windows.Forms;

namespace Sis_Vendas_Mega
{
    public partial class FrmAllRegisters : Form
    {
        private DataContext _context;
        public FrmAllRegisters()
        {
            InitializeComponent();
            _context = new DataContext();
        }

        public void ClearFilds()
        {
            txtCodeProvider.Clear();
            txtNameProvider.Clear();
            txtCodeExchange.Clear();
            dtData.Clear();
            dgvRegister.DataSource = null;
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

            if (!string.IsNullOrEmpty(txtCodeExchange.Text))
                GetAll(Convert.ToInt32(txtCodeExchange.Text));
            else
                return;
        }

        private void GetAll(int id)
        {
            var result = _context.RegisterItens
                                 .Where(w => w.IsDelete == 0 && w.RegisterId == id)
                                 .Select(s => new
                                 {
                                     Codigo = s.Id,
                                     ProdutoId = s.Product.Id,
                                     Descricao = s.Product.Description,
                                     Quantidade = s.Quantidade
                                 }).ToList();

            dgvRegister.DataSource = result;

            dgvRegister.Columns[0].HeaderText = "Código";
            dgvRegister.Columns[1].HeaderText = "Cod. Produto";
            dgvRegister.Columns[2].HeaderText = "Descrição";
            dgvRegister.Columns[3].HeaderText = "Quantidade";
            dgvRegister.Columns[2].Width = 400;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SelectRegisters();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodeExchange.Text))
            {
                var code = _context.RegisterItens.Where(w => w.IsDelete == 0 && w.RegisterId == Convert.ToInt32(txtCodeExchange.Text)).First();
                var report = new FrmRelatorioTroca(code.RegisterId);
                report.Show();
            }else
            {
                MessageBox.Show("Selecione um Registro.", "Alerta", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFilds();
        }
    }
}
