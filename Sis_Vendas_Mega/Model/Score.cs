using System;

namespace Sis_Vendas_Mega.Model
{
    public class Score : BaseModel
    {
        public int EmployeeId { get; private set; }
        public long Code { get; private set; }
        public TimeSpan EntryTime { get; private set; }
        public TimeSpan OutLanch { get; private set; }
        public TimeSpan ReturnLunch { get; private set; }
        public TimeSpan DepartureTime { get; private set; }
        public TimeSpan FullRange { get; private set; }
        public TimeSpan Worked { get; private set; }
        public double Minutes { get; private set; }
        public virtual Employee Employee { get; private set; }

        public Score(int employeeId, long code, TimeSpan entryTime)
        {
            EmployeeId = employeeId;
            Code = code;
            EntryTime = entryTime;
        }

        public Score()
        {

        }

        public void UpdateOutLanch(TimeSpan outLanch)
        {
            OutLanch = outLanch;
        }

        public void UpdateReturnLanch(TimeSpan returnLanch, TimeSpan fullRange)
        {
            ReturnLunch = returnLanch;
            FullRange = fullRange;
        }

        public void UpdateDepartureTime(TimeSpan departureTime, TimeSpan worked, double minutes)
        {
            DepartureTime = departureTime;
            Worked = worked;
            Minutes = minutes;
            UpdateAt = DateTime.Now;
        }

        public void UpdateHours(TimeSpan entryTime, TimeSpan outLanch, TimeSpan returnLanch, TimeSpan departureTime, TimeSpan worked, TimeSpan fullRange, double minutes)
        {
            EntryTime = entryTime;
            OutLanch = outLanch;
            ReturnLunch = returnLanch;
            DepartureTime = departureTime;
            Worked = worked;
            FullRange = fullRange;
            Minutes = minutes;
        }

        public void InsertHoursManual(DateTime inserted,TimeSpan entryTime, TimeSpan outLanch, TimeSpan returnLanch, TimeSpan departureTime, TimeSpan fullRange, TimeSpan worked, 
            double minutes, int employeeId, long code)
        {
            Inserted = inserted;
            EntryTime = entryTime;
            OutLanch = outLanch;
            ReturnLunch = returnLanch;
            DepartureTime = departureTime;
            FullRange = fullRange;
            Worked = worked;
            Minutes = minutes;
            EmployeeId = employeeId;
            Code = code;
        }
    }
}

