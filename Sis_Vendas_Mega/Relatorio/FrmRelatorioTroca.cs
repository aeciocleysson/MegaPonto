using Sis_Vendas_Mega.Data;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sis_Vendas_Mega.Relatorio
{
    public partial class FrmRelatorioTroca : Form
    {
        private DataContext _context;
        public int _code;
        public FrmRelatorioTroca(int code)
        {
            InitializeComponent();
            _context = new DataContext();
            _code = code;
        }

        private void FrmRelatorioTroca_Load(object sender, EventArgs e)
        {
            var result = _context.RegisterItens
                              .Where(w => w.IsDelete == 0 && w.Register.Id == _code)
                              .Select(s => new
                              {
                                  RegisterId = s.Register.Id,
                                  DateRegister = s.Inserted.ToString("dd/MM/yyyy"),
                                  ProviderId = s.Register.Provider.Id,
                                  ProviderName = s.Register.Provider.Name,
                                  ProductId = s.Product.Id,
                                  ProductName = s.Product.Description,
                                  Quantidade = s.Quantidade
                              }).ToArray();

            var dataSource = new Microsoft.Reporting.WinForms.ReportDataSource("DataSetTrocas", result);
            this.reportViewerTrocas.LocalReport.DataSources.Clear();
            this.reportViewerTrocas.LocalReport.DataSources.Add(dataSource);
            this.reportViewerTrocas.RefreshReport();
        }
    }
}
