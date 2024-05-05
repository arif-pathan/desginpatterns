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
    class Inheritence
    {
        public Inheritence()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\nInheritence represents is a relationship");
            stringBuilder.Append("\nManager is a type of Employee, Worker is a type of Employee");

           Console.WriteLine(stringBuilder);
        }
    }


    abstract class Employee1
    {
        public string name;
        public string adress;

        public abstract void getDepartment();
    }

    class Manage1 : Employee1 //Inheritence Manager is a type of Employee
    {
        public override void getDepartment()
        {
            throw new NotImplementedException();
        }
    }

    class Worker1 : Employee1 //Inheritence Worker is a type of Employee
    {
        public override void getDepartment()
        {
            throw new NotImplementedException();
        }
    }
}
