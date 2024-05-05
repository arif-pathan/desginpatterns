using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.OOPS
{
    //http://stackoverflow.com/questions/731802/what-is-the-difference-between-composition-and-association-relationship
    //https://www.codeproject.com/Articles/330447/Understanding-Association-Aggregation-and-Composit
    //http://www.dotnettricks.com/learn/oops/understanding-association-aggregation-composition-and-dependency-relationship

    //Favor Compostion over Inheritence
    //http://stackoverflow.com/questions/3441090/what-is-composition-as-it-relates-to-object-oriented-design
    class CompositionAndEncapsulation
    {
        public CompositionAndEncapsulation()
        {
            StringBuilder stringBuilder = new StringBuilder();
           
            stringBuilder.Append("\nComposition is a death type relationship, special type of aggregation with parent child relationship");
            stringBuilder.Append("\nComposition is with objects whereas Encapsulation is composing one class with those objects and hiding functionality");
            stringBuilder.Append("\nParent is owner of child, Child cannot exist without parent,"
                + "If parent is deleted child object does not have existance");
            stringBuilder.Append("\nProject Eample Building and Apartment, Building is owner of Apartment, Without Building there is no Apartment independently");
            Console.WriteLine(stringBuilder);
        }
    }

    abstract class Employee4
    {
        public string name;
        public string adress;

        public abstract void getDepartment();
    }

    class Manager4 : Employee //Inheritence Manager is a type of Employee
    {
        public override void getDepartment()
        {
            throw new NotImplementedException();
        }
    }

    class Worker4 : Employee4 //Inheritence Worker is a type of Employee
    {
        public override void getDepartment()
        {
            throw new NotImplementedException();
        }
    }

    //Composition : Project is dependent on Manager, Manager is manager while he has some project, 
    //Without project Manager is not a Manager he is an ordinary employee
    //Similarly Building and apartment, If Building is deleted Apartment cannot exist themselves, they need to be deleted
    class Project4
    {
        Manager4 manager;
        void SetManager(Manager4 mgr)
        {
            manager = mgr;
            Console.WriteLine("Setting manager of project" + mgr.name);
        }

    }
}
