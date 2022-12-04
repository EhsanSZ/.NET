using System;
using System.Collections.Generic;

namespace Implementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConcreteSubject concreteSubject = new ConcreteSubject();
            concreteSubject.Attach(new ConcreteObserver("observer 1", concreteSubject));
            concreteSubject.Attach(new ConcreteObserver("observer 2", concreteSubject));
            concreteSubject.Attach(new ConcreteObserver("observer 3", concreteSubject));

            var observer4 = new ConcreteObserver("observer 4", concreteSubject);
            concreteSubject.Attach(observer4);


            //اعمال تغییرات
            concreteSubject.SubjectState = "test Ehsan";
            concreteSubject.Notify();

            Console.WriteLine("---------------------------------------");
            concreteSubject.Detach(observer4);
            concreteSubject.SubjectState = "Test";
            concreteSubject.Notify();
            Console.Read();
        }
    }

    public abstract class Observer
    {
        public abstract void Update();
    }

    public abstract class Subject
    {
        private List<Observer> observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var item in observers)
            {
                item.Update();
            }
        }

    }

    public class ConcreteSubject : Subject
    {
        public string SubjectState { get; set; }
    }


    public class ConcreteObserver : Observer
    {

        public string Name { get; set; }
        private string observerState { get; set; }
        public ConcreteSubject concreteSubject { get; set; }
        public ConcreteObserver(string Name, ConcreteSubject concreteSubject)
        {
            this.Name = Name;
            this.concreteSubject = concreteSubject;
        }

        public override void Update()
        {
            observerState = concreteSubject.SubjectState;
            Console.WriteLine($"{Name} : observerState update = {concreteSubject.SubjectState} ");
        }
    }
}
