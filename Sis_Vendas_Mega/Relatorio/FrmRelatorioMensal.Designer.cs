﻿
namespace Sis_Vendas_Mega.Relatorio
{
    partial class FrmRelatorioMensal
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
            this.rvFechamentoMensal = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvFechamentoMensal
            // 
            this.rvFechamentoMensal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvFechamentoMensal.LocalReport.ReportEmbeddedResource = "Sis_Vendas_Mega.Relatorio.RelatorioMensal.rdlc";
            this.rvFechamentoMensal.Location = new System.Drawing.Point(0, 0);
            this.rvFechamentoMensal.Name = "rvFechamentoMensal";
            this.rvFechamentoMensal.ServerReport.BearerToken = null;
            this.rvFechamentoMensal.Size = new System.Drawing.Size(730, 538);
            this.rvFechamentoMensal.TabIndex = 0;
            // 
            // FrmRelatorioMensal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 538);
            this.Controls.Add(this.rvFechamentoMensal);
            this.Name = "FrmRelatorioMensal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fechamento Mensal";
            this.Load += new System.EventHandler(this.FrmRelatorioMensal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvFechamentoMensal;
    }
}