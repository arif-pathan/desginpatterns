using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational
{
    //https://www.codeproject.com/Articles/430590/Design-Patterns-of-Creational-Design-Patterns#FactoryMethodStructural

    //The factory method pattern is a design pattern that allows for the creation of objects without
    //specifying the type of object that is to be created in code

    //    Make module to expose various courses
    //course
    //java
    //dot net

    //Client
    //switch
    //java
    //dot net

    ////open close principle violated

    //dedicated class
    //switch
    //java
    //dot net

    //add corporate courses

    ////single responsibility principle voilated
    //    Add more course change and adding switch


    //Interface factory
    //Different implementations not standardised how to create object
    //onlinefactory
    //corporate factory


    //To standardise object creation
    //Composition is used
    //Interface or abstract class factory
    //Composition class pass the type to create
    //create
    //Contains abstract method to get the course

    class FactoryPattern
    {
        public FactoryPattern()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("The factory method pattern is a design pattern that allows for the creation of objects without");
            stringBuilder.Append("\n");
            stringBuilder.Append("specifying the type of object that is to be created in code");
            stringBuilder.Append("\nIt defers instantiation of classes to subclasses");

            stringBuilder.Append("\nswitch or reflection, client just passes the type to create, client is not aware of concrete implementation");


            stringBuilder.Append("swtich directly in client, then to add one more switch we need to change client code open close principle violated");
            stringBuilder.Append("\n");
            stringBuilder.Append("So move code to different class but still " +
                                 "Add different type of course online and corporate then single responsibility principle voilated");
            stringBuilder.Append("\n");
            stringBuilder.Append("\nInterface factory " +
                                 "\nBut still Different implementations not standardised how to create object " +
                                 "\nonlinefactory " +
                                 "\ncorporate factory" +
                                 "\nTo avoid this use composition");
            stringBuilder.Append("\n");


          


            stringBuilder.Append("\n ");

            stringBuilder.Append("\n");


            stringBuilder.Append("\n");
            Console.WriteLine(stringBuilder);
            
            AbstractCourse course = null;
            Console.WriteLine("\nEnter dotnet or java");
            string input = Console.ReadLine();

            course = CreateCourse(input);
            Console.WriteLine(course?.GetSchedule());
        }

        public AbstractCourse CreateCourse(string input)
        {
           AbstractCourse course = null;
            switch (input)
            {
                case "java":
                    course=new JavaAbstractCourse();
                    break;
                case "dotnet":
                    course=new DotNetAbstractCourse();
                    break;
                default:
                    Console.WriteLine("Wrong choice");
                    break;
            }
            return course;
        }

        public static void TestFactoryPatternFactoryClassWithComposition()
        {
            Console.WriteLine("Factory Client Code, Enter dotnet or java");
            AbstractCourse course = null;
            string input = Console.ReadLine();

            Console.WriteLine("CorporateFactory");
            AbstractCourseFactory pattern = new CorporateFactory();
            course = pattern.CreateCourse(input);

            Console.WriteLine("Press Enter for OnlineFactory");
            Console.ReadLine();

            Console.WriteLine("\nOnlineFactory");
            pattern = new OnlineFactory();
            course = pattern.CreateCourse(input);

        }
    }

    abstract class AbstractCourse
    {
        public abstract string GetSchedule();

    }

    class JavaAbstractCourse : AbstractCourse
    {
        public override string GetSchedule()
        {
            return "Returning Java Course";
        }
    }

    class DotNetAbstractCourse : AbstractCourse
    {
        public override string GetSchedule()
        {
            return "Returning DotNet Course";
        }
    }



    //How Gang of Four defined Factory Method Pattern “This pattern defines an interface for creating an object,
    //    but let subclasses decide which class to instantiate.
    //    Factory Method lets a class defer instantiation to subclasses"

    abstract class AbstractCourseFactory
    {
        public AbstractCourse CreateCourse(string input)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\nTo standardise object use Composition one more Interface or abstract class factory " +
                                 "\nComposition class pass the type to create " +
                                 "\nContains abstract method to get the course");
            stringBuilder.Append("\n");
            Console.WriteLine(stringBuilder);

            AbstractCourse f = GetCourse(input);
            Console.WriteLine(f.GetSchedule()); 
            return f;
        }
        public abstract AbstractCourse GetCourse(string input);

    }


    class CorporateFactory : AbstractCourseFactory
    {
        private AbstractCourse course = null;
        public override AbstractCourse GetCourse(string input)
        {
            switch (input)
            {
                case "java": course=new JavaAbstractCourse();
                    Console.WriteLine("Corportate Java");
                    break;
                case "dotnet": course=new DotNetAbstractCourse();
                    Console.WriteLine("Corportate DotNet");
                    break;
                default: Console.WriteLine("Wrong choice");
                    break;

            }
            return course;

        }
    }

    class OnlineFactory : AbstractCourseFactory
    {
        private AbstractCourse course = null;
        public override AbstractCourse GetCourse(string input)
        {
            switch (input)
            {
                case "java":
                    course = new JavaAbstractCourse();
                    Console.WriteLine("OnlineFactory Java");
                    break;
                case "dotnet":
                    course = new DotNetAbstractCourse();
                    Console.WriteLine("OnlineFactory DotNet");
                    break;
                default:
                    Console.WriteLine("Wrong choice");
                    break;

            }
            return course;

        }
    }
}
