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
            //Her laver vi nogle værdier vi kan teste programmet med.
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Boss", 60000, "Beau Lehser", 52, "Somewhere inbetween"));
            employees.Add(new Employee("Librarian", 31000, "Vedu HaenBogh", 32, "Kvinde"));
            employees.Add(new Employee("Janitor", 42000, "Stø Uvfjer Nher", 61, "Mand"));

            List<Book> books = new List<Book>();
            books.Add(new Book("The Lost Chapter", 3219, true, new Category("Krimi")));
            books.Add(new Book("Harry Potter", 3219, true, new Category("Magi")));
            books.Add(new Book("Mein Kampf", 420, true, new Category("Fiktion")));

            mainLibrary = new Library("Scst. Nogga's Library", "Wall St. 12th avenue", employees, books, 120);
              
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
                Console.WriteLine("2: See all books");
                Console.WriteLine("3: Search Availablity by book name");
                Console.WriteLine("4: Add new book");
                Console.WriteLine("5: Change data [In progress]");
                Console.WriteLine("6: Add visitor");
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
        //Her tager vi userinput og caller den rigtige metode fra den.
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
                case 2:
                    foreach (var book in mainLibrary.books)
                    {
                        if (book.available)
                        {
                            Console.WriteLine(book.name + ": På lager I kategori: "+ book.category.name);
                        }
                        else
                        {
                            Console.WriteLine(book.name + ": Ikke på lager");
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("What book are you looking for?");
                    string answer = Console.ReadLine();
                    //find bog der matcher string og se om den er available
                    foreach (var item in mainLibrary.books)
                    {
                        if(item.name.ToLower() == answer.ToLower() && item.available) {
                            Console.WriteLine("Book, "+item.name+", with "+item.pages+" pages is available");
                            return;
                        }
                            
                    }
                    Console.WriteLine("Book, " + answer + ", is not available.");
                    break;
                case 4:
                    AddNewBook();
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
                    ChangeBookDue();
                    break;
                default:
                    break;
            }
        }
        static void AddNewBook()
        {
            Console.WriteLine("What is the book name?");
            string bookName = Console.ReadLine();
            Console.WriteLine("What is the books category?");
            string bookCat = Console.ReadLine();
            Console.WriteLine("How many pages is is?");
            string sPageCount = Console.ReadLine();
            int pageCount = 0;
            try
            {
                pageCount = int.Parse(sPageCount);
            }
            catch (Exception)
            {
                
            }
            mainLibrary.books.Add(new Book(bookName, pageCount, true, new Category(bookCat)));
        }
        static void ChangeBookDue()
        {
            bool booksRentet = false;
            foreach (var item in mainLibrary.books)
            {
                if (!item.available)
                {
                    booksRentet = true;
                }
            }
            if (!booksRentet) 
            {
                Console.WriteLine("NO BOOKS RENTET BLYAT");
                return;
            }
            

            Console.WriteLine("Which of the following books do you wish to edit?");
            for (int i = 0; i < mainLibrary.books.Count; i++)
            {
                if (!mainLibrary.books[i].available)
                {
                    Console.WriteLine("[" + i + "] " + mainLibrary.books[i].name);
                }
                
            }

            int finalChoice = 0;
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
                    else if (mainLibrary.books[bookIndex].available)
                    {
                        Console.WriteLine("Choose one of the options please..");
                    }
                    else
                    {
                        //Call library method with the book, and visitor
                        bookChoiceDone = true;
                        finalChoice = bookIndex;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please choose an actual number..");
                }
            }
            Book bookToChange = mainLibrary.books[finalChoice];
            DateTime newTime = bookToChange.dueDate;
            Console.WriteLine("Current due date: " + bookToChange.dueDate.ToString());
            Console.WriteLine("How much do you wish to extend or reduce the due date? [in days]");
            while (true)
            {
                string extendBy = Console.ReadLine();
                try
                {
                    int extendInt = int.Parse(extendBy);
                    newTime = mainLibrary.books[finalChoice].dueDate.AddDays(extendInt);
                    mainLibrary.changeBookDueDate(bookToChange, newTime);
                    return;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please choose an actual number..");
                }
            }

            //Call the library method to change due date
            
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
