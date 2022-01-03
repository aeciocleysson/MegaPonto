using Sis_Vendas_Mega.Data;
using Sis_Vendas_Mega.ViewModel;
using System;
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

        private void GetById()
        {

        }

        public void SelectRegisters()
        {
            var register = new FrmListRegisters();
            register.ShowDialog();

            if (register.DialogResult == DialogResult.OK)
            {
                var dataGrid = register.dgvRegisters.Rows[register.dgvRegisters.CurrentRow.Index];

                txtCodeRegister.Text = dataGrid.Cells[0].Value.ToString();
                dtData.Text = dataGrid.Cells[1].Value.ToString();
                txtCodeProvider.Text = dataGrid.Cells[2].Value.ToString();
                txtName.Text = dataGrid.Cells[3].Value.ToString();
            }

            GetAll(Convert.ToInt32(txtCodeRegister.Text));
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

            dgvAllRegister.DataSource = result;

            dgvAllRegister.Columns[0].HeaderText = "Código";
            dgvAllRegister.Columns[1].HeaderText = "Produto";
            dgvAllRegister.Columns[2].HeaderText = "Quantidade";

            dgvAllRegister.Columns[1].Width = 300;
        }

        private void Update(RegisterItensViewModel viewModel)
        {
            if(!string.IsNullOrEmpty(txtCodeRegister.Text) && !string.IsNullOrEmpty(txtCodeProvider.Text))
            {
                viewModel.Id = Convert.ToInt32(txtCodeRegister.Text);

                foreach (DataGridViewRow item in dgvAllRegister.Rows)
                {
               //id     var a = item.Cells[0].Value   ;
              //descrição      var b = item.Cells[1].Value;
              //quantidade      var c = item.Cells[2].Value;
                  
                }
            }
            else
            {
                MessageBox.Show("Erro");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SelectRegisters();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvAllRegister_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvAllRegister.Rows[e.RowIndex].Cells[2].ReadOnly = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var viewModel = new RegisterItensViewModel();
            Update(viewModel);
        }

        private void dgvAllRegister_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
          var x =   dgvAllRegister.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
    }
}
