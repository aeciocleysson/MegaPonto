using System;

namespace Sis_Vendas_Mega.ViewModel
{
    public class HoursViewModel : BaseViewModel
    {
        public TimeSpan EntryTime { get; set; }
        public TimeSpan OutLanch { get; set; }
        public TimeSpan ReturnLunch { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan Worked { get; set; }
        public TimeSpan Minutes { get; set; }
    }
}
