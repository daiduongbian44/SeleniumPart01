using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleThreadingExample.Tasks
{
    public class ProcessFuncDataTask : BaseTask
    {
        public int Data { get; set; }
        public Func<int, int> FuncChangeData { get; set; }

        public override void Run()
        {
            base.Run();
            var outputData = FuncChangeData?.Invoke(Data);
            Console.WriteLine(string.Format("Result of this task: {0}", outputData));
            Console.WriteLine("Done this task -------------");
        }
    }
}
