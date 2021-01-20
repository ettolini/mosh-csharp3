using System;

namespace DelegatesBro
{
    public class Photo
    {
        public static Photo Load(string path)
        {
            return new Photo();
        }

        public void Save()
        {
            
        }
    }

    public class PhotoFilters
    {
        public void ApplyBrightness(Photo photo)
        {
            System.Console.WriteLine("Apply brightness");
        }

        public void ApplyContrast(Photo photo)
        {
            System.Console.WriteLine("Apply contrast");
        }

        public void Resize(Photo photo)
        {
            System.Console.WriteLine("Resize photo");
        }
    }

    public class PhotoProcessor
    {
        public delegate void PhotoFiltersHandler(Photo photo);  // This delegate can handle any function/method with the same signature

        public void Process(string path, PhotoFiltersHandler filterHandler)
        {
            var photo = Photo.Load(path);

            filterHandler(photo); // Executing PhotoFilterHandler delegate

            photo.Save();
        }
    }

    class Program
    {
        static void Main(string []args)
        {
            PhotoProcessor processor = new PhotoProcessor();
            PhotoFilters filters = new PhotoFilters();
            PhotoProcessor.PhotoFiltersHandler filterHandler = filters.ApplyBrightness; // We create a new delegate instance
                                                                                        // and assign it the ApplyBrightness Method
            filterHandler += filters.ApplyContrast; // Since ApplyContrast and RemoveRedEye share signature as well, we can assign them too
            filterHandler += RemoveRedEyeFilter;

            processor.Process("photo.jpg", filterHandler);  // When calling the delegate instance, it'll apply every method assigned to it
        }

        static void RemoveRedEyeFilter(Photo photo)
        {
            System.Console.WriteLine("Apply RemoveRedEye");
        }
    }
}

// Before, we used a custom delegate, but we can also use generic delegates that come within the .NET Framework:
// System.Action<> -> points to a method that returns void.
// System.Func<> -> points to a method that returns a value.
// We're using Generic Action Delegate in the following example...

    // public class PhotoProcessor // This is another way to implement it
    // {
    //     public void Process(string path, Action<Photo> filterHandler) // "You can pass any delegate that takes a photo as an argument
    //     {                                                             // and returns void".
    //         var photo = Photo.Load(path);

    //         filterHandler(photo);

    //         photo.Save();
    //     }
    // }

// We would access it in the Main Program like this...

        // Action<Photo> filterHandler = filters.ApplyBrightness;

// Interfaces of Delegates? Use a delegate when...
// An eventing design pattern is used, or the caller doesn't need to access other properties or methods on the object implementing the method.