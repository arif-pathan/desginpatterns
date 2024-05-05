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
    class Aggregation
    {
        public Aggregation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\nAggregation represents single ownership but not parent child relationship, " +
                                 "Parent child relationship is, if parent is deleted child will be deleted");
            stringBuilder.Append("\nManager has subordinates under him, So Manager is kind of owner of subordinates");
            stringBuilder.Append("\nBut if Manager is deleted, worker will still remain");
            stringBuilder.Append("\nProject Example Person and Relative, Relative belongs to person, But even if person is not there, Relative is independent and will exist");
            Console.WriteLine(stringBuilder);
        }
    }

    abstract class Employee3
    {
        public string name;
        public string adress;

        public abstract void getDepartment();
    }

    class Manager3 : Employee3 //Inheritence Manager is a type of Employee
    {
        public override void getDepartment()
        {
            throw new NotImplementedException();
        }
    }

    class Worker3 : Employee3 //Inheritence Worker is a type of Employee
    {
        public override void getDepartment()
        {
            throw new NotImplementedException();
        }
    }

    //Aggregation Manager owns Worker, But still both objects Manager and Worker have their own life cycle,
    //Even if Manager is deleted Employee remains as it is
    class Manager13 : Employee3
    {
        List<Worker3> workers = new List<Worker3>();

        void AddWorker(Employee3 emp)
        {
            workers.Add((Worker3)emp);
        }
        public override void getDepartment()
        {
            throw new NotImplementedException();
        }
    }
}
