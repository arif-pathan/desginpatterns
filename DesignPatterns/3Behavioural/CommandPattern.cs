using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioural
{
    //http://javapapers.com/design-patterns/command-design-pattern/
    //http://www.dofactory.com/net/command-design-pattern
        
    class CommandPattern
    {
     public CommandPattern()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\nCommand Design pattern" +
                                 "\nUsed to encapsulate request into an object and pass to invoker");
            stringBuilder.Append("\nInvoker does not how know to service the request but uses the encapsulated command to perform action ");

            stringBuilder.Append("\n");
            Console.WriteLine(stringBuilder);

 
            Program.PressEnterToContinue();

            //Change to TV the reciver and TV commands will be fired

            IReceiver receiver = new Radio();

            ICommand cmd = new OnCommand(receiver);

            ButtonCommandInvoker invoker = new ButtonCommandInvoker(cmd);

            invoker.Invoke();

        }

    }

    class ButtonCommandInvoker
    {
        ICommand _command;
        public ButtonCommandInvoker(ICommand command)
        {
            _command = command;
        }

        public void Invoke()
        {
            _command.Execute();
        }
    
    }

    interface IReceiver
    {
        void On();
        void Off();
    }

    class TV : IReceiver
    {
        
 
        public void Off()
        {
            Console.WriteLine("Command off recvied at receiver of TV");
        }

        public void On()
        {
            Console.WriteLine("Command on recvied at receiver of TV");
        }

   
    }

    class Radio : IReceiver
    {
        public void Off()
        {
            Console.WriteLine("Command off recvied at receiver of radio");
        }

        public void On()
        {
            Console.WriteLine("Command on recvied at receiver of radio");
        }

    }


    interface ICommand
    {
        void Execute();
    }

    class OnCommand : ICommand
    {
        IReceiver _receiver;

        public OnCommand(IReceiver reciver)
        {
            _receiver = reciver;
        }

        public void Execute()
        {
            Console.WriteLine("Turn on Command");
            _receiver.On();
            
        }
    }

    class OffCommand : ICommand
    {
        IReceiver _receiver;

        public OffCommand(IReceiver reciver)
        {
            _receiver = reciver;
        }
        public void Execute()
        {
            Console.WriteLine("TV Turn off Command");
            _receiver.Off();
            
        }
    }

}
