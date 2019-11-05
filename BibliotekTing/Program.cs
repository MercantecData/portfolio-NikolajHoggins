using System;
using System.Collections.Generic;
using System.Linq;

namespace BibliotekTing
{
    class Program
    {
        static Library mainLibrary;
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Boss", 60000, "Beau Lehser", 52, "Somewhere inbetween"));
            employees.Add(new Employee("Librarian", 31000, "Vedu HaenBogh", 32, "Kvinde"));
            employees.Add(new Employee("Janitor", 42000, "Stø Uvfjer Nher", 61, "Mand"));

            List<Book> books = new List<Book>();
            books.Add(new Book("The Lost Chapter", 3219, true, new Category("Krimi")));
            books.Add(new Book("Harry Potter", 3219, true, new Category("Magi")));
            books.Add(new Book("Mein Kampf", 420, true, new Category("Fiktion")));


            mainLibrary = new Library("Sct. Nogga's Library", "Wall St. 12th avenue", employees, books, 120);

            mainLibrary.addVisitor(new Visitor("jonas jespersen", 52, "kvinde"));
            MainLoop();
        }


        static void MainLoop()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Hello, welcome to " + mainLibrary.name+"\n");
                Console.WriteLine("Chose option:");
                Console.WriteLine("1: Get Library information");
                Console.WriteLine("2: Change Library information");
                Console.WriteLine("3: View data:");
                Console.WriteLine("4: Add data:");
                Console.WriteLine("5: Change data:");
                Console.WriteLine("6: Add visitors");
                Console.WriteLine("7: Rent out book");
                Console.WriteLine("8: See rentet out books");
                Console.WriteLine("9: Change book due date");
                string sAnswer = Console.ReadLine();
                try
                {
                    int iAnswer = int.Parse(sAnswer);
                    Console.Clear();
                    HandleChoice(iAnswer);
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Make sure your answer is a number :P");
                }
                Console.WriteLine("Press enter to continue...");
                Console.ReadKey();


            }
        }
        static void HandleChoice(int n)
        {
            switch (n)
            {
                case 1:
                    foreach (var item in mainLibrary.getLibraryInformation())
                    {
                        Console.WriteLine(item);
                    }
                    break;

                case 6:
                    AddVisitorToLib();
                    break;
                case 7:
                    CheckOutBook();
                    break;
                case 8:
                    foreach (var book in mainLibrary.getRentetOutBooks())
                    {
                        Console.WriteLine("Book: " + book.name);
                        Console.WriteLine("Rentet by: " + book.currentHolder.getName());
                        Console.WriteLine("Due at: " + book.dueDate.ToString() + "\n\n");
                    }
                    break;
                case 9:

                    break;
                default:
                    break;
            }
        }

        static void ChangeBookDue()
        {
            Console.WriteLine("Which of the following books do you wish to edit?");
            for (int i = 0; i < mainLibrary.books.Count; i++)
            {
                if (mainLibrary.books[i].available)
                {
                    return;
                }
                Console.WriteLine("["+i+"] "+mainLibrary.books[i].name);
            }

            bool bookChoiceDone = false;
            while (!bookChoiceDone)
            {
                string bookAnswer = Console.ReadLine();
                try
                {
                    int bookIndex = int.Parse(bookAnswer);
                    //Here we need to make sure the book exists and is in fact avaiable before we chose if for the functioncall
                    if (bookIndex >= mainLibrary.books.Count)
                    {
                        Console.WriteLine("That was not an option boy.");
                    }
                    else if (!mainLibrary.books[bookIndex].available)
                    {
                        Console.WriteLine("Choose one of the options please..");
                    }
                    else
                    {
                        //Call library method with the book, and visitor
                        bookChoiceDone = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please choose an actual number..");
                }
            }
        }
        static void CheckOutBook()
        {
            //If no visitors are in the library we should just return without asking user to pick one.
            if(!(mainLibrary.visitors.Count > 0))
            {
                Console.WriteLine("No visitors in the library");
                return;
            }
            //Ligeledes hvis vi ikke har en eneste available book, skal vi også bare return
            bool booksAvail = false;
            foreach (var book in mainLibrary.books)
            {
                if (book.available)
                {
                    booksAvail = true;
                }
            }
            if (!booksAvail)
            {
                Console.WriteLine("No books available");
                return;
            }

            //vi lister alle visitors med et tal valg udenfor navnet på visitor, man vælger så en.
            bool notChosen = true;
            int visIndex = 0;
            while (notChosen)
            {
                Console.WriteLine("Please chose a visitor:");
                for (int i = 0; i < mainLibrary.visitors.Count; i++)
                {
                    Console.WriteLine("[" + i + "] " + mainLibrary.visitors[i].getName());
                }
                string visitorAnswer = Console.ReadLine();
                try
                {
                    visIndex = int.Parse(visitorAnswer);
                    if(visIndex > mainLibrary.visitors.Count - 1)
                    {
                        Console.WriteLine("Chose one of the people on the list please...");
                    }
                    else
                    {
                        notChosen = false;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
         
            //Samme med bog, bortset fra lidt flere tjek
            Console.WriteLine("Please chose a book:");
            for (int i = 0; i < mainLibrary.books.Count; i++)
            {
                if (mainLibrary.books[i].available) //skriv kun available books
                {
                    Console.WriteLine("[" + i + "] " + mainLibrary.books[i].name);
                }
            }
            bool bookChoiceDone = false;
            while (!bookChoiceDone)
            {
                string bookAnswer = Console.ReadLine();
                try
                {
                    int bookIndex = int.Parse(bookAnswer);
                    //Here we need to make sure the book exists and is in fact avaiable before we chose if for the functioncall
                    if(bookIndex >= mainLibrary.books.Count)
                    {
                        Console.WriteLine("That was not an option boy.");
                    }
                    else if (!mainLibrary.books[bookIndex].available)
                    {
                        Console.WriteLine("Choose one of the options please..");
                    }
                    else {
                        //Call library method with the book, and visitor
                        mainLibrary.checkOutBook(mainLibrary.books[bookIndex], mainLibrary.visitors[visIndex]);
                        bookChoiceDone = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please choose an actual number..");
                }
            }
        }

        //here we can create a new visitor of the library, for that we need a name, age and gender
        static void AddVisitorToLib()
        {
            Console.WriteLine("Type visitor name");
            string visName = Console.ReadLine();
            bool notAge = true;
            int visAge = 0;

            //This loop makes you type until an int i put in as input
            while (notAge)
            {
                Console.WriteLine("Type visitor age");
                string oldVisAge = Console.ReadLine();

                try
                {
                    notAge = false;
                    visAge = int.Parse(oldVisAge);
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a number instead plebtard..");
                }
            }
            Console.WriteLine("Type visitor gender");
            string visGender = Console.ReadLine();
            //We then add the visitor to the lib objects visitor list.
            mainLibrary.visitors.Add(new Visitor(visName, visAge, visGender));
        }

    }
}
