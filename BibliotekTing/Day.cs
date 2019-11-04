using System;

namespace BibliotekTing
{
    public class Day
    {
        public DateTime date;
        public DateTime clockIn;
        public DateTime clockOut;
        public double hoursWorked;

        public Day(DateTime date, DateTime clockIn)
        {
            this.date = date;
            this.clockIn = clockIn;
        }
    }
}