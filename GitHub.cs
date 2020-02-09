using System.Collections.Generic;
using Octokit;
using System.Threading.Tasks;
using System.Linq;

namespace MyBot
{
    class GitHub
    {

        const string api = "Github-API-Test";
        const string nameRepository = "takenet";

        /// <summary>
        /// This method is asyncrony and return always a Task list about the takenet repository.
        /// </summary>
        /// <returns> Return  the  first five takenet repositories, in alphabetical order order. Of type list Task</returns>
        public static async Task<List<Repository>> GetRepositories()
        {
            // Creates a new instance with the GitHub API
            var client = new GitHubClient(new ProductHeaderValue(api));

            var contents = await client.Repository.GetAllForUser(nameRepository);
            // Receive the list ordered by the latest updates
            var contentsList = contents.OrderBy(content => content.UpdatedAt);
            
            List<Repository> repository = new List<Repository>();
            
            foreach (var content in  contentsList)
            {
                // Adds the contents of the 'C #' language to the return list and are the first
                if (content.Language == "C#" && repository.Count <5)
                {
                    var repo = new Repository(
                      content.FullName,
                      content.Description
                    );

                    repository.Add(repo);
                }
            }
            repository.OrderBy(repos => repos.Name);
            return repository;
        }

    }
    /// <summary>
    /// This class is of the dynamic type, to store the necessary data of repository  
    /// </summary>
    class Repository
    {
        private string _name;
        private string _description;

        /// <summary>
        /// This constructor receive the necessary data
        /// </summary>
        /// <param name="name">Full repository name </param>
        /// <param name="description">Description about repository</param>
        public Repository(string name,string description)
        {
            _name = name;
            _description = description;

        }

        public string Name { get => _name;}
        public string Description { get => _description;}
    }
}
