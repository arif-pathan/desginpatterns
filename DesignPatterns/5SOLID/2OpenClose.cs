using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID
{
    ////https://code.msdn.microsoft.com/windowsapps/OOPS-Principles-SOLID-7a4e69bf
    class _2OpenClose
    {
        void OpenClose()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\n\nOpen Close Principle");
            stringBuilder.Append("\nClasses functions modules should be open for extension but close for modification");
            stringBuilder.Append("\nBelow example DataProvider is open for extension but closed for modification, "+
                "SqlDataProvider extends it but does not modify base");

            //****************************//
            stringBuilder.Append("\nProject Example : DataProvider" +
                "SQL and oracle, They exten the base functionality so open for extension but base functions are abstract so close for modification ");
            Console.WriteLine(stringBuilder);
            //****************************//
        }

        abstract class DataProvider
        {
           public abstract void OpenConnection();
           public abstract void CloseConnection();
           public abstract void ExecuteCommand();

        }

        class SqlDataProvider:DataProvider
        {
            public override void OpenConnection()
            {
                throw new NotImplementedException();
            }

            public override void CloseConnection()
            {
                throw new NotImplementedException();
            }

            public override void ExecuteCommand()
            {
                throw new NotImplementedException();
            }
        }

        class OracleDataProvider : DataProvider
        {
            public override void OpenConnection()
            {
                throw new NotImplementedException();
            }

            public override void CloseConnection()
            {
                throw new NotImplementedException();
            }

            public override void ExecuteCommand()
            {
                throw new NotImplementedException();
            }
        }
    }
}
