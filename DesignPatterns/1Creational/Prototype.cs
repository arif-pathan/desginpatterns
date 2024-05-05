using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational
{
    class PrototypePattern
    {
        public PrototypePattern()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\nPrototype Design pattern" +
                                 "\nCreational Pattern uses protype to create new objects");
            

            stringBuilder.Append("\n");
            Console.WriteLine(stringBuilder);

            Prototype a = new ConcretePrototype1("prototyp1");
            Prototype b = a.Clone();
        }
    }

    abstract class Prototype
    {
        string id;

        public Prototype(string Id)
        {
            id = Id;
        }


       public abstract Prototype Clone();
    }

    class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(string Id):base(Id)
        {

        }
        public override Prototype Clone()
        {
            Console.WriteLine("MemberwiseClone() Return shallow copy of object in Clone method");
            return (Prototype)this.MemberwiseClone();
        }
    }
}
