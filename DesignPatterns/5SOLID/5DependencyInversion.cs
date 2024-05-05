using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID
{
    ////https://code.msdn.microsoft.com/windowsapps/OOPS-Principles-SOLID-7a4e69bf
    class _5DependencyInversion
    {
        //Dependency injection (DI) is a technique for achieving loose coupling between objects and their collaborators, or dependencies. 
        //VS
        //ServiceLocator pattern - remove depdenencies in other way but purpose is similar to dependency injection that is remove dependencies


        //Most often, classes will declare their dependencies via their constructor, 
        //allowing them to follow the Explicit Dependencies Principle.This approach is known as "constructor injection".

        //When classes are designed with DI in mind, they are more loosely coupled because they do not have direct, 
        //hard-coded dependencies on their collaborators. This follows the Dependency Inversion Principle, which states that 
        //"high level modules should not depend on low level modules; both should depend on abstractions."


        void DependencyInversion()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\n\nDependency Inversion Principle");
            stringBuilder.Append("\n");
            Console.WriteLine(stringBuilder);
        }
    }
}
