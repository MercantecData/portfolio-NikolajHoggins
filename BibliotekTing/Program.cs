using System;
using System.Collections.Generic;
using System.Linq;

namespace BibliotekTing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Boss", 60000, "Beau Lehser", 52, "Somewhere inbetween"));
            employees.Add(new Employee("Librarian", 31000, "Vedu HaenBogh", 32, "Kvinde"));
            employees.Add(new Employee("Janitor", 42000, "Stø Uvfjer Nher", 61, "Mand"));

            List<Book> books = new List<Book>();
            books.Add(new Book("The Lost Chapter", 3219, true, new Category("Krimi")));
            books.Add(new Book("Harry Potter", 3219, true, new Category("Magi")));

            var myLib = new Library("Sct. Nogga's Library", "Wall St. 12th avenue", employees, books, 120);

            
        }
    }
}
