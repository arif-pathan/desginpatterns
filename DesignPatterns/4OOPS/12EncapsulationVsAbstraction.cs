using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns._4OOPS
{
    //https://www.codeproject.com/Articles/1037139/Difference-between-Encapsulation-and-Abstraction-i
    //http://www.geekinterview.com/talk/5381-abstraction-vs-encapsulation.html
    class _5EncapsulationVsAbstraction
    {
        private StringBuilder stringBuilder = new StringBuilder();
        _5EncapsulationVsAbstraction()
    {
    stringBuilder.Append("Abstraction means hiding the internal details and just exposing the functionality.                                ");
    stringBuilder.Append("    Abstraction focuses on the outside view of an object (i.e.the interface)                                      ");
    stringBuilder.Append("Encapsulation means put the data and the function that operate on that data in a single unit(information hiding) .");
    stringBuilder.Append("Encapsulation is a process of binding data members(variables, properties) and member functions(methods) together." +
        "In object oriented programming language we achieve encapsulation through Class.");
    stringBuilder.Append("Encapsulation prevents clients from seeing its inside view, where the behavior of the abstraction is implemented. ");
    stringBuilder.Append("    After encapsulation what we see from outside is Abstraction                                                   ");
    stringBuilder.Append("So procedure hiding is Abstraction and putting every necessary thing into one is Encapsulation.                   ");
            stringBuilder.Append(
                "Example When you change the gear of your car, you know the gears will be changed without knowing how they are " +
                "functioning internally.");
    }
}



}
