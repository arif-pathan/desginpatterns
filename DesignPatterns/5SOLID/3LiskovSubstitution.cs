using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.SOLID
{
    ////https://code.msdn.microsoft.com/windowsapps/OOPS-Principles-SOLID-7a4e69bf
    class _3LiskovSubstitution
    {
        void LiskovSubstitution()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\n\nLiskov Substitution Principle");
            stringBuilder.Append("\nAs per Liskov Substitution Principle Derived types must be completely substitutable for their base types");
            stringBuilder.Append("\nClasses that derive from base class should only extend and not impact existing functionality of base class");
            stringBuilder.Append("\nIf any module is using the base class then it can be replaced by dervied class without impacting the module functionality");

            stringBuilder.Append("\nIn below example Square derives from Rectangle but it cannot replace rectangle as it overrides the methods getarea " +
                                 "and result would be different, so functionality of module will change over here");

            //How do we fix this, i.e., ensure that this principle is not violated? Well, you can have a new class introduced called Quadrilateral 
            //and ensure that both the Rectangle and the Square classes extend the Quadrilateral class.



            Console.WriteLine(stringBuilder);

        }

        class Rectangle
        {
            public int x;
            public int y;

            public virtual void SetWidth(int width)
            {
                x = width;
            }

            public virtual void Setheight(int height)
            {
                y = height;
            }

            int GetArea()
            {
                return x*y;
            }

        }

        class Square : Rectangle
        {

            public override void SetWidth(int width)
            {
                x = width;
                y = width;
            }

            public override void Setheight(int height)
            {
                y = height;
                x = height;
            }

            int GetArea()
            {
                return x * x;
            }

        }

        public class Quadrilateral

        {

            public virtual int Height { get; set; }

            public virtual int Width { get; set; }

            public int Area

            {

                get

                {

                    return Height * Width;

                }

            }

        }

    }
}
