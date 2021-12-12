using Sis_Vendas_Mega.Data;
using Sis_Vendas_Mega.Model;
using Sis_Vendas_Mega.ViewModel;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Sis_Vendas_Mega
{
    public partial class FrmProvider : Form
    {
        private DataContext _context;
        public FrmProvider()
        {
            InitializeComponent();
            _context = new DataContext();
            ClearFields();
            GetAll();
        }

        private void ClearFields()
        {
            txtCode.Clear();
            txtName.Clear();
            txtName.Select();
            txtName.Focus();
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

            dgvProvider.DataSource = providers;
            dgvProvider.Columns[0].HeaderText = "Código";
            dgvProvider.Columns[1].HeaderText = "Nome";
            dgvProvider.Columns[1].Width = 400;
        }

        private void Insert(ProviderViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                if (string.IsNullOrEmpty(txtCode.Text))
                {
                    viewModel.Name = txtName.Text;

                    var model = new Provider(name: viewModel.Name);

                    _context.Add(model);
                    _context.SaveChanges();

                    MessageBox.Show("Cadastrado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    GetAll();
                }
                else
                {

                    viewModel.Id = Convert.ToInt32(txtCode.Text);

                    var model = _context.Providers.Find(viewModel.Id);

                    viewModel.Name = txtName.Text;

                    model.Update(name: viewModel.Name);

                    _context.Update(model);
                    _context.SaveChanges();

                    MessageBox.Show("Atualizado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    GetAll();
                }
            }
            else
            {
                MessageBox.Show("Nome é obrigatório!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Delete(ProviderViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(txtCode.Text))
            {
                viewModel.Id = Convert.ToInt32(txtCode.Text);
                viewModel.IsDelete = 1;
                var model = _context.Providers.Find(viewModel.Id);

                model.Delete(isDelete: viewModel.IsDelete);

                _context.Update(model);
                _context.SaveChanges();

                MessageBox.Show("Excluido com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                GetAll();
            }
            else
            {
                MessageBox.Show("Selecione um fornecedor!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var viewModel = new ProviderViewModel();
            Insert(viewModel);
        }

        private void dgvProvider_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvProvider.Rows[e.RowIndex];

                txtCode.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var viewModel = new ProviderViewModel();
            Delete(viewModel);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
