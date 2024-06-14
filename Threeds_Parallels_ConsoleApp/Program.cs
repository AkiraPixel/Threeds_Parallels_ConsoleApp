namespace Threeds_Parallels_ConsoleApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine($"Method Main Thread ID - {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("Please press any key...");
            Console.ReadKey();



            ThreadPoolWorker threadPoolWorker = new ThreadPoolWorker(PrintChar);

            threadPoolWorker.Start('*');

            threadPoolWorker.Wait();

            // получение результата
            if (threadPoolWorker.Success is true)
            {
                Console.WriteLine();
                Console.WriteLine((int)threadPoolWorker.Result);
            }


        }

        #region MyRegion
 
        /*
                private static void Example1(object state)
                {
                    Console.WriteLine($"Method Example1 begean work in Thread ID - {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(2000);
                    Console.WriteLine($"Method Example1 end work in Thread ID - {Thread.CurrentThread.ManagedThreadId}");
                }

                private static void Example2(object state)
                {
                    Console.WriteLine($"Method Example2 begean work in Thread ID - {Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Method Example2 end work in Thread ID - {Thread.CurrentThread.ManagedThreadId}");
                }

                private static void Report()
                {
                    ThreadPool.GetMaxThreads(out int maxWorkThreads, out int maxPortThreads);
                    ThreadPool.GetAvailableThreads(out int workThreads, out int portThreads);

                    Console.WriteLine($"work thread {workThreads} from {maxWorkThreads}");
                    Console.WriteLine(new string('-', 80));
                }*/

        #endregion
        private static int PrintChar(object arg)
        {
            Console.WriteLine($"Current thread Id: ${Thread.CurrentThread.ManagedThreadId}");
            char item = (char)arg;
            for (int i = 0; i < 8; i++)
            {
                Console.Write(item);
                Thread.Sleep(1000);
            }

            return 5;
        }
    }
}

