using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatterns.Practice
{
    public static class MyExtensions
    {
        public static void ConsoleExension(this string s)
        {
            Console.WriteLine(s);
        }
    }

    #region CreationalStart
    //Focusses on the creation of new objects by hiding the internal logic of how the objects are created
    #endregion CreationalStart

    #region Singleton
    public class SingleTonP
    {
        Thread[] arrayThreads = new Thread[10];
        public SingleTonP()
        {
            for (int i = 0; i < 10; i++)
            {
                //Thread thread = new Thread(() => { MySingleton isntance = MySingleton.GetMySingleton; });
                //Thread thread = new Thread(() => { MySingletonClassLazyLoading isntance = MySingletonClassLazyLoading.GetMySingleton; });
                Thread thread = new Thread(() => { MySingletonClass isntance = MySingletonClass.GetMySingleton; });
                arrayThreads[i] = thread;
                arrayThreads[i].Start();
            }

            for (int i = 0; i < 10; i++)
            {
                arrayThreads[i].Join();
            }


            Console.WriteLine("Multiple Threads over");
        }
        //When there is a requirement to use single instance of particular class
    }

    public class MySingleton
    {
        private static readonly object lockvar = new object();
        private static MySingleton mySingletonInstance;

        private MySingleton()
        {
            Console.WriteLine("In Constrcutor");
        }

        public static MySingleton GetMySingleton
        {
            get
            {
                if (mySingletonInstance == null)
                {
                    lock (lockvar)
                    {
                        if (mySingletonInstance == null)
                            mySingletonInstance = new MySingleton();

                    }

                }
                Console.WriteLine("Thread Id {0}", Thread.CurrentThread.ManagedThreadId);
                return mySingletonInstance;
            }
        }
    }

    class MySingletonClass
    {
        private static readonly MySingletonClass mySingletonInstance = new MySingletonClass();
        private MySingletonClass()
        { Console.WriteLine("In Constrcutor"); }

        public static MySingletonClass GetMySingleton
        {
            get
            {
                Console.WriteLine("Thread Id {0}", Thread.CurrentThread.ManagedThreadId);

                return mySingletonInstance;
            }
        }
    }

    class MySingletonClassLazyLoading
    {

        private static readonly Lazy<MySingletonClassLazyLoading> mySingletonInstance =
            new Lazy<MySingletonClassLazyLoading>(() => new MySingletonClassLazyLoading());
        private MySingletonClassLazyLoading()
        { Console.WriteLine("In Constrcutor"); }

        public static MySingletonClassLazyLoading GetMySingleton
        {
            get
            {
                Console.WriteLine("Thread Id {0}", Thread.CurrentThread.ManagedThreadId);

                return mySingletonInstance.Value;
            }
        }
    }

    #endregion Singleton

    #region Factory
    class FactoryP
    {
        //Creates object at run time based on input
        HousingFactory housingFactory = new HousingFactory();
        private IHousing housing;
        public FactoryP()
        {
            housing = housingFactory.GetHousing(1);
            Console.WriteLine(housing.GetType());
        }

    }

    interface IHousing
    {
        void GetApartments();
    }

    class PermanentHousing : IHousing
    {
        public void GetApartments()
        {
            Console.WriteLine("Permanent");
        }
    }

    class AlternateHousing : IHousing
    {
        public void GetApartments()
        {
            Console.WriteLine("Alternate");
        }
    }

    internal class HousingFactory
    {
        private IHousing housing;
        public IHousing GetHousing(int choice)
        {
            switch (choice)
            {
                case 1:

                    housing = new PermanentHousing();
                    break;
                case 2:
                    housing = new AlternateHousing();
                    break;
                default:
                    Console.WriteLine("Wrong choice");
                    break;
            }
            return housing;
        }

    }

    #endregion Factory

    #region AbstractFactory
    class AbstractFactoryP
    {
        //Used when there is a need to create families of related or interdependent objects 
        internal AbstractFactoryP()
        {
            Machine m = new Machine();
            m.AssembleMachine(new LowMachine());
        }


    }

    interface IRam
    {
        void Perform();
    }

    interface IDsiplay
    {
        void Display();
    }

    interface IProcessor
    {
        void Process();
    }


    interface IMachine
    {
        IRam GetRam();
        IDsiplay GetDsiplay();
        IProcessor GetProcessor();
    }

    public class HighRam : IRam
    {
        public void Perform()
        {
            "High Ram Perform".ConsoleExension();
        }
    }

    public class LowRam : IRam
    {
        public void Perform()
        {
            "Low Ram Perform".ConsoleExension();
        }
    }

    public class HighDisplay : IDsiplay
    {
        public void Display()
        {
            "High Display".ConsoleExension();
        }
    }

    public class LowDisplay : IDsiplay
    {
        public void Display()
        {
            "Low Display".ConsoleExension();
        }
    }

    public class HighProcessor : IProcessor
    {
        public void Process()
        {
            "High Process".ConsoleExension();
        }
    }

    public class LowProcessor : IProcessor
    {
        public void Process()
        {
            "Low Process".ConsoleExension();
        }
    }

    class HighMachine : IMachine
    {

        public IRam GetRam()
        {
            "HighMachine HighRam".ConsoleExension();
            return new HighRam();
        }

        public IDsiplay GetDsiplay()
        {
            "HighMachine High Display".ConsoleExension();

            return new HighDisplay();
        }

        public IProcessor GetProcessor()
        {
            "HighMachine High Processor".ConsoleExension();

            return new HighProcessor();
        }
    }

    class LowMachine : IMachine
    {

        public IRam GetRam()
        {
            "LowMachine Low Ram".ConsoleExension();
            return new LowRam();
        }

        public IDsiplay GetDsiplay()
        {
            "LowMachine Low Display".ConsoleExension();

            return new LowDisplay();
        }

        public IProcessor GetProcessor()
        {
            "LowMachine Low Processor".ConsoleExension();

            return new LowProcessor();
        }
    }

    class AvgMachine : IMachine
    {

        public IRam GetRam()
        {
            "AvgMachine Avg Ram".ConsoleExension();
            return new HighRam();
        }

        public IDsiplay GetDsiplay()
        {
            "AvgMachine Avg Display".ConsoleExension();

            return new HighDisplay();
        }

        public IProcessor GetProcessor()
        {
            "AvgMachine Avg Processor".ConsoleExension();

            return new HighProcessor();
        }
    }

    class Machine
    {

        internal void AssembleMachine(IMachine machine)
        {
            machine.GetProcessor().Process();
            machine.GetDsiplay().Display();
            machine.GetRam().Perform();
        }
    }

    #endregion AbstractFactory

    #region Prototype
    class ProtoTypeP
    {
        internal ProtoTypeP()
        {
            Prototype protoType = new Prototype();
            Prototype protoTypeClone = protoType.GetClone();
            protoTypeClone.i.ToString().ConsoleExension();
            "Deep copy of internal object apartment fails k should be 30 but it is 0".ConsoleExension();
            protoTypeClone.k.ToString().ConsoleExension();
        }
    }

    class Prototype
    {
        //Create prototype of exising object
        //Memberwise clone, shallow copy no deep copy 
        internal int i = 20;
        Apartment a = new Apartment();
        internal int k = 0;
        internal Prototype GetClone()
        {
            k = a.j;
            return (Prototype)new Prototype().MemberwiseClone();
        }
    }

    class Apartment
    {
        internal int j = 30;
    }




    #endregion Prototype

    #region Creationalend
    #endregion Creationalend

    #region StructuralStart 
    //Focusses on the composition of the object and classess
    #endregion StructuralStart

    #region Adapter
    class AdapterP
    {
        //Adapter Proxy and Decorator provide a level of indirection to the object they are referring to
        //Use adapter to glue old legacy code with new code  
        //User proxy when the original class is heavy to load in beginning
        //User decorator when you need to add functionality at run time
        internal AdapterP()
        {
            List<StudentBase> studList = new List<StudentBase>();
            studList.Add(new Student() { FirstName = "Manoj", LastName = "Lahore" });
            studList.Add(new ExternalStudentAdapter(new ExternalStudent() { GivenName = "Jai", SurName = "Kishan" }));

            foreach (var studentBase in studList)
            {
                Console.WriteLine(studentBase.FirstName + studentBase.LastName);
            }
        }

    }

    abstract class StudentBase
    {
        internal abstract string FirstName { get; set; }
        internal abstract string LastName { get; set; }
    }

    class Student : StudentBase
    {
        internal override string FirstName { get; set; }

        internal override string LastName { get; set; }
    }

    class ExternalStudent
    {
        public string GivenName { get; set; }

        public string SurName { get; set; }
    }

    class ExternalStudentAdapter : StudentBase
    {
        private ExternalStudent _stud;
        internal ExternalStudentAdapter(ExternalStudent stud)
        {
            _stud = stud;
        }

        internal override string FirstName
        {
            get { return _stud.GivenName; }
            set { _stud.GivenName = value; }
        }

        internal override string LastName
        {
            get { return _stud.SurName; }
            set { _stud.SurName = value; }
        }
    }

    #endregion Adapter

    #region Proxyp
    class ProxyP
    {
        internal ProxyP()
        {
            string filepath = @"C:\\myimage.img";
            Image m = new Image(filepath);
            m.Process();

            MyProxy p = new MyProxy(filepath);
            p.Process();
        }
    }

    interface IImage
    {
        void Process();
    }

    class Image : IImage
    {
        internal Image(string filepath)
        {
            "InConstructor Heavy Loading of Image".ConsoleExension();
            LoadImage(filepath);
        }

        public void LoadImage(string filepath)
        {
            ("Heavy LoadImage" + filepath).ConsoleExension();
        }
        public void Process()
        {
            "ProcessImage".ConsoleExension();
        }
    }

    class MyProxy : IImage
    {
        private string _filepath;
        internal MyProxy(string filepath)
        {
            "In Proxy constructor no heavy loading".ConsoleExension();
            _filepath = filepath;
        }
        public void LoadImage(string filepath)
        {
            ("Heavy LoadImage" + filepath).ConsoleExension();
        }
        public void Process()
        {
            LoadImage(_filepath);
            "ProcessImage proxy".ConsoleExension();
        }
    }

    #endregion Proxyp

    #region DecoratorP
    class DecoratorP
    {
        internal DecoratorP()
        {
            IPizza pizza = new Pizza();

            pizza = new CheeseDecorator(pizza);

            pizza = new SaladDecorator(pizza);

            pizza.makePizza();
        }
    }

    interface IPizza
    {
        void makePizza();
    }

    class Pizza : IPizza
    {
        public void makePizza()
        {
            "Base Pizza".ConsoleExension();
        }
    }

    class Decorator : IPizza
    {
        internal IPizza _pizza;
        internal Decorator(IPizza pizza)
        {
            _pizza = pizza;
        }

        public virtual void makePizza()
        {
            _pizza.makePizza();
        }
    }

    class SaladDecorator : Decorator
    {
        public SaladDecorator(IPizza pizza) : base(pizza)
        {
        }

        public override void makePizza()
        {
            _pizza.makePizza();
            "SaladDecorator".ConsoleExension();

        }
    }

    class CheeseDecorator : Decorator
    {
        public CheeseDecorator(IPizza pizza) : base(pizza)
        {
        }

        public override void makePizza()
        {
            _pizza.makePizza();
            "CheeseDecorator".ConsoleExension();

        }
    }



    #endregion DecoratorP

    #region CompositeP
    class CompositeP
    {
        //Create tree like hierarchial structure
        //Both the nodes and parents are treated as same 
    }
    #endregion CompositeP

    #region FacadeP
    class FacadeP
    {
        //Refactoring, One unified outside interface, Combine all smal functionalities in one unit 
        SubSystemOne subSystemOne = new SubSystemOne();
        SubSystemTwo susSystemTwo = new SubSystemTwo();
        internal FacadeP()
        {
            UnifiedMethodOne();
            UnifiedMethodTwo();
        }

        internal void UnifiedMethodOne()
        {
            "UnifiedSystemOne".ConsoleExension();
            subSystemOne.MethodTwo();
            susSystemTwo.MethodOne();
        }

        internal void UnifiedMethodTwo()
        {
            "\n\nUnifiedSystemTwo".ConsoleExension();
            subSystemOne.MethodTwo();
            subSystemOne.MethodOne();
            susSystemTwo.MethodOne();
        }
    }

    class SubSystemOne
    {
        internal void MethodOne()
        {
            "SysteOne MethodOne".ConsoleExension();
        }

        internal void MethodTwo()
        {
            "SysteOne MethodTwo".ConsoleExension();
        }

    }

    class SubSystemTwo
    {
        internal void MethodOne()
        {
            "SubSystemTwo MethodOne".ConsoleExension();
        }

        internal void MethodTwo()
        {
            "SubSystemTwo MethodTwo".ConsoleExension();
        }

    }
    #endregion FacadeP

    #region StructuralEnd

    #endregion StructuralEnd

    #region BehavioralStart
    //Focusses on the communication between the objects
    #endregion BehavioralStart

    #region IteratorP
    class IteratorP
    {
        //Provides read only sequential access to the elements of the aggregator class
        //hiding internal details of how agregrator is internally implemented
        internal IteratorP()
        {
            Agregator agregator = new Agregator();
            agregator[0] = 1;
            agregator[1] = 2;
            agregator[2] = 3;

            IIterator iterator = agregator.GetItterator();

            "Total Agregator lenght is ".ConsoleExension();
            agregator.Count().ToString().ConsoleExension();

            object first = iterator.First();
            "firstelement is ".ConsoleExension();
            first.ToString().ConsoleExension();

            while (!iterator.Done())
            {
                object elementCurrent = iterator.Current();
                "CurrentElement is ".ConsoleExension();
                elementCurrent.ToString().ConsoleExension();
                object element = iterator.Next();
                "Next element is ".ConsoleExension();
                element.ToString().ConsoleExension();
            }
        }

    }

    interface IIterator
    {
        object First();

        object Next();

        object Current();

        bool Done();
    }


    class Iterator : IIterator
    {
        private Agregator _agregator;
        private int current = 0;
        public Iterator(Agregator agregator)
        {
            _agregator = agregator;
        }
        public object First()
        {
            return _agregator[0];
        }

        public object Next()
        {
            if (current < _agregator.Count())
            {
                current++;
            }
            return _agregator[current];
        }

        public object Current()
        {
            return _agregator[current];
        }

        public bool Done()
        {
            if (current == _agregator.Count() - 1)
                return true;
            else
            {
                return false;
            }
        }
    }

    interface IAgregator
    {
        IIterator GetItterator();
    }

    class Agregator : IAgregator
    {
        // IIterator iterator = new Iterator(new Agregator());
        ArrayList a = new ArrayList(3);
        public IIterator GetItterator()
        {
            return new Iterator(this);
        }

        public int Count()
        {
            return a.Count;
        }

        public object this[int i]
        {
            get { return a[i]; }
            set
            {
                a.Add(0);
                a[i] = value;
            }
        }
    }

    #endregion IteratorP

    #region Strategy
    class StrategyP
    {
        internal StrategyP()
        {
            "\nStrategy Pattern".ConsoleExension();
            //When there is a need to change strategy at run time
            IIBehavior behavior = new MyAgressiveBehavior();
            MyRobot robot = new MyRobot(behavior, "Agressive");
            robot.GetBehavior();

            "\nChanging Behavior At run time from agressive to avg".ConsoleExension();
            //Change behavior
            behavior = new MyAvgBehavior();
            robot.SetBehavior(behavior);

            robot.GetBehavior();
        }
    }

    interface IIBehavior
    {
        void DisplayBehavior();
    }

    class MyAvgBehavior: IIBehavior
    {
        public void DisplayBehavior()
        {
            "Avg Behavior".ConsoleExension();
        }
    }

    class MyAgressiveBehavior : IIBehavior
    {
        public void DisplayBehavior()
        {
            "Agressive Behavior".ConsoleExension();
        }
    }

    class MyRobot
    {
        private IIBehavior _behavior;
        public string Name;

        internal MyRobot(IIBehavior behavior, string name)
        {
            _behavior = behavior;
            Name = name;
        }

        internal void SetBehavior(IIBehavior behavior)
        {
            _behavior = behavior;
        }

        internal void GetBehavior()
        {
            _behavior.DisplayBehavior();
        }
    }

    #endregion Strategy

    #region Observer
    class ObserverP
    {
        //Kind of publish subcriber pattern, Observer subcribes to updates of the subject, When there is an update
        //subject publish the event to subscriber
        MySubject subject = new MySubject();

        MyObserver observer = new MyObserver();
        MyObserver observer2 = new MyObserver();


        internal ObserverP()
        {
            observer.name = "AObserver";
            subject.Subscribe(observer);

            observer2.name = "BObserver";
            subject.Subscribe(observer2);

            subject.State = "1";
            subject.Publish();

            subject.State = "2";
            subject.Publish();
        }

    }

    class MySubject
    {
       internal string State { get; set; }

        private List<IIObserver> _observer=new List<IIObserver>();

        internal void Subscribe(IIObserver observer)
        {
            ("Subcriber observerName"+observer.name).ConsoleExension();
            _observer.Add(observer);
        }

        internal void Publish()
        {
            foreach (var observerInstance in _observer)
            {
                
                observerInstance.Update(this.State);
            }
        }

    }

    interface IIObserver
    {
         string name { get; set; }

        void Update(string state);
    }

    class MyObserver : IIObserver
    {
        public string name { get; set; }

        public void Update(string state)
        {
            ("Update received for observer" + name).ConsoleExension();
            ("State Change Update recevied"+state).ConsoleExension();
        }
    }

    class MyClass
    {
         
    }
    #endregion Observer

    #region Command
    class CommandP
    {
        //It encapsulates request into an object, While it receives command, It does not know which action to perform
        //It uses encapsulated object to fullfill the request  
        internal CommandP()
        {
            IIReceiver receiver = new MyTvReceiver();
            IICommand command = new MyOnCommand(receiver);
            MyButtonInvoker invoker = new MyButtonInvoker(command);
            invoker.Invoke();

            receiver=new MyRadioReceiver();
            command = new MyOnCommand(receiver);
            invoker = new MyButtonInvoker(command);
            invoker.Invoke();

            
        }

    }

    interface IICommand
    {
        void Execute();
    }


    class MyOnCommand : IICommand
    {
        private IIReceiver _receiver;
        internal MyOnCommand(IIReceiver receiver)
        {
            _receiver = receiver;
        }
        public void Execute()
        {
            _receiver.On();
        }
    }

    class MyOffCommand : IICommand
    {
        private IIReceiver _receiver;
        internal MyOffCommand(IIReceiver receiver)
        {
            _receiver = receiver;
        }
        public void Execute()
        {
            _receiver.Off();
        }
    }

    interface IIReceiver
    {
        void On();

        void Off();
    }
    class MyTvReceiver : IIReceiver
    {
        public void On()
        {
            "TvOn".ConsoleExension();
        }

        public void Off()
        {
            "TvOff".ConsoleExension();
        }
    }

    class MyRadioReceiver : IIReceiver
    {
        public void On()
        {
            "RadioOn".ConsoleExension();
        }

        public void Off()
        {
            "RadioOff".ConsoleExension();
        }
    }

    class MyButtonInvoker
    {
        private IICommand _command;
        internal MyButtonInvoker(IICommand command)
        {
            _command = command;
        }

        internal void Invoke()
        {
            _command.Execute();

        }
    }

    #endregion Command

    #region BehavioralEnd

    #endregion BehavioralEnd

}
