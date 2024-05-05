using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    //https://code.msdn.microsoft.com/windowsapps/OOPS-Principles-SOLID-7a4e69bf
    class Solid_Principles
    {
        Solid_Principles()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\nSOLID");
            stringBuilder.Append("\n\nSingle Responsibility Principle");
            stringBuilder.Append("\nOpen Close");
            stringBuilder.Append("\nLiskov Substitution");
            stringBuilder.Append("\nInterface Seggregation");
            stringBuilder.Append("\nDependency Inversion");
            Console.WriteLine(stringBuilder);
        }


        void SingleResponsibility()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\n\nSingle Responsibility Principle");
            stringBuilder.Append("\nExample There should be single responsibilty for the class like DataAccess or Logging not both");
            stringBuilder.Append("\nProject Example : While creating application if patient is not there we also create patient" +
               "In this case Patient and Application class should be different single responsibility");
            Console.WriteLine(stringBuilder);

        }

        void OpenClose()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\n\nOpen Close Principle");
            stringBuilder.Append("\nClasses functions modules should be open for extension but close for modification");
            stringBuilder.Append("\nExample DataProvider abstract method Open close connection, derived class SQLDataProvider inherits and extens base class"+
                "But does not modify base class functionality");
            stringBuilder.Append("\nProject Example : DataProvider" +
               "SQL and oracle, They exten the base functionality so open for extension but base functions are abstract so close for modification ");
            Console.WriteLine(stringBuilder);

        }

        void LiskovSubstitution()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\n\nLiskov Substitution Principle");
            stringBuilder.Append("\nAs per Liskov Substitution Principle Derived types must be completely substitutable for their base types") ;
            stringBuilder.Append("\nClasses that derive from base class should only extend and not impact existing functionality of base class");
            stringBuilder.Append("\nIf any module is using the base class then it can be replaced by dervied class without impacting the module functionality");
            stringBuilder.Append("\nExample  :Rectangle derives from square, but get area of rectangle gives different result as width!=height in most cases");
            stringBuilder.Append("\nExample  :Use Quadraple class that rectangle and square derives from");
            Console.WriteLine(stringBuilder);

        }

        void InterfaceSeggregation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\n\nInterface Seggregation Principle");
            stringBuilder.Append("\nClasses should not be forced to depend on interfaces that they do not use");
            stringBuilder.Append("\nExample DataProvider should have base methods OpenClose Connection and not ExecuteSqlQuery and ExecuteOracle"+
                "They should be in seprate interface IsqlDataProvider and IOracleDP that derives from DataProvider");
            stringBuilder.Append("\nProject Example : Earlier there were common interfaces like client application that both projects caseworker and provider portal were using" +
              "Whenever we introduced some new methods in interface they use to get affected, and they did not even required those methods" +
              "So we seperated out the interfaces");

            Console.WriteLine(stringBuilder);
        }

        void DependencyInversion()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\n\nDependency Inversion Principle");
            stringBuilder.Append("\nDependency injection (DI) is a technique for achieving loose coupling between objects and their collaborators, or dependencies. "+
                "ServiceLocator pattern another way - remove depdenencies in other way but purpose is similar to dependency injection that is remove dependencies");
            stringBuilder.Append("\nThis follows the Dependency Inversion Principle, which states that" +
        "high level modules should not depend on low level modules; both should depend on abstractions.");
            Console.WriteLine(stringBuilder);
        }


    }



}
