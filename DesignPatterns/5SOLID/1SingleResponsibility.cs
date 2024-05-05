using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID
{
    ////https://code.msdn.microsoft.com/windowsapps/OOPS-Principles-SOLID-7a4e69bf
    class _1SingleResponsibility
    {
        void SingleResponsibility()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\n\nSingle Responsibility Principle");
            stringBuilder.Append("\nThere should be single responsibilty for the class like DataAccess or Logging not both");

            //****************************//
            stringBuilder.Append("\nProject Example : While creating application if person is not there we also create person"+
                "In this case Person and Application class should be different single responsibility");
            Console.WriteLine(stringBuilder);
            //****************************//
        }


    }

    class DataAccess
    {
        DataAccess()
        {
            Console.WriteLine("Single Responsibility of DataAccess");
        }
    }

    class Logger
    {
        Logger()
        {
            Console.WriteLine("Single Responsibility of Logging");
        }
    }
}
