using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{
    class FacadePattern
    {
        //Provide a unified interface to a set of interfaces in a subsystem. 
        //Façade defines a higher-level interface that makes the subsystem easier to use.

        //Refactoring
        //Just extract complex methods into more simple small apis to be used by client
        private SubSystemOne one = null;
        private SubSystemTwo two = null;
        private SubSystemThree three = null;


        public FacadePattern()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Facade Pattern is Provide a unified interface to a set of interfaces in a subsystem");
            stringBuilder.Append("\n");
            stringBuilder.Append("Façade defines a higher-level interface that makes the subsystem easier to use");
            stringBuilder.Append("\n");
            Console.WriteLine(stringBuilder);
            Program.PressEnterToContinue();

            one = new SubSystemOne();
            two=new SubSystemTwo();
            three=new SubSystemThree();
            
        }
        public void DoSystemOperationOne()
        {
            Console.WriteLine("System Method One Different set of subsystem operations");
            one.DoOperationOne();
            two.DoOperationTwo();
            Program.PressEnterToContinue();
        }

        public void DoSystemOperationTwo()
        {
            Console.WriteLine("System Method Two Different set of subsystem operations");
            three.DoOperationThree();
            two.DoOperationTwo();
            Program.PressEnterToContinue();
        }

    }


    public class SubSystemOne
    {
        public void DoOperationOne()
        {
            Console.WriteLine("Do Operation1");
        }
    }

    public class SubSystemTwo
    {
        public void DoOperationTwo()
        {
            Console.WriteLine("Do Operation2");
        }
    }

    public class SubSystemThree
    {
        public void DoOperationThree()
        {
            Console.WriteLine("Do Operation3");
        }
    }
}
