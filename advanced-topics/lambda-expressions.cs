using System;

namespace LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // We use a Func Delegate to access the expression (not mandatory), <entering value type, returning value type>
            // arguments => expression (number => number*number)
            Func<int, int> square = number => number*number;
            System.Console.WriteLine(square(5));    // Returns 25

            // Lambda Expressions can access its arguments, and variables defined inside the methods where the expression itself is defined
            const int factor = 5;
            Func<int, int> multiplier = n => n*factor;
            System.Console.WriteLine(multiplier(10));   // Returns 50
        }
    }
}

// If you don't need arguments...       ()           =>  ...
// If you need one argument...          x            =>  ...
// If you need multiple arguments...    (x, y, z)    =>  ...