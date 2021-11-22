namespace Sis_Vendas_Mega.Model
{
    public class LogScore : BaseModel
    {
        public int Log { get; private set; }
        public int EmployeeId { get; private set; }
        public Employee Employee { get; private set; }

        public LogScore(int log, int employeeId)
        {
            Log = log;
            EmployeeId = employeeId;
        }
    }
}
