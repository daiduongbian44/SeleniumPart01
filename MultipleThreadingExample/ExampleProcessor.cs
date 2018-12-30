using MultipleThreadingExample.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultipleThreadingExample
{
    public class ExampleData
    {
        public int InputNumber { get; set; }
    }

    public class ExampleProcessor : IRunable
    {
        public ExampleData Data { get; set; }

        public void AddToData(int num)
        {
            lock(Data)
            {
                Data.InputNumber += num;
            }
        }

        public void Run()
        {
            var listTasks = new List<Task>();

            // Khởi tạo dữ liệu cần xử lý
            Data = new ExampleData()
            {
                InputNumber = 10
            };

            // Bắt đầu xử lý
            // Bắt đầu simple Task tại thời điểm 0
            var simpleWork = new SimpleTask()
            {
                Data = Data
            };
            Task taskSimple = Task.Factory.StartNew(simpleWork.Run);
            listTasks.Add(taskSimple);

            // Dừng 200ms
            Thread.Sleep(200);

            // Khởi tạo task xử lý dữ liệu
            var funcData01 = new ProcessFuncDataTask()
            {
                Data = Data.InputNumber,
                FuncChangeData = (input) =>
                {
                    Thread.Sleep(500);
                    var num = 12;
                    AddToData(num);
                    return Data.InputNumber;
                }
            };

            Task task01 = Task.Factory.StartNew(funcData01.Run);
            listTasks.Add(task01);

            // Dừng 200ms
            Thread.Sleep(200);

            var funcData02 = new ProcessFuncDataTask()
            {
                Data = Data.InputNumber,
                FuncChangeData = (input) =>
                {
                    Thread.Sleep(300);
                    var num = 101;
                    AddToData(num);
                    return Data.InputNumber;
                }
            };

            Task task02 = Task.Factory.StartNew(funcData02.Run);
            listTasks.Add(task02);

            // Chờ đợi tất cả các tasks thực hiện xong
            Task.WaitAll(listTasks.ToArray());

            Console.WriteLine("Latest result: ");
            Console.WriteLine(JsonConvert.SerializeObject(Data));
        }
    }
}
