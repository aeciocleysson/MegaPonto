using System;

namespace Sis_Vendas_Mega.ViewModel
{
    public class HoursViewModel : BaseViewModel
    {
        public DateTime EntryTime { get; set; }
        public DateTime OutLanch { get; set; }
        public DateTime ReturnLunch { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}
