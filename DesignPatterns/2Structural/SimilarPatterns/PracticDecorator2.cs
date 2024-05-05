using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{
    class PracticDecorator2
    {
        public static void TestDecorate()
        {
            IIcecream icecream = new SimpleIcecream();
            icecream=new ColorDecorator(icecream);
            icecream=new CreamDecorator(icecream);

            Console.WriteLine(icecream.Make());

        }
       
    }

    interface IIcecream
    {
        string Make();
    }

    class SimpleIcecream : IIcecream
    {
        public string Make()
        {

            return "base Simple IceCream";
        }
    }

    class IcecreamDecorator:IIcecream
    {
        public IIcecream _icecream;

        public IcecreamDecorator(IIcecream icecream)
        {
            _icecream = icecream;
        }

        public virtual string Make()
        {
            return _icecream.Make();
        }
    }


    class ColorDecorator : IcecreamDecorator
    {
        public ColorDecorator(IIcecream icecream):base(icecream)
        { }

        public override string Make()
        {
            return _icecream.Make() + "\nColor Decorator";
        }
    }


    class CreamDecorator : IcecreamDecorator
    {
        public CreamDecorator(IIcecream icecream) : base(icecream)
        {
        }

        public override string Make()
        {
            return _icecream.Make() + "\nCreamDecorator";
        }
    }

}
