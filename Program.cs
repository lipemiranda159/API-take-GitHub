using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBot
{
    class Program
    {
        /// <summary>
        /// Is the main method, which starts the program, don't delete or modify. 
        /// </summary>
        /// 
        /// <returns> return int value for a takenet chatbot</returns>
        static int Main(string[] args)
        {
            Task.Factory.StartNew(async () =>
            {
                List<Repository> repo = await GitHub.GetRepositories();
                Console.WriteLine(repo.ToString());
            }).Wait();

            return Take.Blip.Client.Console.ConsoleRunner.RunAsync(args).GetAwaiter().GetResult();
        }
    }
}