using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotekTing
{
    class Library
    {
        public string name;
        public string addresse;
        public int maxVisitors;

        public List<Employee> employees;
        public List<Book> books;
        public List<Category> categories;
        public List<Visitor> visitors;

        public Library(string name, string addresse, List<Employee> employees, List<Book> books, List<Category> categories, List<Visitor> guests, int maxVisitors)
        {
            this.name = name;
            this.addresse = addresse;
            this.employees = employees;
            this.books = books;
            this.categories = categories;
            this.maxVisitors = maxVisitors;
        }
        public void closeLibrary() //Kick out all visitors, then make all employees currently at work clock out
        {
            kickOutVisitors();
            foreach (var employee in employees)
            {
                if(employee.schedule.currentDay != null)
                {
                    employee.clockOut();
                }
            }

        }
        public bool addVisitor(Visitor visitor)
        {
            if(visitors.Count >= maxVisitors || visitor.visiting)
            {
                return false;
            }

            visitors.Add(visitor);
            visitor.visiting = true;
            return true;
        }

        public void kickOutVisitors()
        {
            foreach (var visitor in visitors)
            {
                visitor.visiting = false;
            }
            visitors.Clear();
        }
    }
}
