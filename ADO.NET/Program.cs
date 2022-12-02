using AdoSamples.ConsoleUI;
using Microsoft.Data.SqlClient;
using System.Data;
using System;

namespace ADO.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sample1 _samples = new Sample1();
            _samples.SqlBulkCopySample();

            Console.ReadKey();
        }
    }
}
