using System;

namespace Sample_Memento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Originator originator = new Originator();
            originator.State = "Green";
            Caretaker caretaker = new Caretaker();
            caretaker.Memento = originator.CreateMemento();
            originator.State = "Red";
            originator.State = "Blue ";
            originator.State = "Yellow";

            originator.SetMemento(caretaker.Memento);

            Console.Read();
        }
    }

    public class Originator
    {
        string state;
        public string State
        {
            get { return state; }
            set
            {
                state = value;
                Console.WriteLine($"State={state}");
            }
        }

        public Memento CreateMemento()
        {
            Console.WriteLine("Saving state......");
            return (new Memento(state));
        }

        public void SetMemento(Memento memento)
        {
            Console.WriteLine("Restoring state...");
            State = memento.State;
        }
    }


    public class Memento
    {
        string state;
        public Memento(string state)
        {
            this.state = state;
        }

        public string State
        {
            get { return state; }
        }
    }

    public class Caretaker
    {
        Memento memento;
        public Memento Memento
        {
            get { return memento; }
            set
            {
                memento = value;
                Console.WriteLine("Caretaker Set Memento...");
            }
        }
    }

}
