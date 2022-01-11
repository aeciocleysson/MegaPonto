
namespace Sis_Vendas_Mega.Relatorio
{
    partial class FrmRelatorioTroca
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewerTrocas = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DadosTrocasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DadosTrocasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewerTrocas
            // 
            this.reportViewerTrocas.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetTrocas";
            reportDataSource1.Value = this.DadosTrocasBindingSource;
            this.reportViewerTrocas.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerTrocas.LocalReport.ReportEmbeddedResource = "Sis_Vendas_Mega.Relatorio.RelatorioTroca.rdlc";
            this.reportViewerTrocas.Location = new System.Drawing.Point(0, 0);
            this.reportViewerTrocas.Name = "reportViewerTrocas";
            this.reportViewerTrocas.ServerReport.BearerToken = null;
            this.reportViewerTrocas.Size = new System.Drawing.Size(730, 538);
            this.reportViewerTrocas.TabIndex = 0;
            // 
            // DadosTrocasBindingSource
            // 
            this.DadosTrocasBindingSource.DataSource = typeof(Sis_Vendas_Mega.Model.DadosTrocas);
            // 
            // FrmRelatorioTroca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 538);
            this.Controls.Add(this.reportViewerTrocas);
            this.Name = "FrmRelatorioTroca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatorio Troca";
            this.Load += new System.EventHandler(this.FrmRelatorioTroca_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DadosTrocasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerTrocas;
        private System.Windows.Forms.BindingSource DadosTrocasBindingSource;
    }
}