using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational
{
    class AbstractFactoryPattern
    {

        public AbstractFactoryPattern()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\nAbstract Factory pattern" +
                                 "\nProvide an interface for creating families of related or dependent objects without specifying their concrete classes.");
            stringBuilder.Append("\nObeys open close principal - no need to change any configuration if new configuration arrives");
            stringBuilder.Append("\nSingle Responsibility - No need to change High end configuration if Low end changes");
            stringBuilder.Append("\nComposition - AssembleMachine");
            stringBuilder.Append("\nDependency Injection");
            stringBuilder.Append("\n");
            Console.WriteLine(stringBuilder);

            IMachineFactory machine = new HighEndMachine();
            Getmachine(machine);

            Program.PressEnterToContinue();

            machine = new LowEndMachine();
            Getmachine(machine);

            Program.PressEnterToContinue();

            machine = new VeryHighEndMachine();
           Getmachine(machine);
        }

        public void Getmachine(IMachineFactory machineFactory)
        {
            
           ComputerShop s = new ComputerShop(machineFactory);
            s.AssembleMachine();
        }
    }

    public interface IRam
    {
        void Process();
    }

    public interface IHardDisk
    {
        void StoreData();
    }

    public interface IProcessor
    {
        void PerformOperation();
    }

    class LowRam : IRam
    {
        public void Process()
        {
            Console.WriteLine("low ram");
        }
    }

    class HighRam : IRam
    {
        public void Process()
        {
            Console.WriteLine("high ram");
        }
    }

    class VeryHighRam : IRam
    {
        public void Process()
        {
            Console.WriteLine("very high ram");
        }
    }

    class LowHardDisk : IHardDisk
    {
        public void StoreData()
        {
            Console.WriteLine("low harddisk");
        }
    }

    class HighHardDisk : IHardDisk
    {
        public void StoreData()
        {
            Console.WriteLine("high harddisk");
        }
    }

    class VeryHighHardDisk : IHardDisk
    {
        public void StoreData()
        {
            Console.WriteLine("very high harddisk");
        }
    }

    class LowProcessor : IProcessor
    {
        public void PerformOperation()
        {
            Console.WriteLine("low processor");
        }
    }

    class HighProcessor : IProcessor
    {
        public void PerformOperation()
        {
            Console.WriteLine("high processor");
        }
    }



    public interface IMachineFactory
   {
       IProcessor GetProcessor();
        IHardDisk GetHardDisk();
        IRam GetRam();

    }

    class HighEndMachine : IMachineFactory
    {
        public IProcessor GetProcessor()
        {
            return new HighProcessor();
        }

        public IHardDisk GetHardDisk()
        {
            return new HighHardDisk();
        }

        public IRam GetRam()
        {
            return  new HighRam();
        }
    }

    class VeryHighEndMachine : IMachineFactory
    {
        public IProcessor GetProcessor()
        {
            return new HighProcessor();
        }

        public IHardDisk GetHardDisk()
        {
            return new VeryHighHardDisk();
        }

        public IRam GetRam()
        {
            return new VeryHighRam();
        }
    }

    class LowEndMachine : IMachineFactory
    {
        public IProcessor GetProcessor()
        {
            return new LowProcessor();
        }

        public IHardDisk GetHardDisk()
        {
            return new LowHardDisk();
        }

        public IRam GetRam()
        {
            return new LowRam();
        }
    }


    public class ComputerShop
    {
        IMachineFactory _machine;

        public ComputerShop(IMachineFactory machine)
        {
            _machine = machine;
        }

        public IMachineFactory AssembleMachine()
        {
            _machine.GetHardDisk();
            _machine.GetProcessor();
            _machine.GetRam();

            _machine.GetHardDisk().StoreData();
            _machine.GetProcessor().PerformOperation();
            _machine.GetRam().Process();

            return _machine;
        }

    }

}
