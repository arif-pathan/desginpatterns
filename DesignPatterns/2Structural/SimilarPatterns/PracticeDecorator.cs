using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural
{
    class PracticeDecorator
    {
        public PracticeDecorator()
        {
            IBurger burger = new SimpleBurger();

            burger = new MeatBurgerDecorator(burger);
            burger=new DressingBurgerDecorator(burger);

            Console.WriteLine(burger.make());
        }
    }

    interface IBurger
    {
        string make();
    }

    class SimpleBurger:IBurger
    {
        public string make()
        {
            return "Simple Burger";
        }
    }

    abstract class BurgerDecorator : IBurger
    {
        public IBurger _burger;
       public BurgerDecorator(IBurger burger)
        {
            _burger = burger;
        }

        public abstract string make();
        //public virtual string make()
        //{
        //    return _burger.make();
        //}
    }

    class DressingBurgerDecorator:BurgerDecorator
    {
        public DressingBurgerDecorator(IBurger burger) : base(burger)
        { }

        public override string make()
        {
            return _burger.make() + "\naddDressing";
        }
    }

    class MeatBurgerDecorator:BurgerDecorator
    {
        public MeatBurgerDecorator(IBurger burger) :base(burger)
        { }

        public override string make()
        {
            return _burger.make() + "\naddMeat";
        }
    }

}
