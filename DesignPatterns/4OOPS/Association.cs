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
    class Association
    {
       public Association()
            {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\n\nAssociation represents relationship between objects");
            stringBuilder.Append("\nManager uses swipe card");
            stringBuilder.Append("\nbut Manager and swipe card objects have their idependent life cycle there is no ownership");
            Console.WriteLine(stringBuilder);
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
        
        //Assocation : Employee or Manager uses SwipeCard to swipe in, But both swipecard and Manager have their own lifecycle, No one has ownership of other
        class SwipeCard 
        {
            void Swipe(Employee emp)
            {
                Console.WriteLine("Employee swiped in" + emp.name);
            }

        }
            
    }
}
