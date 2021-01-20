using System;

// Use extension methods only when you really have to, because if C# gets an update that incorporates the method you extended, it wouldn't
// be useful anymore, since static methods (yours) will come second to instance methods (the officially added ones).
// You, most likely, will be using extension methods rather than creating them.

namespace  ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            string post = "This is supposed to be a very long blog post...";
            var shortenedPost = post.Shorten(5);

            System.Console.WriteLine(shortenedPost);
        }
    }

    public static class StringExtensions    // They must be static, since you're extending an already existing class
    {
        public static string Shorten(this string str, int numberOfWords) // "This" Keyword allows us to use it on an object instance
        {                                                                // even though it's a static method
            if (numberOfWords < 0)
                throw new ArgumentOutOfRangeException("numberOfWords should be greater than or equal to 0.");
            
            if (numberOfWords == 0)
                return "...";
            
            var words = str.Split(' ');

            if (words.Length <= numberOfWords)
                return str;
            
            return string.Join(' ', words.Take(numberOfWords)) + "...";
        }
    }
}