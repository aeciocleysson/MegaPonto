using Sis_Vendas_Mega.Data;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sis_Vendas_Mega
{
    public partial class FrmListProvider : Form
    {
        private DataContext _context;

        public FrmListProvider()
        {
            InitializeComponent();
            _context = new DataContext();
            GetAll();
        }

        private void GetAll()
        {
            var providers = _context.Providers
                                    .Where(w => w.IsDelete == 0)
                                    .Select(s => new
                                    {
                                        s.Id,
                                        s.Name
                                    })
                                    .ToList();

            dgvProviders.DataSource = providers;
            dgvProviders.Columns[0].HeaderText = "Código";
            dgvProviders.Columns[1].HeaderText = "Nome";
            dgvProviders.Columns[1].Width = 400;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void dgvProviders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProviders.Rows.Count == 0)
                return;
            else
                DialogResult = DialogResult.OK;

            Close();
        }
    }
}
