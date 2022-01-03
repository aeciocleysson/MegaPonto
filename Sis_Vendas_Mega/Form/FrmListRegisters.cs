using Sis_Vendas_Mega.Data;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sis_Vendas_Mega
{
    public partial class FrmListRegisters : Form
    {
        private DataContext _context;
        public FrmListRegisters()
        {
            InitializeComponent();
            _context = new DataContext();
            GetAll();
        }

        private void GetAll()
        {
            var result = _context.Registers
                                 .Where(w => w.IsDelete == 0)
                                 .Select(s => new
                                 {
                                     Codigo = s.Id,
                                     Data = s.Inserted,
                                     CodFornecedor = s.ProviderId,
                                     Fornecedor = s.Provider.Name
                                 }).OrderByDescending(o => o.Data).ToList();

            dgvRegisters.DataSource = result;

            dgvRegisters.Columns[0].HeaderText = "Código";
            dgvRegisters.Columns[1].HeaderText = "Data";
            dgvRegisters.Columns[2].HeaderText = "Cód. Fornec";
            dgvRegisters.Columns[3].HeaderText = "Fornecedor";

            dgvRegisters.Columns[3].Width = 300;
        }

        private void GetAll(string texto)
        {
            var result = _context.Registers
                                 .Where(w => w.IsDelete == 0 && w.Provider.Name.Contains(texto))
                                 .Select(s => new
                                 {
                                     Codigo = s.Id,
                                     Data = s.Inserted,
                                     CodFornecedor = s.ProviderId,
                                     Fornecedor = s.Provider.Name
                                 }).OrderByDescending(o => o.Data).ToList();

            dgvRegisters.DataSource = result;

            dgvRegisters.Columns[0].HeaderText = "Código";
            dgvRegisters.Columns[1].HeaderText = "Data";
            dgvRegisters.Columns[2].HeaderText = "Cód. Fornec";
            dgvRegisters.Columns[3].HeaderText = "Fornecedor";

            dgvRegisters.Columns[3].Width = 300;
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
            if (dgvRegisters.Rows.Count == 0)
                return;
            else
                DialogResult = DialogResult.OK;

            Close();
        }
    }
}
