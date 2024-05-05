using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{
    public class DecoratorPattern
    {
        //http://www.oodesign.com/decorator-pattern.html
        //Extending an object�s functionality can be done statically (at compile time) by using inheritance 
        //however it might be necessary to extend an object�s functionality dynamically (at runtime) as an object is used.

        //in c# its compulsory to have the method virtual in decorator, 
        //else it always refer to the base decorator instead of the concrete implementations of decorator
        //or use abstract method then we need to write override keyword

        //https://sourcemaking.com/design_patterns/proxy
        //  Adapter provides a different interface to its subject.Proxy provides the same interface. 
        //Decorator provides an enhanced interface.
        //Decorator and Proxy have different purposes but similar structures.
        //Both describe how to provide a level of indirection to another object, 
        //and the implementations keep a reference to the object to which they forward requests.

        public DecoratorPattern()
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Decorator Structural Pattern :" +
                                 "\nExtending an objects functionality can be done statically (at compile time) by using inheritance");
            stringBuilder.Append("\n");
            stringBuilder.Append("however it might be necessary to extend an objects functionality dynamically (at runtime) as an object is used");
            stringBuilder.Append("\n");
            stringBuilder.Append("in c# its compulsory to have the method virtual in decorator so it can be overridden in decorator");
            stringBuilder.Append("\n");
            stringBuilder.Append("Both Decorator and Proxy describe how to provide a level of indirection to another object");
            stringBuilder.Append("\n");
            stringBuilder.Append("and the implementations keep a reference to the object to which they forward requests");
            stringBuilder.Append("\n");
            Console.WriteLine(stringBuilder);
            Program.PressEnterToContinue();

            ISandwich pizza = new DressingDecorator(new MeatDecorator(new SimpleSandwich()));
             Console.WriteLine(pizza.make());


            var output = new DressingDecorator(new MeatDecorator(new SimpleSandwich())).make();
            Console.WriteLine(output);

            ISandwich sandwich = new SimpleSandwich();

            sandwich = new DressingDecorator(sandwich);

            sandwich = new MeatDecorator(sandwich);

            

            string output1 = sandwich.make();
            Console.WriteLine(output1);

        }
    }

    public interface ISandwich
    {
        string make();
    }

    public class SimpleSandwich : ISandwich
    {

        public string make()
        {
            return "SimpleSandwich";
        }
    }

    public abstract class SandwichDecorator : ISandwich
    {
        public ISandwich _customSandwich;
            

        internal SandwichDecorator(ISandwich customsandwich)
        {
            _customSandwich = customsandwich;
        }


        public virtual string make()
        {
            var output= _customSandwich.make();
            return output;
        }


    }

    public class DressingDecorator : SandwichDecorator
    { 
        public DressingDecorator(ISandwich customsandwich):base(customsandwich)
        {
           // _customSandwich = customsandwich;
        }


        public override string make()
        {
            var output= _customSandwich.make() + addDressing();
            return output;
        }

        string addDressing()
        {
            return " addDressing";
        }

    }


    public class MeatDecorator : SandwichDecorator
    {
        public MeatDecorator(ISandwich customsandwich)
            : base(customsandwich)
        {
           // _customSandwich = customsandwich;
        }


        public override string make()
        {
            var output= _customSandwich.make() + addMeat();

            return output;
        }

        string addMeat()
        {
            return " addMeat";
        }

    }
}
