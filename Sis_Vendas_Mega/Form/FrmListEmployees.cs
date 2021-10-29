using Sis_Vendas_Mega.Data;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sis_Vendas_Mega
{
    public partial class FrmListEmployees : Form
    {
        private DataContext _context;
        public FrmListEmployees()
        {
            InitializeComponent();
            _context = new DataContext();
            GetAll();
        }

        public void GetAll()
        {
            _context = new DataContext();

            var employees = _context.Employees
                .Where(w => w.IsDelete == 0)
                .Select(s => new
                {
                    s.Id,
                    s.Name
                }).OrderBy(o => o.Name)
                .ToList();

            dgvEmployees.DataSource = employees;

            dgvEmployees.Columns[0].HeaderText = "Código";
            dgvEmployees.Columns[1].HeaderText = "Nome";
            dgvEmployees.Columns[1].Width = 300;
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void dgvEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmployees.Rows.Count == 0)
                return;
            else
                DialogResult = DialogResult.OK;

            Close();
        }
    }
}