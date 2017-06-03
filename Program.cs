using System;
using System.Threading.Tasks;

namespace Sample01
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }
        public void Run()
        {
            Task<string> task3 = Task.Factory.StartNew<int>(() =>
            {
                int x = 1;
                Console.WriteLine("Task1: {0}", x);
                return x;   // int
            }).ContinueWith<double>((firstTask) =>
            {
                double x = firstTask.Result + 1.1;
                Console.WriteLine("Task2: {0}", x);
                return x;   // double
            }).ContinueWith<string>((secondTask) =>
            {
                string x = string.Format("{0}", secondTask.Result + 1);
                Console.WriteLine("Task3: {0}", x);
                return x;   // string
            });
            Console.WriteLine("end: {0}", task3.Result);
            Console.ReadLine();
        }
    }
}
