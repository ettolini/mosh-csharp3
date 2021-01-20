using System;
using System.Collections.Generic;

namespace YoutubeHandling
{
    public class YouTubeException : Exception // This way we're creating our own, custom exception
    {
        public YouTubeException(string message, Exception innerException)
            : base(message, innerException)
            {
            }
    }

    public class YouTubeApi
    {
        public List<string> GetVideos(string user)
        {
            try
            {
                throw new Exception("Something happened!");
            }
            catch (Exception ex)
            {
                throw new YouTubeException("Could not fetch the videos from YouTube.", ex);
                // You wrap the exception in the ex variable so you can check at it later and visualize what went wrong
            }

            // return new List<string>(); -> this is what would happen if I hadn't forced the exception
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var api = new YouTubeApi();
                var videos = api.GetVideos("Kaxel");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message); // "Could not fetch the videos from YouTube."
            }
        }
    }
}