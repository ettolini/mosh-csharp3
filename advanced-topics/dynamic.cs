

namespace Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
                dynamic name = "Mosh";  // The Dynamic Keyword allows the variable to have dynamic features
                name = 10;  // Does compile, notice we never defined name as a string

                dynamic a = 10;
                dynamic b = 5;
                var c = a + b;  // Since a and b are dynamic, var identifies c as dynamic as well.
                // If we specify a value for c, we won't be allowed by the compiler to use it as dynamic.
                string d = a + b; // We'd get an exception, because a + b returns an int
        }
    }
}