using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threeds_Parallels_ConsoleApp
{
    public class ThreadPoolWorker
    {
        private readonly Func<object, int> _action;

        public ThreadPoolWorker(Func<object, int> action)
        {
            _action = action ?? throw new ArgumentNullException();
        }

        public bool Success { get; private set; } = false;
        public bool IsComplete { get; private set; } = false;
        public object Result { get; private set; }


        public void Start(object state)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(Execute), state);
        }

        public void Wait()
        {
            Console.WriteLine($"Wait start in {Thread.CurrentThread.ManagedThreadId}");
            while (!IsComplete)
            {
                Thread.Sleep(150);
            }
        }

        private void Execute(object state)
        {
            try
            {
                Console.WriteLine($"Execute start in {Thread.CurrentThread.ManagedThreadId}");
                Result = _action.Invoke(state);
                Success = true;
            }
            catch (Exception ex)
            {
                Success = false;
            }
            finally
            {
                IsComplete = true;

            }
        }
    }
}
