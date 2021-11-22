using System;

namespace Sis_Vendas_Mega.ViewModel
{
    public class ScoreViewModel : BaseViewModel
    {
        public DateTime EntryTime { get; set; }
        public DateTime OutLanch { get; set; }
        public DateTime ReturnLunch { get; set; }
        public DateTime DepartureTime { get; set; }
        public TimeSpan FullRange { get; set; }
        public TimeSpan Worked { get; set; }
        public int EmployeeId { get; set; }
        public long Code { get; set; }
        public long Minutes { get; set; }
    }
}
