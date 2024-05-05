using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioural
{
    class StrategyPattern
    {
        //Implementation
        //Strategy - defines an interface 
        //common to all supported algorithms. Context uses this interface to call the algorithm defined by a ConcreteStrategy.
        //ConcreteStrategy - each concrete strategy implements an algorithm.
        //Context-The Context objects contains a reference to the ConcreteStrategy that should be used,
        //The Context is not aware of the strategy implementation
        //If necessary, addition objects can be defined to pass data from context object to strategy

        //Dependency Injection : High level modules should not depend on low level modules both should depend on abstractions
        //Extracting dependencies into interfaces and providing implementations of these interfaces as parameters is also an 
        //example of the Strategy design pattern.

        public StrategyPattern()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("There are common situations when classes differ only in their behavior");
            stringBuilder.Append("\n");
            stringBuilder.Append("For this cases is a good idea to isolate the algorithms in separate classes in order to have " +
                                 "the ability to select different algorithms at runtime.");
            stringBuilder.Append("\n");
            stringBuilder.Append("Define a family of algorithms, encapsulate each one, and make them interchangeable.");
            stringBuilder.Append("\n");
            stringBuilder.Append("Strategy lets the algorithm vary independently from clients that use it.");
            stringBuilder.Append("\n");

           
           stringBuilder.Append("\n");
            Console.WriteLine(stringBuilder);
            Program.PressEnterToContinue();

            //In this its simple strategy pattern, Here client needs to be aware of the concrete strategy AgressiveBehaviour
            Robot r1 = new Robot("Agressive");
            Robot r2 = new Robot("Mild");
            

            r1.setBehaviour(new AgressiveBehaviour());
            Console.WriteLine("\nr1 Agressive");
            r1.moveCommand();
            r2.setBehaviour(new MildBehaviour());
            Console.WriteLine("\nr2 Mild");
            r2.moveCommand();


            Console.WriteLine("\n/***  Change Behaviours by interchangeable ones  ***/");
            Program.PressEnterToContinue();

            Console.WriteLine("\nr1 Mild");
            r1.setBehaviour(new MildBehaviour());
            r1.moveCommand();

            Console.WriteLine("\nr2 Agressive");
            r2.setBehaviour(new AgressiveBehaviour());
            
            r2.moveCommand();

            Console.WriteLine("\n\n/**      **/");
            Program.PressEnterToContinue();

            #region Strategy with factory
                //In this its a mix of factory and strategy pattern, Here client is not aware of the concrete strategy, It use int or string and 
                //does the task with interface instead of concrete strategy class
                stringBuilder = new StringBuilder();
                stringBuilder.Append("In the classic implementation of the pattern the client should be aware of the strategy concrete classes.");
                stringBuilder.Append("\n");
                stringBuilder.Append("In order to decouple the client class from strategy classes is possible to use a " +
                                     "factory class inside the context object to create the strategy object to be used");
                stringBuilder.Append("\n");
                stringBuilder.Append("By doing so the client has only to send a parameter(like a string) to the " +
                                     "context asking to use a specific algorithm, being totally decoupled of strategy classes.");
                stringBuilder.Append("\n");
                Console.WriteLine(stringBuilder);

                IBehaviour behaviour = new Robot().GetBehaviourInstance(1);
                behaviour.moveCommand();
            #endregion Strategy with factory

        }
    }


    interface IBehaviour
    {
        int moveCommand();
    }

    class Robot 
    {
        private IBehaviour _behaviour;
        private String _name;
        private int _option;

        public Robot()
        { }

        public Robot(string name)
        {
            _name = name;
        }

        
        public void moveCommand()
        {
            _behaviour.moveCommand();
        }

        public void setBehaviour(IBehaviour behaviour)
        {
            _behaviour = behaviour;
        }

        public IBehaviour GetBehaviourInstance(int option)
        {
            //Using factory with strategy pattern start
            IBehaviour behaviourInstance = null;

            switch (option)
            {
                case 1:
                    behaviourInstance = new AgressiveBehaviour();
                    break;

                case 2:
                    behaviourInstance = new MildBehaviour();
                    break;

                default:
                    Console.WriteLine("Wrong choice");
                    break;
            }

            return behaviourInstance;
        }


    }

    class AgressiveBehaviour:IBehaviour
    {
        public int moveCommand()
        {
            Console.WriteLine("Agressive Behaviour");
            return 2;
        }
    }

    class MildBehaviour : IBehaviour
    {
        public int moveCommand()
        {
            Console.WriteLine("Mild Behaviour");
            return 3;
        }
    }
}























