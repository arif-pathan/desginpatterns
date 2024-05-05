using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{
    internal class DecoratorPatternAbstract
    {
        internal DecoratorPatternAbstract()
        {
            Sandwich pizza = new DressingDecorator2(new MeatDecorator2(new SimpleSandwich2()));
            Console.WriteLine(pizza.make());


            //var output = new DressingDecorator2(new MeatDecorator2(new SimpleSandwich2())).make();
            //Console.WriteLine(output);

            //Sandwich sandwich = new SimpleSandwich2();

            //sandwich = new MeatDecorator2(sandwich);

            //sandwich=new DressingDecorator2(sandwich);

            //string output1 =sandwich.make();
            //Console.WriteLine(output1);

        }
    }

    internal abstract  class Sandwich
    {
        internal abstract string make();
    }

    internal class SimpleSandwich2 : Sandwich
    {

        internal override string make()
        {
            return "SimpleSandwich2";
        }
    }

    internal abstract class SandwichDecorator2 : Sandwich
    {
        internal Sandwich _customSandwich;
            

        internal SandwichDecorator2(Sandwich customsandwich)
        {
            _customSandwich = customsandwich;
        }


        internal override string make()
        {
            var output= _customSandwich.make();
            return output;
        }


    }

    internal class DressingDecorator2 : SandwichDecorator2
    { 
        internal DressingDecorator2(Sandwich customsandwich):base(customsandwich)
        {
            _customSandwich = customsandwich;
        }


        internal override string make()
        {
            var output= _customSandwich.make() + addDressing();
            return output;
        }

        string addDressing()
        {
            return " addDressing";
        }

    }


    internal class MeatDecorator2 : SandwichDecorator2
    {
        internal MeatDecorator2(Sandwich customsandwich)
            : base(customsandwich)
        {
            _customSandwich = customsandwich;
        }


        internal override string make()
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
