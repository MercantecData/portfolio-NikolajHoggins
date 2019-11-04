using System.Collections.Generic;

namespace BibliotekTing
{
    public class Schedule
    {
        public List<Day> daysWorked;
        public Day currentDay;

        public void saveDay()
        {
            currentDay.hoursWorked = (currentDay.clockOut - currentDay.clockIn).TotalHours;

            daysWorked.Add(currentDay);

            currentDay = null;
        }
    }
}