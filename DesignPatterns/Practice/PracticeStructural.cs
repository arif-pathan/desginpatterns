using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Practice
{
    class PracticeStructural
    {

        public PracticeStructural()
        {
            TestBehaviourPatterns();

        }

        #region testBehavioural
        private static void TestBehaviourPatterns()
        {
            TestIterator();
            TestCommand();
            TestStrategy();
            TestObserver();
        }

        private static void TestObserver()
        {
            Console.WriteLine("Test Observer");
            IObserverr observerr = new Observer("A");
            IObserverr observerr1 = new Observer("B");
            Subject s = new Subject();
            s.State = " State1 ";
            s.Subscribe(observerr);
            s.Subscribe(observerr1);

            s.Notify();

            s.State = " State2 ";
            s.Notify();
        }

        private static void TestStrategy()
        {
            Console.WriteLine("Test Strategy Behaviour");
            Robot robot = new Robot("Aggressive", new AgressiveBehaviour());

            robot.AboutSelf();

            Console.WriteLine("Using Mild behaviour for Agressive robot");
            robot.SetBehaviour(new MildBehaviour());
            robot.AboutSelf();
        }

        private static void TestCommand()
        {
            Console.WriteLine("Test Command Pattern");

            IReceiver receiver = new RadioReceiver();
            ICommand command = new OnCommand(receiver);
            ButtonInvoker invoker = new ButtonInvoker(command);

            invoker.Invoke();
        }

        private static void TestIterator()
        {
            Console.WriteLine("Aggregator Pattern Practice ");
            ConcreteAgregator a = new ConcreteAgregator();
            a[0] = 1;
            a[1] = 2;
            a[2] = 3;
            IItterator iteratorItterator = a.GetItterator();

            object current = iteratorItterator.Current();
            Console.WriteLine("Current " + current);
            object first = iteratorItterator.First();
            Console.WriteLine("first " + first);


            while (!iteratorItterator.Done())
            {
                object i = iteratorItterator.Next();
                Console.WriteLine(i);
            }
        }
        #endregion testBehavioural

        #region testStructural
        public void TestAdapter()
        { }

        public void TestDecorator()
        { }

        public void TestProxy()
        { }

        public void TestCompsite()
        { }

        public void TestFacade()
        { }

        public void TestBridge()
        { }

        public void TestFlyweight()
        { }
        #endregion testStructural

        #region  testCreational
        public void TestSingleton()
        { }

        public void TestPrototype()
        { }

        public void TestFactory()
        { }

        public void TestAbstractFactory()
        { }
        #endregion testCreational
    }

    #region Behavioural
    #region Iterator

    interface IItterator
    {
        object First();

        object Next();

        bool Done();

        object Current();
    }

    interface IAgregate
    {
        int Count();
        IItterator GetItterator();

        object this[int i] { get; set; }
    }

    class ConcreteAgregator : IAgregate
    {
        ArrayList arrayList=new ArrayList();
        
        public IItterator GetItterator()
        {
            return new ConcreteItterator(this);
        }

        public int Count()
        {
            return arrayList.Count;
        }

        public object this[int i]
        {
            get { return arrayList[i]; }
            set { arrayList.Add(value); }
        }
    }

    class ConcreteItterator : IItterator
    {
        private IAgregate _agregate;
        private int current = 0;
        public ConcreteItterator(IAgregate agregate)
        {
            _agregate = agregate;
        }
        public object First()
        {
           return  _agregate[0];
            
        }

        public object Next()
        {
            if (current < _agregate.Count())
            {
                current = current + 1;
            }
          return  _agregate[current];
        }

        public bool Done()
        {
            if (current >= _agregate.Count()-1)
            {
                return true;
            }
            return false;
        }

        public object Current()
        {
           return _agregate[current];
        }
    }

    #endregion Iterator

    #region Command

    interface ICommand
    {
        void Execute();
    }

    class OnCommand:ICommand
    {
        private IReceiver _receiver;

        public OnCommand(IReceiver receiver)
        {
            _receiver = receiver;
        }
        public void Execute()
        {
           _receiver.On();
        }
    }

    class OffCommand : ICommand
    {
        private IReceiver _receiver;

        public OffCommand(IReceiver receiver)
        {
            _receiver = receiver;
        }
        public void Execute()
        {
            _receiver.Off();
        }
    }

    interface IReceiver
    {
        void On();
        void Off();
    }

    class TVReceiver : IReceiver
    {
        public void On()
        {
            Console.WriteLine("TV on");
        }

        public void Off()
        {
            Console.WriteLine("TV off"); 
        }
    }

    class RadioReceiver : IReceiver
    {
        public void On()
        {
            Console.WriteLine("Radio on");
        }

        public void Off()
        {
            Console.WriteLine("Radio off");
        }
    }

    class ButtonInvoker
    {
        ICommand _command;

        public ButtonInvoker(ICommand command)
        {
            _command = command;
        }

        public void Invoke()
        {
            _command.Execute();
        }


    }


    #endregion Command

    #region Strategy

    interface IBehavviour
    {
        void GetBehaviour();
    }

    class AgressiveBehaviour : IBehavviour
    {
        public void GetBehaviour()
        {
            Console.WriteLine("Aggressive behaviour");
        }
    }

    class MildBehaviour : IBehavviour
    {
        public void GetBehaviour()
        {
            Console.WriteLine("Mild behaviour");
        }
    }

    class Robot
    {
        private IBehavviour _behavviour;
        private string _name;

        public Robot(string name, IBehavviour behavviour)
        {
            _behavviour = behavviour;
            _name = name;
        }

        public void SetBehaviour(IBehavviour behavviour)
        {
            _behavviour = behavviour;
        }

        public void AboutSelf()
        {
            Console.WriteLine("Robot Name is "+_name );
            _behavviour.GetBehaviour();

        }
    }

    #endregion Strategy

    #region Observer

    public class Subject
    {
        public string State;

        List<IObserverr> _observers = new List<IObserverr>();

        public void Subscribe(IObserverr observerr)
        {
            _observers.Add(observerr);
        }

        public void Notify()
        {
            foreach (var observerr in _observers)
            {
                observerr.Update(State);
            }
        }
    }

    public interface IObserverr
    {
        void Update(string state);
        string Name { get; set; }
    }

    public class Observer : IObserverr
    {
        public Observer(string name)
        {
            Name = name;
        }
        public void Update(string state)
        {
           Console.WriteLine("Received state{0} for observer{1}",state,Name);
        }

        public string Name { get; set; }
    }


    #endregion Observer
    #endregion Behavioural

    #region Structural


#endregion Structural
}
