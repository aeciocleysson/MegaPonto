using Sis_Vendas_Mega.Data;
using Sis_Vendas_Mega.ViewModel;
using System;
using System.Windows.Forms;

namespace Sis_Vendas_Mega
{
    public partial class FrmHours : Form
    {
        private DataContext _context;
        public FrmHours()
        {
            InitializeComponent();
            _context = new DataContext();
        }

        public void Insert(HoursViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(txtEntry.Text) &&
                !string.IsNullOrEmpty(txtExit.Text))
            {
                viewModel.Entry = TimeSpan.FromHours(Convert.ToInt32(txtEntry.Text));
                viewModel.Exit = TimeSpan.FromHours(Convert.ToInt32(txtExit.Text));
                viewModel.Lunch = TimeSpan.FromHours(Convert.ToInt32(cbAlmoco.SelectedItem));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var viewModel = new HoursViewModel();
            Insert(viewModel);
        }
    }
}
