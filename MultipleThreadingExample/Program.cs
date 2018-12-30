using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleThreadingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Đo thời gian chạy
            Stopwatch sw = Stopwatch.StartNew();

            var processor = new ExampleProcessor();
            processor.Run();

            // Vòng chạy kết thúc, thời gian chạy = thời gian tính + thời gian in ra màn hình
            sw.Stop();
            Console.WriteLine("Time taken: {0}ms", sw.Elapsed.TotalMilliseconds);
            Console.ReadKey();
        }
    }
}
