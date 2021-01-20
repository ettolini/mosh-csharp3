using System;
using System.Linq; // You need this to use LINQ extensions

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks();

            // LINQ Query Operators
            var cheapBooks2 =
                from b in books     // Defines b as books
                where b.Price < 10  // Filters books that are over $10
                orderby b.Title     // Orders the selection by title
                select b.Title;     // Converts the object elements to strings (book title)

            // LINQ Query Methods (is more powerful, since query uses keywords for methods, and not all of them have one)
            var cheapBooks = books
                                .Where(b => b.Price < 10)       
                                .OrderBy(books => books.Title)  
                                .Select(books => books.Title);  

            foreach (var cheapBook in cheapBooks)
                System.Console.WriteLine(cheapBook);

            // Some more examples of LINQ Extension Methods
            var book = books.SingleOrDefault( book => book.Title == "El Principito" ); // Unlike Where(), this gets only one object
            // There's a Single Method, but that throws an exception if it doesn't find anything

            System.Console.WriteLine(book == null); // Returns a book with that title, if not found returns null (default object value)

            var firstBook = books.First(); // Gets the first book object
            var lastBook = books.Last();   // They can also receive delegates as arguments

            var pagedBooks = books.Skip(2).Take(3); // It's gonna skip 2 books and store the following three

            var maxPrice = books.Max(b => b.Price); // Returns the max value specified (the price, in this case)
            var minPrice = books.Min(b => b.Price); // Returns the min value specified
            var sumPrice = books.Sum(b => b.Price); // Returns the sum of all elements (prices)
            var averagePrice = books.Average(b => b.Price); // Gets the average given value
        }
    }
}