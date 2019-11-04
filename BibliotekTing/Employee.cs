using System;

namespace BibliotekTing
{
    public class Employee : Person
    {
        public string position;
        public double salary;
        public Schedule schedule;

        public Employee(string position, double salary, string name, int age, string gender)
        {
            this.position = position;
            this.salary = salary;
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

        public bool clockIn() //Function check if day is not currently started, then starts the day with current time.
        {
            if(schedule.currentDay != null)
            {
                return false;
            }
            schedule.currentDay = new Day(DateTime.Today, DateTime.Now);
            return true;
        }

        public bool clockOut() //Checks if the day is starte, then adds the clockout and calls function in schedule that saves the day
        {
            if(schedule.currentDay == null)
            {
                return false;
            }
            schedule.currentDay.clockOut = DateTime.Now;
            schedule.saveDay();
            return true;
        }
    }
}