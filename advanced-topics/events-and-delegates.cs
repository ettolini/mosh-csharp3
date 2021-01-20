using System;
using System.Threading;

namespace EventsAndDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var video = new Video() { Title = "Video 1" };
            var videoEncoder = new VideoEncoder();      // publisher
            var mailService = new MailService();        // subscriber
            var messageService = new MessageService();  // subscriber

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded; // I'm saving the REFERENCE to that method
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

            videoEncoder.Encode(video);
        }
    }

    public class Video
    {
        public string Title { get; set; }
    }

    public class VideoEncoder
    {
        public delegate void VideoEncodedEventHandler(object source, EventArgs args);
        // The first argument is the object from where the event comes from, and EventArgs represents all the extra data we may need to send
        // The delegate's name is such because we take the event's name (VideoEncoded) and add EventHandler to it

        public event VideoEncodedEventHandler VideoEncoded; // We defined its handler and then its name

        public void Encode(Video video)
        {
            System.Console.WriteLine("Encoding video...");
            Thread.Sleep(3000); // Delays for the specified amount of time (3 seconds)
        
            OnVideoEncoded();
        }

        protected virtual void OnVideoEncoded() // Event publisher method
        {                                       // They should be protected, virtual, void. Their name should be "On" and the event's name
            if (VideoEncoded != null)
                VideoEncoded(this, EventArgs.Empty); // If you don't need to add anything, you can use EventArgs.Empty
        }
    }

    public class MailService
    {
        public void OnVideoEncoded(object source, EventArgs e)
        {
            System.Console.WriteLine("MailService: Sending an email...");
        }
    }

    public class MessageService
    {
        public void OnVideoEncoded(object source, EventArgs args)
        {
            System.Console.WriteLine("MessageService: Sending a text message...");
        }
    }
}