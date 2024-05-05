using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.OOPS
{
    class InterfaceVsAbstract
    {
        public InterfaceVsAbstract()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\n1. Interface has only abstract methods");
            stringBuilder.Append("\nAbstract class can contain both abstract as well as non abstract methods");

            stringBuilder.Append("\n\n2.Interace Methods cannot have access specifier they are by default public, no need to write");
            stringBuilder.Append("\nAbstract class Methods can have access specifiers public and private");

            stringBuilder.Append("\n\n3.For class implementing interface its compulsory to provide the definition");
            stringBuilder.Append("\nIf class deriving abstract is declared as abstract there is no need to provide definition for the abstract methods");

            stringBuilder.Append("\n\n4.Interfaces can contain properties,methods, events but An interface can't contain constants, static variables, fields, operators, instance constructors, destructors, or types");
            stringBuilder.Append("\nAbstract classess can contain all types of variables");

            stringBuilder.Append("\n\n5.Class can derive one to many interfaces, Multiple Inheritence");
            stringBuilder.Append("\nClass can derive from only one abstract class, Abstract class Multiple inheritence not allowed");

            stringBuilder.Append("\n\n6.Interface once used cannot be changed without dervied class implementing the new behavior and it " +
                                 "is not so good in case of forward compatibility");
            stringBuilder.Append("\n6.Abstract class should be used if forward compatibility is required" +
                                 "In future additional behaviour can be added without affecting existing functionality");

            Console.WriteLine(stringBuilder);
        }
    }

    interface IVehicle
    {
        int i{get;set;}

        



    }
}
