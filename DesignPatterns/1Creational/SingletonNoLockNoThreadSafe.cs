using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.Creational
{
    //http://csharpdesignpatterns.codeplex.com/

    //http://csharpdesignpatterns.codeplex.com/wikipage?title=Singleton%20Pattern&referringTitle=Home

    //https://msdn.microsoft.com/en-us/library/dd997286(v=vs.110).aspx

    //Other links
    //https://www.codeproject.com/Articles/430590/Design-Patterns-of-Creational-Design-Patterns
    //https://www.codeproject.com/Articles/438922/Design-Patterns-of-Structural-Design-Patterns
    //https://www.codeproject.com/Articles/455228/Design-Patterns-of-Behavioral-Design-Patterns

    class Singleton
    {
        public static void SingletonTheory()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Singleton creational pattern");
            stringBuilder.Append("\nthread safety-lock but performance impact");
            stringBuilder.Append("\nprivate constructor");
            stringBuilder.Append("\nsealed class - to avoid inheritence and prevent making objects of child class");
            stringBuilder.Append("\nstatic getinstance or variable");
            stringBuilder.Append("\nUsing internal class or static read only variable");
            stringBuilder.Append("\nLazy loading");
            Console.WriteLine(stringBuilder);
        }

        public static void TestSingletonNoLockNoThreadSafe()
        {
            //SingletonPattern p = new SingletonPattern(); Not allowed
            //Once it goes in constructor it will never go again
            Console.WriteLine("\n\nTesting TestSingleton NoLock NoThreadSafe");
            Thread t1;

            for (int i = 0; i < 20; i++)
            {
                t1 = new Thread(() => { SingletonNoLockNoThreadSafe p1 = SingletonNoLockNoThreadSafe.GetInstance; });
                t1.Start();
            }

        }

        public static void TestSingletonLockThreadSafe()
        {
            //SingletonPattern p = new SingletonPattern(); Not allowed
            //Once it goes in constructor it will never go again
            //SingletonPattern p = SingletonPattern.GetInstancePattern;
            Console.WriteLine("\n\nTesting TestSingletonLockThreadSafe");

            Thread t1;

            for (int i = 0; i < 20; i++)
            {
                t1 = new Thread(() => { SingletonLockThreadSafe p1 = SingletonLockThreadSafe.GetInstance; });
                t1.Start();
            }
        }

        public static void TestSingletonWithoutLockThreadSafe()
        {
            //SingletonPattern p = new SingletonPattern(); Not allowed
            //Once it goes in constructor it will never go again
            //SingletonPattern p = SingletonPattern.GetInstancePattern;

            Console.WriteLine("\n\nTesting TestSingletonWithoutLock ThreadSafe");

            Thread t1;

            for (int i = 0; i < 20; i++)
            {
                t1 = new Thread(() => { SingletonWithoutLockThreadSafe p1 = SingletonWithoutLockThreadSafe.GetInstance; });
                t1.Start();
            }

            }

        public static void TestSingletonLazyThreadSafe()
        {
            //SingletonPattern p = new SingletonPattern(); Not allowed
            //Once it goes in constructor it will never go again
            //SingletonPattern p = SingletonPattern.GetInstancePattern;
            Console.WriteLine("\n\nTesting TestSingletonLazy ThreadSafe");

            Thread t1;

            for (int i = 0; i < 20; i++)
            {
                t1 = new Thread(() => { SingletonLazyThreadSafe p1 = SingletonLazyThreadSafe.GetInstance; });
                t1.Start();
            }

           
        }
    }

    class SingletonNoLockNoThreadSafe
    {
        private static SingletonNoLockNoThreadSafe singleton;
        private static int count = 0;

        private SingletonNoLockNoThreadSafe()
        {
            //Console.WriteLine("Inside constructor ThreadId :" + Thread.CurrentThread.ManagedThreadId);
            //Console.WriteLine("Inside constructor count :" + count);
            count++;
            if (count > 1)
            {
               Console.WriteLine("SingletonNoLockNoThreadSafe Inside constructor multiple times not thread safe ThreadId: " +
                                  Thread.CurrentThread.ManagedThreadId);
            }

        }

        public static SingletonNoLockNoThreadSafe GetInstance
        {
            get
            {
                if (singleton == null)
                {
                    singleton = new SingletonNoLockNoThreadSafe();
                }
                Console.WriteLine("Outside if ThreadId" + Thread.CurrentThread.ManagedThreadId);
                return singleton;
            }
            

        }

    }


    class SingletonLockThreadSafe
    {
        //Performance with locks
        private static SingletonLockThreadSafe singletonLockThreadSafe;
        private static readonly object lockObject = new object();
        private static int count = 0;

        private SingletonLockThreadSafe()
        {
            Console.WriteLine("Inside constructor ThreadId :" + Thread.CurrentThread.ManagedThreadId);
            count++;
            if(count>1)
            Console.WriteLine("Inside constructor multiple times not thread safe Thread " + Thread.CurrentThread.ManagedThreadId);
        }

        public static SingletonLockThreadSafe GetInstance
        {
            get
            {
                if (singletonLockThreadSafe == null)
                {
                    lock (lockObject)
                    {
                        if (singletonLockThreadSafe == null)
                        {
                            singletonLockThreadSafe=new SingletonLockThreadSafe();
                            
                        }
                    }
                }
                Console.WriteLine("Outside if Thread " + Thread.CurrentThread.ManagedThreadId);
                return singletonLockThreadSafe;
            }

        }


    }

    
    class SingletonWithoutLockThreadSafe
    {
        //Performance with locks
        private static readonly SingletonWithoutLockThreadSafe singleton = new SingletonWithoutLockThreadSafe();
        private static int count = 0;
        private SingletonWithoutLockThreadSafe()
        {
            Console.WriteLine("Inside constructor ThreadId :" + Thread.CurrentThread.ManagedThreadId);
            count++;
            if (count > 1)
                Console.WriteLine("Inside constructor multiple times not thread safe Thread " + Thread.CurrentThread.ManagedThreadId);
        }

        public static SingletonWithoutLockThreadSafe GetInstance
        {
            get
            {
                Console.WriteLine("Outside if Thread " + Thread.CurrentThread.ManagedThreadId);
                return singleton;
            }

        }


    }


    class SingletonLazyThreadSafe
    {
        //Performance issue with locks, using static class will solve but using lazy further will give some more performance or memory improvements
        //as object will be initialized only when required
        private static readonly Lazy<SingletonLazyThreadSafe> singleton = new Lazy<SingletonLazyThreadSafe>(()=>new SingletonLazyThreadSafe());
        private static int count = 0;
        private SingletonLazyThreadSafe()
        {
            Console.WriteLine("Inside constructor ThreadId :" + Thread.CurrentThread.ManagedThreadId);
            count++;
            if (count > 1)
                Console.WriteLine("Inside constructor multiple times not thread safe ThreadId : " + Thread.CurrentThread.ManagedThreadId);
        }

        public static SingletonLazyThreadSafe GetInstance
        {
            get
            {
                Console.WriteLine("Outside if Thread " + Thread.CurrentThread.ManagedThreadId);
                return singleton.Value;
            }

        }


    }
}
