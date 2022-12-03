using System;
using System.Collections.Generic;

namespace Composite_Computer_Sample_Example2
{
    public class Example2
    {
       public static void Method2()
        {
            IComponent hardDisk = new Leaf("Hard Disk", 100000);
            IComponent ram = new Leaf("RAM", 100000);
            IComponent cpu = new Leaf("CPU", 200000);
            IComponent mouse = new Leaf("Mouse", 50000);
            IComponent keyboard = new Leaf("Keyboard", 50000);
            IComponent Monitor = new Leaf("Monitor", 400000);

            Composite motherBoard = new Composite("MotherBoard", 100000);
            Composite Case = new Composite("Case", 70000);
            Composite peripherals = new Composite("Peripherals", 0);
            Composite computer = new Composite("Computer", 0);


            motherBoard.AddComponent(cpu);
            motherBoard.AddComponent(ram);


            Case.AddComponent(motherBoard);
            Case.AddComponent(hardDisk);


            peripherals.AddComponent(mouse);
            peripherals.AddComponent(keyboard);

            computer.AddComponent(Case);
            computer.AddComponent(peripherals);
            computer.AddComponent(Monitor);

            computer.DisplayPrice();
            Console.Read();

        }
    }

    public interface IComponent
    {
        string Name { get; set; }
        int Price { get; set; }
        int DisplayPrice();
    }

    public class Leaf : IComponent
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Leaf(string name, int price)
        {
            this.Price = price;
            this.Name = name;
        }
        public int DisplayPrice()
        {
            Console.WriteLine(Name + " : " + Price);
            return Price;
        }
    }
    public class Composite : IComponent
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Composite(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }
        List<IComponent> components = new List<IComponent>();

        public void AddComponent(IComponent component)
        {
            components.Add(component);
        }

        public int DisplayPrice()
        {
            int sumPrice = Price;

            foreach (var item in components)
            {
                sumPrice += item.DisplayPrice();
            }
            Console.WriteLine(Name + " : " + sumPrice);
            return sumPrice;
        }
    }
}
