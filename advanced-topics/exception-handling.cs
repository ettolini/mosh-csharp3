using System;
using System.IO;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using specific exceptions, from more specific to less specific

            try
            {
                var calculator = new Calculator();
                var result = calculator.Divide(5, 0); // 5 divided by 0
            }
            catch (DivideByZeroException ex)
            {
                System.Console.WriteLine("You cannot divide by 0.");
            }
            catch (ArithmeticException ex)
            {
                System.Console.WriteLine("You've commited an arithmetic error.");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("An unexpected error occurred.");
            }

            // Making sure you dispose a stream (1) -> The Finally Keyword, it always executes after every other instruction

            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader("c:\\file.jpg");
                var content = streamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Sorry, an error occurred.");
            }
            finally
            {
                if (streamReader != null)
                    streamReader.Dispose(); // Always make sure to close a stream when you're done using it
            }

            // Making sure you dispose a stream (2) -> The Using Keyword, it uses a stream and disposes it automatically (this is better)

            try
            {
                using (StreamReader streamReader2 = new StreamReader("c:\\file.zip"))
                {
                    var content = streamReader2.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Sorry, an error occurred.");
            }
        }
    }
}