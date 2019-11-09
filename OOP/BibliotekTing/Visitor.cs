using System.Collections.Generic;

namespace BibliotekTing
{
    public class Visitor : Person
    {
        public bool visiting;
        public List<Book> books;

        public Visitor(string name, int age, string gender)
        {
            this.visiting = false;
            this.name = name;
            this.age = age;
            this.gender = gender;
            this.books = new List<Book>();
        }

        public string getName()
        {
            return this.name;
        }
    }
}