using System;

namespace Sis_Vendas_Mega.ViewModel
{
    public class ScoreViewModel : BaseViewModel
    {
        public TimeSpan EntryTime { get; set; }
        public TimeSpan OutLanch { get; set; }
        public TimeSpan ReturnLunch { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan FullRange { get; set; }
        public TimeSpan Worked { get; set; }
        public int EmployeeId { get; set; }
        public long Code { get; set; }
        public double Minutes { get; set; }
    }
}
