using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Take.Blip.Client.Console;

namespace MyBot
{
    class Program
    {
        static int Main(string[] args)
        {
            Task.Factory.StartNew(async () =>
            { 
                List<Repository> repo = await GitHub.GetRepositories();
                Console.WriteLine(repo.ToString());
            }).Wait();
    
            return ConsoleRunner.RunAsync(args).GetAwaiter().GetResult();

        }

  
    }
}