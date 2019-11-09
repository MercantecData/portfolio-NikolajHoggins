using System.Collections.Generic;

namespace BibliotekTing
{
    public class Schedule
    {
        public List<Day> days;
        public Day currentDay;

        public void saveDay()
        {
            currentDay.hoursWorked = (currentDay.clockOut - currentDay.clockIn).TotalHours;

            days.Add(currentDay);

            currentDay = null;
        }
    }
}