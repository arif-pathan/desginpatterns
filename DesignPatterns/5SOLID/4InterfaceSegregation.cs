using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID
{
    ////https://code.msdn.microsoft.com/windowsapps/OOPS-Principles-SOLID-7a4e69bf
    class _4InterfaceSegregation
    {
        void InterfaceSeggregation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\n\nInterface Seggregation Principle");
            stringBuilder.Append("\nClasses should not be forced to depend on interfaces that they do not use");

            //****************************//
            stringBuilder.Append("\nProject Example : Earlier there were common contracts that both projects caseworker and provider portal were using"+
                "Whenever we introduced some new methods in interface they use to get affected, and they did not even required those methods"+
                "So we seperated out the interfaces");

            //****************************//

            Console.WriteLine(stringBuilder);
        }
    }


    interface IDataProvider
    {
        void OpenConnection();
        void CloseConnection();
    }

    interface ISqlDataProvider : IDataProvider
    {
        void ExecuteSqlQuery();
    }

    interface IOracleDataProvider : IDataProvider
    {
        void ExecuteOracleQuery();
    }


    class SqlClient : ISqlDataProvider
    {
        SqlClient()
        {
            Console.WriteLine("\nSqlClient does not require oracle query so its not forced to implement sqlquery method, " +
                                "By seggregating the interfaces");
        }
        public void ExecuteSqlQuery()
        {
            throw new NotImplementedException();
        }

        public void OpenConnection()
        {
            throw new NotImplementedException();
        }

        public void CloseConnection()
        {
            throw new NotImplementedException();
        }

        class OracleClient : IOracleDataProvider
        {
            OracleClient()
            {
                Console.WriteLine("\nOracleClient does not require sql query so its not forced to implement sqlquery method, " +
                                  "By seggregating the interfaces");
            }
            public void OpenConnection()
            {
                throw new NotImplementedException();
            }

            public void CloseConnection()
            {
                throw new NotImplementedException();
            }

            public void ExecuteOracleQuery()
            {
                throw new NotImplementedException();
            }
        }
    }

}
