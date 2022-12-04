using System;

namespace Sample1_Command
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reciver reciver = new Reciver();
            Command command = new ConcreteCommand(reciver);
            Invoker invoker = new Invoker();


            invoker.SetCommand(command);
            invoker.ExecuteCommand();

            Console.Read();
        }
    }
    public class Reciver
    {
        public void Action()
        {
            Console.WriteLine("Reciver.Action()   Run .......");
        }
    }

    public abstract class Command
    {
        protected Reciver reciver;
        public Command(Reciver reciver)
        {
            this.reciver = reciver;
        }
        public abstract void Execute();
    }


    public class ConcreteCommand : Command
    {
        public ConcreteCommand(Reciver reciver) : base(reciver)
        {

        }
        public override void Execute()
        {
            reciver.Action();
        }
    }
    public class Invoker
    {
        private Command command;
        public void SetCommand(Command command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            command.Execute();
        }
    }
}
