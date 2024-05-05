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
    class AllInOne_AssInhAggComp
    {
       public AllInOne_AssInhAggComp()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\n\nAssociation represents relationship between objects");
            stringBuilder.Append("\nManager uses swipe card");
            stringBuilder.Append("\nBoth but Manager and swipe card objects have their idependent life cycle there is no ownership");

            stringBuilder.Append("\nInheritence represents is a relationship");
            stringBuilder.Append("\nManager is a type of Employee, Worker is a type of Employee");

            stringBuilder.Append("\nAggregation represents single ownership but not parent child or death relationship");
            stringBuilder.Append("\nManager has subordinates under him, So Manager is kind of owner of subordinates");
            stringBuilder.Append("\nBut if Manager is deleted, worker will still remain");

            stringBuilder.Append("\nComposition is a death type relationship, special type of aggregation with parent child relationship");
            stringBuilder.Append("\nParent is owner of child, Child cannot exist without parent,"
                + "If parent is deleted child object does not have existance");

            //****************************//

            stringBuilder.Append("\nAssocation-Project Example Relationship"
            + "Client and Relatives");


            stringBuilder.Append("\nAggregation-Project Example Ownership"
            + "CaseWorker and Clients ");

            stringBuilder.Append("\nComposition-Project Example Parent Child relationship"
                +"Building and Apartment ");

            //****************************//
            Console.WriteLine(stringBuilder);
        }
    }

    abstract class Employee
    {
        public string name;
        public string adress;

        public abstract void getDepartment();
    }

    class Manager : Employee //Inheritence Manager is a type of Employee
    {
        public override void getDepartment()
        {
            throw new NotImplementedException();
        }
    }

    class Worker : Employee //Inheritence Worker is a type of Employee
    {
        public override void getDepartment()
        {
            throw new NotImplementedException();
        }
    }

    class SwipeCard //Assocation : Employee or Manager uses SwipeCard to swipe in, But both swipecard and Manager have their own lifecycle, No one has ownership of other
    {
        void Swipe(Employee emp)
        {
            Console.WriteLine("Employee swiped in" + emp.name);
        }

    }

    class Manager2 : Employee //Aggregation Manager owns Worker, But still both objects Manager and Worker have their own life cycle,
                              //Even if Manager is deleted Employee remains as it is
    {
        List<Worker> workers = new List<Worker>();

        void AddWorker(Employee emp)
        {
            workers.Add((Worker)emp);
        }
        public override void getDepartment()
        {
            throw new NotImplementedException();
        }
    }

    class Project //Composition : Project is dependent on Manager, Manager is manager while he has some project, 
                  //Without project Manager is not a Manager he is an ordinary employee
                  //Similarly House and Room, If House is deleted Rooms cannot exist themselves, they need to be deleted
    {
        Manager2 manager;
        void SetManager(Manager2 mgr)
        {
            manager = mgr;
            Console.WriteLine("Setting manager of project" + mgr.name);
        }

    }
}
