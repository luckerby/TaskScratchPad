using System;
using System.Collections.Generic;
using System.Text;

namespace TaskScratchPad
{
    class Misc
    {
        //Console.WriteLine(await GetElidingKeywordAsync("https://www.google.com"));
        /*
        static public async Task<string> GetElidingKeywordAsync(string url)
        {
            using (var client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }

        static public Task<string> GetElidingKeywordSync(string url)
        {
            using (var client = new HttpClient())
            {
                return client.GetStringAsync(url);
            }
        }
        */

        /*
        private static void Debug<T>(T arg) =>
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] {arg}");
    
        static async Task<int> DelaySecondsAndReturnAsync(int seconds, CancellationToken token)
        {
            await Task.Delay(TimeSpan.FromSeconds(seconds), token);
            return seconds;
        }
        static async Task Main(string[] args)
        {
            await AwaitOnCancelledTask();
        }
        static async Task AwaitOnCancelledTask()
        {
            Debug("Start");
            using var cts = new CancellationTokenSource(2000);
            var task = DelaySecondsAndReturnAsync(4, cts.Token);
            Thread.Sleep(1000);

            try
            {
                var result = await task;
                Debug($"Done. Cancelled: {task.IsCanceled}");
                Debug($"Result: {result}");
            }
            catch
            {
                Debug($"Exception caught");
            }

        }
        */

        /*
        static async Task Main(string[] args)
        {
            string fileContent = await File.ReadAllTextAsync("TaskScratchPad.runtimeconfig.dev.json");
            Task task = SleepMethod();
            await task;
            Console.WriteLine(fileContent);
            Console.ReadKey();  // make sure the methods waits
        }


        static async Task SleepMethod()
        {
            Console.WriteLine("SleepMethod starts");
            await Task.Delay(1000);
            //string fileContent = await File.ReadAllTextAsync("myFile.txt");
            Console.WriteLine("SleepMethod ends");
        }
        */
    }
}
