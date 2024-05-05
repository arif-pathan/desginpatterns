using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioural
{
    class IteratorPattern
    {
        public IteratorPattern()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("IteratorPattern is a behavioural pattern");
            stringBuilder.Append("\nProvides a way to access elements of an aggregate sequentially " +
                                 "\nwithout exposing its underlying structure");
            stringBuilder.Append("\nImplementation has Iterator abstract class which provides methods to access elements of Aggregate" +
                                 "\nConcreteIterator take Agregates and provide methods to iteratre over it, " +
                                 "\nAggregate which contains elements and provide interface to create Iterator and " +
                                 "\nConcreteAggregate which implements Aggregate creates Iterator"
                                 );
            stringBuilder.Append("\n");
            stringBuilder.Append("");
            Console.WriteLine(stringBuilder);
            Program.PressEnterToContinue();

            ConcreteAggregator a=new ConcreteAggregator();
            a[0] = 1;
            //a[1] = 2;
            a[2] = 3;
            a[3] = 4;

            Iterator iterator = a.CreateIterator();
            var j = iterator.First();
            Console.WriteLine("Current Item " + j);
            while (!iterator.Done())
            {
                var k=iterator.Next();
                Console.WriteLine("Sequential next Item "+k);
            }
        }


        public abstract class Iterator
        {
            public abstract object First();
            public abstract object Next();

            public abstract bool Done();

            public abstract object CurrentItem();

        }

        public abstract class Aggregate
        {
            public abstract Iterator CreateIterator();
        }

        public class ConcreteIterator : Iterator
        {
            private ConcreteAggregator _aggregator;
            private int _current = 0;

            public ConcreteIterator(ConcreteAggregator aggregator)
            {
                _aggregator = aggregator;
            }


            public override object First()
            {
               return _aggregator[0];
            }

            public override object Next()
            {
                object s = null;
                if (_current <= _aggregator.Count())
                {
                    _current = _current + 1;
                    s = _aggregator[_current];

                }
                return s;
            }

            public override bool Done()
            {
                return _current >= _aggregator.Count()-1;
            }

            public override object CurrentItem()
            {
                return _aggregator[_current];
            }
        }

        public class ConcreteAggregator : Aggregate
        {
            private Iterator _iterator;
            private ArrayList arrayList = new ArrayList();




            public override Iterator CreateIterator()
            {
                return new ConcreteIterator(this);
            }

            public int Count()
            {
                return arrayList.Count;
            }

            public object this[int index]
            {
                get { return arrayList[index]; }
                set { arrayList.Add(value); }
            }
        }

    }


}
