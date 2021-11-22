using System;

namespace Sis_Vendas_Mega.ViewModel
{
    public class HoursViewModel : BaseViewModel
    {
        public TimeSpan Entry { get; set; }
        public TimeSpan Lunch { get; set; }
        public TimeSpan Exit { get; set; }
        public TimeSpan TotalWeek { get; set; }
        public TimeSpan TotalMonth { get; set; }
    }
}
