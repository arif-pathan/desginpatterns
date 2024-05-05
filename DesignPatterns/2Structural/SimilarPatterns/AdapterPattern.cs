using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{
    //https://sourcemaking.com/design_patterns/proxy
    //  Adapter provides a different interface to its subject.Proxy provides the same interface. 
    //Decorator provides an enhanced interface.
    //Decorator and Proxy have different purposes but similar structures.
    //Both describe how to provide a level of indirection to another object, 
    //and the implementations keep a reference to the object to which they forward requests.
    public class AdapterPattern
    {

        public AdapterPattern()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Adapter Structural Pattern is used to glue between legacy code and new code");
            stringBuilder.Append("\n");
            stringBuilder.Append("No new functionality should be there for legacy code, if required use Decorator pattern");
            stringBuilder.Append("\n");
            Console.WriteLine(stringBuilder);

            CreateEmployees();
        }

        public void CreateEmployees()
        {
            List<IEmployee> employees = new List<IEmployee>();

            employees.Add(new Employee(firstname:"amir", id:"1", lastname:"khan"));

            //EmployeeDBAdapter to convert EmployeeDB to Employee
            var employeeDb = new EmployeeDB(givenName: "amirDB", id: 1, lastname: "khanDB");
            employees.Add(new EmployeeDBAdapter(employeeDb));

            //EmployeeLDAPAdapter to convert EmployeeLDAP to Employee
            var employeeLdap = new EmployeeLDAP(firstName: "amirLDAP", id: 1, lastname: "khanLDAP");
            employees.Add(new EmployeeLDAPAdapter(employeeLdap));

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Id);
                Console.WriteLine(employee.FirstName);
                Console.WriteLine(employee.LastName);
            }

            Console.WriteLine();

            Program.PressEnterToContinue();
        }

    }

    interface IEmployee
    {
       string Id { get; }
       string LastName { get;  }
       string FirstName { get;  }
    }

    class Employee : IEmployee
    {
        private string _id;
        private string _lastname;
        private string _firstname;

        public Employee(string id, string lastname, string firstname)
        {
            this._id = id;
            this._lastname = lastname;
            this._firstname = firstname;
        }

        public string Id
        {
            get { return _id; }
        }

        public string LastName
        {
            get { return _lastname; }
        }

        public string FirstName
        {
            get { return _firstname; }
        }


 }

    class EmployeeDB
    {
        private int _id;
        private string _lastname;
        private string _givenName;

        public EmployeeDB(int id, string lastname, string givenName)
        {
            this.Id = id;
            this.Lastname = lastname;
            this.GivenName = givenName;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string GivenName
        {
            get { return _givenName; }
            set { _givenName = value; }
        }
    }

    class EmployeeLDAP
    {
        private int _id;
        private string _lastname;
        private string _firstName;

        public EmployeeLDAP(int id, string firstName, string lastname)
        {
            this.Id = id;
            this.Lastname = lastname;
            this.FirstName = firstName;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
    }

    class EmployeeDBAdapter : IEmployee
    {
        private EmployeeDB _employeeDb;

        public EmployeeDBAdapter(EmployeeDB employeeDb)
        {
            _employeeDb = employeeDb;
        }

        public string Id
        {
            get { return _employeeDb.Id + ""; }
        }

        public string LastName
        {
            get { return _employeeDb.Lastname; }
        }

        public string FirstName
        {
            get { return _employeeDb.GivenName; }
        }
    }

    class EmployeeLDAPAdapter : IEmployee
    {
        private EmployeeLDAP _employeeLdap;

        public EmployeeLDAPAdapter(EmployeeLDAP employeeLdap)
        {
            _employeeLdap = employeeLdap;
        }

        public string Id
        {
            get { return _employeeLdap.Id + ""; }
        }

        public string LastName
        {
            get { return _employeeLdap.Lastname; }
        }

        public string FirstName
        {
            get { return _employeeLdap.FirstName; }
        }
    }


}
