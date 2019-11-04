using System;
using System.Collections.Generic;
using System.Linq;
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
            this.categories = new List<Category>();
            this.visitors = new List<Visitor>();
            updateCategories();
        }

        /// 
        /// - 3 Linjer comments er funktioner eller vigtige dele kode der specifikt opfylder opgavekrav.
        /// 

        /// 
        /// - Låne en bog med en bestemt titel
        ///
        public void checkOutBookByName(Visitor visitor, string bookName)
        {
            if (bookAvailByName(bookName))
            {
                checkOutBook(getBookByName(bookName), visitor);
            }
        }

        ///
        ///  - Checke om en bog med en bestemt titel er hjemme
        ///
        public bool bookAvailByName(string bookName)
        {
            foreach (var book in books)
            {
                if(book.name == bookName && book.available)
                {
                    return true;
                }
            }
            return false;
        }


        ///
        ///  - Returnere en bog
        /// 
        //Check om bogen overhovedet er lånt, vi ser så om de er sent på den for at kunne tage bøde, derefter fjerner vi bogen fra tidligere låners låneliste.
        public void returnBook(Book book)
        {
            if (book.available)
            {
                return;
            }
            

            if ((book.dueDate - DateTime.Now).TotalMinutes < 0)
            {
                //Penalty for returning late
            }
            else
            {
                //thanks biatch
            }
            book.available = true;
            if (book.currentHolder != null)
            {
                Visitor bookOwner = book.currentHolder;
                bookOwner.books.Remove(book);
            }

        }

        //Only to be used after book AvailByName
        public Book getBookByName(string bookName)
        {
            return books.FirstOrDefault(o => o.name == bookName);
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


        //Kick out all visitors, then make all employees currently at work clock out, no overtime pay for those suckers
        public void closeLibrary() 
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

        //This is what happens when a visitor enters the library
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

        //Removes all visitors from the library.
        public void kickOutVisitors() 
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
            if(categories.Count > 0)
            {
                categories.Clear();
            }
            foreach (var item in books)
            {
                if (!categories.Contains(item.category) && item.available)
                {
                    categories.Add(item.category);
                }
            }
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
