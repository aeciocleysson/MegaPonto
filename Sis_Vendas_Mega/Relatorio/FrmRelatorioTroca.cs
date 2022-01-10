using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sis_Vendas_Mega.Relatorio
{
    public partial class FrmRelatorioTroca : Form
    {
        public FrmRelatorioTroca()
        {
            InitializeComponent();
        }

        private void FrmRelatorioTroca_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
