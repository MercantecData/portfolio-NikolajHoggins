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

        public Library(string name, string addresse, List<Employee> employees, List<Book> books, int maxVisitors)
        {
            this.name = name;
            this.addresse = addresse;
            this.employees = employees;
            this.books = books;
            this.maxVisitors = maxVisitors;

            updateCategories();
        }
        public void closeLibrary() //Kick out all visitors, then make all employees currently at work clock out, no overtime pay for those suckers
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

        public void kickOutVisitors() //Removes all visitors from the library.
        {
            foreach (var visitor in visitors)
            {
                visitor.visiting = false;
            }
            visitors.Clear();
        }

        //Recieves a new book, adds to book list, and refreshes categorie
        public void getNewBook(Book book)
        {
            books.Add(book);
            updateCategories();
        }

        //Gets every available book, checks the category if it isn't on the category list it is added.
        public void updateCategories()
        {
            categories.Clear();
            foreach (var item in books)
            {
                if (!categories.Contains(item.category) && item.available)
                {
                    categories.Add(item.category);
                }
            }
        }
        //Check if book is loaned out, if not we put it on the visitor book list, add 14 days from now to the due date and makes the book unavailable
        public void checkOutBook(Book book, Visitor visitor) 
        {
            if (!book.available)
            {
                return;
            }
            book.dueDate = DateTime.Now.AddDays(14);
            book.currentHolder = visitor;
            visitor.books.Add(book);
            book.available = false;
        }

        //Returns all books that are available (by category if specified) 
        public List<Book> getAvailBooks(Category searchCategory = null) { 
            var searchResult = new List<Book>();
            if(searchCategory == null)
            {
                foreach (var book in books)
                {
                    if (book.available)
                    {
                        searchResult.Add(book);
                    }
                }
            }
            else
            {
                foreach (var book in books)
                {
                    if(book.category == searchCategory && book.available)
                    {
                        searchResult.Add(book);
                    } 
                }
            }
            return searchResult;
        }
    }
}
