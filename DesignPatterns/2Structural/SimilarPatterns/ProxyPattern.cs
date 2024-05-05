using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{
    //http://www.dofactory.com/net/proxy-design-pattern

    //http://www.oodesign.com/proxy-pattern.html
    //Sometimes we need the ability to control the access to an object. For example if we need to use only a few methods of some costly 
    //objects we'll initialize those objects when we need them entirely. Until that point we can use some light objects exposing the 
    //same interface as the heavy objects. These light objects are called proxies and they will instantiate those heavy objects when they are really need and by then we'll use some light objects instead.
    //Consider for example an image viewer program.An image viewer program must be able to list and display high resolution photo 
    //objects that are in a folder, but how often do someone open a folder and view all the images inside. 
    //Sometimes you will be looking for a particular photo, sometimes you will only want to see an image name. The image viewer must be able to list all photo objects, but the photo objects must not be loaded into memory until they are required to be rendered.

    //https://sourcemaking.com/design_patterns/proxy
    //  Adapter provides a different interface to its subject.Proxy provides the same interface. 
    //Decorator provides an enhanced interface.
    //Decorator and Proxy have different purposes but similar structures.
    //Both describe how to provide a level of indirection to another object, 
    //and the implementations keep a reference to the object to which they forward requests.
    class ProxyPattern
    {
        public static void TestProxyPattern()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Proxy Pattern provides a surrogate or placeholder to another object and control access to it" +
                                 "light objects called proxies instantiate those heavy objects when they are really need and by then we'll use some light objects instead.");
            stringBuilder.Append("\n");
            stringBuilder.Append("Adapter provides a different interface to its subject.Proxy provides the same interface. Decorator provides an enhanced interface.");
            stringBuilder.Append("\n");
            stringBuilder.Append("Decorator and Proxy have different purposes but similar structures");
            stringBuilder.Append("\n");
            stringBuilder.Append("Both describe how to provide a level of indirection to another object");
            stringBuilder.Append("\n");
            stringBuilder.Append("and the implementations keep a reference to the object to which they forward requests");
            stringBuilder.Append("\n");
            Console.WriteLine(stringBuilder);
            Program.PressEnterToContinue();

            //Without using proxy
            Console.WriteLine("Wihtout using Proxy");
            IImage subject = new Image("abc.txt");
            subject.ShowImage();
            Program.PressEnterToContinue();

            //using proxy
            Console.WriteLine("Using Proxy");
            subject = new ImageProxy("abc.txt");
            subject.ShowImage();
        }
    }

    interface IImage
    {
        void ShowImage();
    }

    class Image : IImage
    {
        public Image(string filepath)
        {
            Console.WriteLine("\nDuring init heavy operation loadImage called");
            loadImage(filepath);
        }

        private void loadImage(string filepath)
        {
            Console.WriteLine("Load image from disk, Heavy operation");
        }

        public void ShowImage()
        {
            Console.WriteLine("Actual Render Image");
        }
    }

    class ImageProxy : IImage
    {
        private string _imagepath;
        public ImageProxy(string imagepath)
        {
            Console.WriteLine("\nProxy Avoided heavy operation during init , " +
                              "Just give file path");
            _imagepath = imagepath;
        }

        public void ShowImage()
        {
            Console.WriteLine("Proxy show Image, Now call heavy operation which was not done in init");
            Image img = new Image(_imagepath);
            img.ShowImage();

        }
    }
}
