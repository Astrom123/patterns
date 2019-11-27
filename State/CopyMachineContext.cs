using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    public class CopyMachineContext
    {
        public IState State { get; set; }
        public int Money { get; set; }
        public string Device { get; set; }
        public string FileName { get; set; }
        public readonly int Cost = 10;

        public CopyMachineContext()
        {
            State = new InitState();
        }

        public void GetChange()
        {
            State.GetChange(this);
        }

        public void Print()
        {
            State.Print(this);
        }

        public void PrintMore(bool printMore)
        {
            State.PrintMore(this, printMore);
        }

        public void PutMoney(int money)
        {
            State.PutMoney(this, money);
        }

        public void SelectDevice(string device)
        {
            State.SelectDevice(this, device);
        }

        public void SelectFile(string fileName)
        {
            State.SelectFile(this, fileName);
        }
    }

    public interface IState
    {
        void PutMoney(CopyMachineContext context, int money);
        void SelectDevice(CopyMachineContext context, string device);
        void SelectFile(CopyMachineContext context, string fileName);
        void Print(CopyMachineContext context);
        void PrintMore(CopyMachineContext context, bool printMore);
        void GetChange(CopyMachineContext context);
    }

    public abstract class StateBase : IState
    {
        public virtual void GetChange(CopyMachineContext context)
        {
            Console.WriteLine("Wrong Operation");
        }

        public virtual void Print(CopyMachineContext context)
        {
            Console.WriteLine("Wrong Operation");
        }

        public virtual void PrintMore(CopyMachineContext context, bool printMore)
        {
            Console.WriteLine("Wrong Operation");
        }

        public virtual void PutMoney(CopyMachineContext context, int money)
        {
            Console.WriteLine("Wrong Operation");
        }

        public virtual void SelectDevice(CopyMachineContext context, string device)
        {
            Console.WriteLine("Wrong Operation");
        }

        public virtual void SelectFile(CopyMachineContext context, string fileName)
        {
            Console.WriteLine("Wrong Operation");
        }
    }

    public class InitState : StateBase
    {
        public override void PutMoney(CopyMachineContext context, int money)
        {
            context.Money = money;
            context.State = new SelectDeviceState();
        }
    }

    public class SelectDeviceState : StateBase
    {
        public override void SelectDevice(CopyMachineContext context, string device)
        {
            context.Device = device;
            context.State = new SelectFileState();
        }
    }

    public class SelectFileState : StateBase
    {
        public override void SelectFile(CopyMachineContext context, string fileName)
        {
            context.FileName = fileName;
            context.State = new PrintState();
        }
    }

    public class PrintState : StateBase
    {
        public override void Print(CopyMachineContext context)
        {
            if (context.Money - context.Cost < 0)
            {
                Console.WriteLine("Not enough money");
                context.State = new GetChangeState();;
            }
            else
            {
                Console.WriteLine($"Printing {context.FileName} from {context.Device}...");
                context.Money -= context.Cost;
                context.State = new PrintMoreState();
            }
        }
    }

    public class PrintMoreState : StateBase
    {
        public override void PrintMore(CopyMachineContext context, bool printMore)
        {
            if (printMore)
                context.State = new SelectFileState();
            else
                context.State = new GetChangeState();
        }
    }

    public class GetChangeState : StateBase
    {
        public override void GetChange(CopyMachineContext context)
        {
            Console.WriteLine($"Your change is {context.Money}");
            context.Money = 0;
            context.State = new InitState();
        }
    }
}