namespace Sis_Vendas_Mega.ViewModel
{
    public class EmployeeViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public long Code { get; set; }
        public int FunctionId { get; set; }
        public string DataNascimento { get; set; }
        public int IsDelete { get; set; }
    }
}
