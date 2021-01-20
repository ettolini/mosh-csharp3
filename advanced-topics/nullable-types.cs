using System;

namespace NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nullable<DateTime> date = null; -> is another way to type it
            DateTime? date = null;

            System.Console.WriteLine("GetValueOrDefault: " + date.GetValueOrDefault()); // Returns default DateTime value
            System.Console.WriteLine("HasValue: " + date.HasValue());                   // Retuns false
            System.Console.WriteLine("Value: " + date.Value());                         // Throws exception
       
            // DateTime date2 = date; -> won't compile, if date were to have a null value, date2 wouldn't be able to store it
            DateTime date2 = date.GetValueOrDefault();
            DateTime? date3 = date2; // No prob

            DateTime date4 = date ?? DateTime.Today; // If date has a value, store it in date4. Otherwise, store DateTime.Today
        }
    }
}