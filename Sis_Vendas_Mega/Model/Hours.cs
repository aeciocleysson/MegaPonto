using System;

namespace Sis_Vendas_Mega.Model
{
    public class Hours : BaseModel
    {
        public TimeSpan Entry { get; private set; }
        public TimeSpan Lunch { get; private set; }
        public TimeSpan Exit { get; private set; }
        public TimeSpan TotalWeek { get; private set; }
        public TimeSpan TotalMonth { get; private set; }

        public Hours(TimeSpan entry, TimeSpan lunch, TimeSpan exit, TimeSpan totalWeek, TimeSpan totalMonth)
        {
            Entry = entry;
            Lunch = lunch;
            Exit = exit;
            TotalWeek = totalWeek;
            TotalMonth = totalMonth;
        }
    }
}
