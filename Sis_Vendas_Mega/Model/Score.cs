using System;

namespace Sis_Vendas_Mega.Model
{
    public class Score : BaseModel
    {
        public DateTime? EntryTime { get; private set; }
        public DateTime? OutLanch { get; private set; }
        public DateTime? ReturnLunch { get; private set; }
        public DateTime? DepartureTime { get; private set; }
        public TimeSpan? Worked { get; private set; }
        public int EmployeeId { get; private set; }
        public virtual Employee Employee { get; private set; }

        public Score(int employeeId, DateTime? entryTime)
        {
            EmployeeId = employeeId;
            EntryTime = entryTime;
        }

        public void UpdateOutLanch(DateTime? outLanch)
        {
            OutLanch = outLanch;
        }

        public void UpdateReturnLanch(DateTime? returnLanch)
        {
            ReturnLunch = returnLanch;
        }

        public void UpdateDepartureTime(DateTime? departureTime, TimeSpan? worked)
        {
            DepartureTime = departureTime;
            Worked = worked;
        }
    }
}
