using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using ExtensionTests;


namespace TaskScratchPad
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task<int>> taskList = new List<Task<int>>();
            taskList.Add(SpawnTaskFromNumber(2000));
            Thread.Sleep(100);
            taskList.Add(SpawnTaskFromNumber(1000));
            Thread.Sleep(100);
            taskList.Add(SpawnTaskFromNumber(5000));
            Thread.Sleep(100);
            taskList.Add(SpawnTaskFromNumber(3000));
            Thread.Sleep(100);
            taskList.Add(SpawnTaskFromNumber(4000));

            // Give it a while so that 2 of the tasks complete
            Thread.Sleep(2500);

            // Instantiate a new List of Tasks based on the extension method. From
            //  this moment on, it looks like the tasks are magically ordered in the
            //  list as they get completed
            List<Task<int>> newTaskList = new List<Task<int>>(taskList.InCompletionOrder());

            foreach(Task<int> task in newTaskList)
            {
                Console.WriteLine($"On thread id {Thread.CurrentThread.ManagedThreadId}, waiting on task with id {task.Id}");
                task.Wait();
                Console.WriteLine(task.Result);
            }

            Console.WriteLine("done");
        }

        public static Task<int> SpawnTaskFromNumber(int ms)
        {
            // Task.Run only takes an Action as parameter, which means in turn that no parameters are allowed
            //  Alternatives are 1. using lambdas or 2. using the Task constructor, then starting the task.
            //  We're using the latter option below
            Task<int> task = new Task<int>(MyMethod, (object)ms);
            task.Start();
            Console.WriteLine($"Created&started task with id {task.Id} for {ms}");
            return task;
        }

        static int MyMethod(object delayInMs)
        {
            Console.WriteLine($"Starting to wait on thread {Thread.CurrentThread.ManagedThreadId} for {delayInMs} ms");
            Task.Delay((int)delayInMs).Wait();
            Console.WriteLine($"Completed wait on thread {Thread.CurrentThread.ManagedThreadId} for {delayInMs} ms");
            return (int)delayInMs;
        }
    }
}
