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
        /// <returns> return list Repository for a takenet chatbot</returns>
      static List<Repository> Main(string[] args)
        {
             Task.Factory.StartNew(async () =>
            {
                 List <Repository> repo = await GitHub.GetRepositories();
                return repo;
            }).Wait();

            return null;

        }
    }
}