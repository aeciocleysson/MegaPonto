using Sis_Vendas_Mega.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Sis_Vendas_Mega
{
    public partial class FrmListFunction : Form
    {
        private DataContext _context;

        public FrmListFunction()
        {
            InitializeComponent();
            _context = new DataContext();
            GetAllFunction();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void GetAllFunction()
        {
            var result = _context.Functions
              .Select(s => new
              {
                  Codigo = s.Id,
                  Descricao = s.Description
              }).OrderBy(o => o.Descricao).ToList();

            gvFunctions.DataSource = result;
            gvFunctions.Columns[1].Width = 200;
            gvFunctions.Columns[0].HeaderText = "Código";
            gvFunctions.Columns[1].HeaderText = "Descrição";
        }

        private void gvFunctions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvFunctions.Rows.Count == 0)
                return;
            else
                DialogResult = DialogResult.OK;
            
            Close();
        }

        private void gvFunctions_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gvFunctions.Rows.Count == 0)
                return;
            else
                DialogResult = DialogResult.OK;

            Close();
        }
    }
}
