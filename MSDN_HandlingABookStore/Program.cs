using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public struct Book
    {
        public string Title; //Title of the book.
        public string Author; //Author of the book.
        public decimal Price; // Price of the book.
        public bool Paperback; // Is it paperback?

        public Book(string title, string author, decimal price, bool paperback)
        {
            Title = title;
            Author = author;
            Price = price;
            Paperback = paperback;
        }
    }

    //Declare a delegate type for processing a book:
    public delegate void ProcessBookDelegate(Book book);

    //Maintains a book database:
    public class BookDB
    {
        ArrayList list = new ArrayList();

        //Add a book to the database:
        public void AddBook (string title, string author, decimal price, bool paperback)
        {
            list.Add(new Book(title,author,price,paperback));
        }

        //Call a passed-in delegate on each paperback book to process it:
        public void ProcessPaperbackBooks(ProcessBookDelegate processBook)
        {
            foreach(Book b in list)
            {
                if (b.Paperback)
                    //Calling the delegate
                    processBook(b);
            }
        }

    }
}

namespace BookTestClient
{
    using BookStore;

    //Class to total and average prices of books:
    class PriceTotaller
    {
        int countBooks = 0;
        decimal priceBooks = 0.0m;
        
        internal void AddBookToTotal(Book book)
        {
            countBooks += 1;
            priceBooks += book.Price;
        }

        internal decimal AveragePrice()
        {
            return priceBooks / countBooks;
        }
    }

    //Class to test the book database:
    class TestBookDB
    {
        //Print the title of the book.
        static void PrintTitle(Book book)
        {
            Console.WriteLine("   {0}", book.Title);
        }

        // Initialize the book database with some test books:
        static void AddBooks(BookDB bookDB)
        {
            bookDB.AddBook("The C Programming Language", "Brian W. Kernighan and Dennis M. Ritchie", 19.95m, true);
            bookDB.AddBook("The Unicode Standard 2.0", "The Unicode Consortium", 39.95m, true);
            bookDB.AddBook("The MS-DOS Encyclopedia", "Ray Duncan", 129.95m, false);
            bookDB.AddBook("Dogbert's Clues for the Clueless", "Scott Adams", 12.00m, true);
        }

        static void Main(string[] args)
        {
            BookDB bookDB = new BookDB();

            //Initialize the database with some books:
            AddBooks(bookDB);

            // Print all the titles of paperbacks:
            System.Console.WriteLine("Paperback Book Titles:");

            //Create a new delegate object associated with the static
            // method Test.PrintTitle:
            bookDB.ProcessPaperbackBooks(PrintTitle);

            // Get the average price of a paperback by using
            // a PriceTotaller object:
            PriceTotaller totaller = new PriceTotaller();

            // Create a new delegate object associated with the nonstatic 
            // method AddBookToTotal on the object totaller:
            bookDB.ProcessPaperbackBooks(totaller.AddBookToTotal);

            System.Console.WriteLine("Average Paperback Book Price: ${0:#.##}",
                    totaller.AveragePrice());

            Console.ReadLine();
        }
    }
}

/*
Robust Programming

Declaring a delegate. The following statement declares a new delegate type.
    public delegate void ProcessBookDelegate(Book book);
Each delegate type describes the number and types of the arguments, and the type of
the return value of methods that it can encapsulate. Whenever a new set of argument types
or return value type is needed, a new delegate type must be declared.

Instantiating a delegate.
After a delegate type has been declared, a delegate object must be created and associated
with a particular method. In the previous example, you do this by passing the PrintTitle
method to the ProcessPaperbackBooks method as in the following example:
    bookDB.ProcessPaperbackBooks(PrintTitle);
This creates a new delegate object associated with the static method Test.PrintTitle.
Similarly, the non-static method AddBookToTotal on the object totaller is passed as in
the following example:
    bookDB.ProcessPaperbackBooks(totaller.AddBookToTotal);

In both cases a new delegate object is passed to the ProcessPaperbackBooks method.
After a delegate is created, the method it is associated with never changes; delegate 
objects are immutable.

Calling a delegate.
After a delegate object is created, the delegate object is typically passed to other code
that will call the delegate. A delegate object is called by using the name of the delegate
object, followed by the parenthesized arguments to be passed to the delegate.
Following is an example of a delegate call:
    processBook(b);

A delegate can be either called synchronously, as in this example, or asynchronously by 
using BeginInvoke and EndInvoke methods.
*/
