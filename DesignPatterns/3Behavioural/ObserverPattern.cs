using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioural
{
    //http://www.dofactory.com/net/observer-design-pattern
    class ObserverPattern
    {
        public ObserverPattern()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("ObserverPattern is a behavioural pattern");
            stringBuilder.Append("\nDefine one to many dependency between objects so when one object changes " +
                                 "state all its dependants are notified and updated accordingly");
            stringBuilder.Append("Implementation has Subject with Observer class member" +
                                 " ConcreteSubject with state, abstract Observerclass abstract update  method and concrete observer");
            stringBuilder.Append("\n");
            stringBuilder.Append("");
            Console.WriteLine(stringBuilder);
            Program.PressEnterToContinue();


            ConcreteSubject s = new ConcreteSubject();
            s.State = "New";

            ConcreteObserver a = new ConcreteObserver(s,"A");
            ConcreteObserver b = new ConcreteObserver(s, "B");
            ConcreteObserver c = new ConcreteObserver(s, "C");

            
            s.subscribe(a);
            s.subscribe(b);
            s.subscribe(c);

            s.State = "Updated";
            s.Notify();

        }
    }

    class Subject
    {
        List<Observer>   _observers=new List<Observer>();

        public void subscribe(Observer observer)
        {
            Console.WriteLine("Adding Observer " + observer.Name);
            _observers.Add(observer);
        }

        public void RemoveSubscription(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                Console.WriteLine("Notifying observer " + observer.Name);
                observer.Update();
            }

        }

    }

    class ConcreteSubject:Subject
    {
        private string _state;
        public string State {
            get { return _state; }
            set
            {
                Console.WriteLine("Setting subject state to " + value);
                _state = value;
            }
        }
    }


    abstract class Observer
    {
        public abstract void Update();
        public string Name;
    }

    class ConcreteObserver:Observer
    {
        private ConcreteSubject _subject;
        
        public ConcreteObserver(ConcreteSubject subject,string name)
        {
            _subject = subject;
            Name = name;
        }


        public override void Update()
        {
           Console.WriteLine("Recieved Update status for observer " + Name +" with subject state "+ _subject.State);
        }
    }
}
