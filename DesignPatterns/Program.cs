using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DesignPatterns.Behavioural;
using DesignPatterns.Creational;
using DesignPatterns.Structural;
using DesignPatterns.OOPS;
using DesignPatterns.Practice;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //StringBuilder stringBuilder = new StringBuilder();
            //stringBuilder.Append("\nProject Usage Factory - Factory HousingGatweay / FCGateway - Factory Pattern");
            //stringBuilder.Append("\nProject Usage Factory- ActionFactory - Multiple dependencies injection as and when accessed ore required");


            //stringBuilder.Append("\nProject Usage Facade - Apartment, Coapplicant subsystem was exposed via one system");
            //stringBuilder.Append("\nProject Usage Facade - Application, ICFCodes,PersonDetailsEdit, multiple subsystems exposed via one unified interface");

            //stringBuilder.Append("\nProject Usage SingleTon - GlobalInitializations - Single Mapping Copy");



            /////Practice
            //  PracticeStructural s = new PracticeStructural();



            //   InterfaceVsAbstract a = new InterfaceVsAbstract();

            // // //Creational
            // Singleton.SingletonTheory();
            // Singleton.TestSingletonNoLockNoThreadSafe();
            //Singleton.TestSingletonLockThreadSafe();
            //Singleton.TestSingletonWithoutLockThreadSafe();
            //Singleton.TestSingletonLazyThreadSafe();
            // PrototypePattern p = new PrototypePattern();

            //TestFactoryPatternClientCode();
            // FactoryPattern pattern = new FactoryPattern();
            //FactoryPattern.TestFactoryPatternFactoryClassWithComposition();
            //TestFactoryPatternFactoryClassWithComposition();
            // AbstractFactoryPattern f= new AbstractFactoryPattern();

            // // //Structural

            // AdapterPattern adapterPattern = new AdapterPattern();
            // DecoratorPattern decoratorPattern = new DecoratorPattern();
            // DecoratorPatternAbstract decoratorPattern = new DecoratorPatternAbstract();
            //PracticeDecorator decorator = new PracticeDecorator();
            //PracticDecorator2.TestDecorate();
            //ProxyPattern.TestProxyPattern();
            //TestProxyPattern();

            //FacadePattern facadePattern = new FacadePattern();
            //facadePattern.DoSystemOperationOne();
            //facadePattern.DoSystemOperationTwo();

            //CompositePattern p = new CompositePattern();

            //  // //Behavioural

            // IteratorPattern pattern=new IteratorPattern();
            // ObserverPattern pattern = new ObserverPattern();
            // StrategyPattern strategyPattern=new StrategyPattern();

            // BridgePattern bridgePattern =new BridgePattern();
            //CompositePattern compositePattern = new CompositePattern();
            //  FlywieghtPattern flywieghtPattern = new FlywieghtPattern();

            // CommandPattern pattern = new CommandPattern();
            TestPatternsPracticeTwoP();


            Console.ReadLine();
        }



         public   static void TestPatternsPracticeTwoP()
        {
            //SingleTonP p = new SingleTonP();
            //FactoryP factoryP=new FactoryP();
            //AbstractFactoryP acAbstractFactoryP=new AbstractFactoryP();
            //ProtoTypeP protoTypeP = new ProtoTypeP();

            //AdapterP adapter = new AdapterP();
            // DecoratorP decoratorP = new DecoratorP();
            //ProxyP p = new ProxyP();
            //FacadeP facadeP = new FacadeP();

            //IteratorP iteratorP = new IteratorP();
            //ObserverP observer = new ObserverP();

            // CommandP commandP = new CommandP();
            StrategyP strategyP = new StrategyP();

        }

        public static void PressEnterToContinue()
        {
            Console.WriteLine("\nPress Enter to Continue");
            Console.ReadLine();
        }

        public static void Test(int i)
        {
            //int i;
            //i.ToString();
        }



        //https://www.codeproject.com/articles/716413/factory-method-pattern-vs-abstract-factory-pattern
        //[2/7/2017 4:57 PM] NP: 
       // http://stackoverflow.com/questions/2280170/why-do-we-need-abstract-factory-design-pattern


        private static void TestFactoryPatternClientCode()
        {
            Console.WriteLine("Factory Client Code");
            string input = Console.ReadLine();
            AbstractCourse course = null;
                switch (input)
                {
                    case "java":
                        course = new JavaAbstractCourse();
                        break;
                    case "dotnet":
                        course = new DotNetAbstractCourse();
                        break;
                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }
                course?.GetSchedule();
        }


       
    }
}
