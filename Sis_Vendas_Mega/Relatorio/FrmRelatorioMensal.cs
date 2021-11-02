using System;
using System.Data;
using System.Windows.Forms;

namespace Sis_Vendas_Mega.Relatorio
{
    public partial class FrmRelatorioMensal : Form
    {
        DataTable _data = new DataTable();
        
        public FrmRelatorioMensal(DataTable data)
        {
            _data = data;
            InitializeComponent();
        }

        private void FrmRelatorioMensal_Load(object sender, EventArgs e)
        {
            this.rvFechamentoMensal.LocalReport.DataSources.Clear();
            this.rvFechamentoMensal.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSetFechamentoMensal", _data));
            this.rvFechamentoMensal.RefreshReport();

            ReturnDataRefenrencia();
        }

        public void ReturnDataRefenrencia()
        {
            var result = new FrmListScore();
            
            this.rvFechamentoMensal.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dtInicio", result.dpDtInicio.Value.ToString("dd/MM/yyyy")));
            this.rvFechamentoMensal.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dtFim", result.dpDtFim.Value.ToString("dd/MM/yyyy")));
            rvFechamentoMensal.RefreshReport();
        }
    }
}
