using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{
    public class BridgePattern
    {
      
        public BridgePattern()
        {
            //****************************//
            //"Decouple an abstraction from its implementation so that the two can vary independently."
            //****************************//

              //var shape = new Square(new BlueColor());
              //shape.ApplyColor();
              //shape = new Square(new RedColor());
              //shape.ApplyColor();

              Movie movie1 = new Movie(title:"hero",director:"rajnandani");
           
            Printer printer = new MoviePrinter(movie1);
            Formatter formatter = new HtmlFormatter();
            printer.print(formatter);

            formatter = new ConsoleFormatter();
            printer.print(formatter);

          
        }

    }

    class Movie
    {
        private string _title;
        private string _director;

        public Movie(string title, string director)
        {
            Title = title;
            Director = director;
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Director
        {
            get { return _director; }
            set { _director = value; }
        }
    }

    class Details
    {
        private string _label;
        private string _value;

        public Details(string label, string value)
        {
            Label = label;
            Value = value;
        }

        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }

    abstract class Printer
    {
        public void print(Formatter formatter)
        {
         Console.WriteLine(formatter.Format(getHeader(), getDetails()));
             
        }

        public abstract List<Details> getDetails();
        public abstract string getHeader();
    }

    abstract class Formatter
    {
        public abstract  string Format(string header, List<Details> details);
    }

    class MoviePrinter : Printer
    {
        private Movie _movie;

        public MoviePrinter(Movie movie)
        {
            _movie = movie;
        }

        public override List<Details> getDetails()
        {
            List<Details> details = new List<Details>();
            details.Add(new Details("Title",_movie.Title));
            details.Add(new Details("Director",_movie.Director));
            return details;
        }

        public override string getHeader()
        {
            return _movie.Title;
        }
    }

    class ConsoleFormatter : Formatter
    {
        public override string Format(string header, List<Details> details)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Console header " + header);

            foreach (var detail in details)
            {
                stringBuilder.Append("\nLabel " + detail.Label);
                stringBuilder.Append("\nValue " + detail.Value);
            }

            return stringBuilder.ToString();
        }
    }

    class HtmlFormatter : Formatter
    {
        public override string Format(string header, List<Details> details)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("HTML header " + header);

            foreach (var detail in details)
            {
                stringBuilder.Append("\br Label " + detail.Label);
                stringBuilder.Append("\br Value " + detail.Value);
            }

            return stringBuilder.ToString();
        }
    }


    abstract class Shape
    {
        internal Color _color;
        public Shape(Color color)
        {
            _color = color;
        }

        public abstract void ApplyColor();
    }

    abstract class Color
    {
        public abstract void Applycolor();
    }

    class BlueColor : Color
    {

        public override void Applycolor()
        {
            Console.WriteLine("blueColor");
        }
    }

    class RedColor : Color
    {

        public override void Applycolor()
        {
            Console.WriteLine("redColor");
        }
    }

    class Square : Shape
    {
        private Color _color;

        public Square(Color color)
            : base(color)
        {
            
        }

        public override void ApplyColor()
        {
            _color.Applycolor();
        }
    }
}
