using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleThreadingExample.Tasks
{
    public abstract class BaseTask : IRunable
    {
        public virtual void Run()
        {
            Console.WriteLine("Run the task with type: " + this.GetType().Name);
        }
    }
}
