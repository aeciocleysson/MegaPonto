using System;
using System.Data;
using System.Windows.Forms;

namespace Sis_Vendas_Mega.Relatorio
{
    public partial class FrmRelatorioMensal : Form
    {
        DataTable _data = new DataTable();
        string _horaTotal;
        DateTime _dtInicio, _dtFim;
        
        public FrmRelatorioMensal(DataTable data, string horaTotal, DateTime dtInicio, DateTime dtFim)
        {
            InitializeComponent();
            _data = data;
            _horaTotal = horaTotal;
            _dtInicio = dtInicio;
            _dtFim = dtFim;
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
            
            this.rvFechamentoMensal.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dtInicio", _dtInicio.ToString("dd/MM/yyyy")));
            this.rvFechamentoMensal.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("dtFim", _dtFim.ToString("dd/MM/yyyy")));
            this.rvFechamentoMensal.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("totalTrabalhado", _horaTotal));
            rvFechamentoMensal.RefreshReport();
        }
    }
}
