using System;

namespace ImplementationPrototype
{
    class Program
    {
        static void Main(string[] args)
        {

            ConcreatePrototy1 Service1 = new ConcreatePrototy1(1500, "test");
            ConcreatePrototy1 Service2 = (ConcreatePrototy1)Service1.Clone();
            Console.WriteLine(Service1.Property1);
            Console.WriteLine(Service2.Property1);
            Console.WriteLine(Service1 == Service2);

            ConcreateProtorype2 serviceComplex1 = new ConcreateProtorype2(Service1);
            var serviceComplex2 = (ConcreateProtorype2)serviceComplex1.Clone();
            Console.WriteLine(serviceComplex1.myApplicationService.Property2);
            Console.WriteLine(serviceComplex2.myApplicationService.Property1);
            Console.WriteLine(serviceComplex1 == serviceComplex2);
            Console.WriteLine(serviceComplex1 == serviceComplex1);



            Console.ReadLine();

            Console.WriteLine("Hello World!");
        }
    }


    public interface IPrototype
    {
        IPrototype Clone();
    }


    public class ConcreatePrototy1 : IPrototype
    {
        public int Property1 { get; set; }
        public string Property2 { get; set; }
        public ConcreatePrototy1(int property1, string property2)
        {
            Property1 = property1;
            Property2 = property2;
        }

        public IPrototype Clone()
        {
            return (IPrototype)this.MemberwiseClone();
        }
    }

    public class ConcreateProtorype2 : IPrototype
    {
        public ConcreatePrototy1 myApplicationService { get; set; }


        public ConcreateProtorype2(ConcreatePrototy1 myApplicationService)
        {
            this.myApplicationService = myApplicationService;
        }
        public IPrototype Clone()
        {
            var result = (ConcreateProtorype2)this.MemberwiseClone();
            result.myApplicationService = (ConcreatePrototy1)this.myApplicationService.Clone();
            return (IPrototype)result;
        }
    }

}
