using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultipleThreadingExample.Tasks
{
    public class SimpleTask : BaseTask
    {
        public object Data { get; set; }
        
        public override void Run()
        {
            base.Run();
            if(Data != null)
            {
                Console.WriteLine("Process data: ");
                //Thread.Sleep(500);
                Console.WriteLine(JsonConvert.SerializeObject(Data));
            }
            Console.WriteLine("Done this task -------------");
        }
    }
}
