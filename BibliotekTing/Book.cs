using System;

namespace BibliotekTing
{
    public class Book
    {
        public string name;
        public int pages;
        public bool available;

        public DateTime dueDate;
        public Category category;
        public Visitor currentHolder;

        public Book(string name, int pages, bool available, Category category)
        {
            this.name = name;
            this.pages = pages;
            this.available = available;
            this.category = category;
        }
    }
}