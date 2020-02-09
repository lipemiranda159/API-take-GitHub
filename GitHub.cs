using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Octokit;
using System.Threading.Tasks;
using System.Linq;

namespace MyBot
{
    class GitHub
    {

        const string api = "Github-API-Test";
        const string nameRepository = "takenet";

        public static async Task<List<Repository>> GetRepositories()
        {
            var client = new GitHubClient(new ProductHeaderValue(api));

            var contents = await client.Repository.GetAllForUser(nameRepository);
            var contentsList = contents.OrderBy(content => content.UpdatedAt);
            
            List<Repository> repositorio = new List<Repository>();

            foreach (var content in  contentsList)
            {
                Console.WriteLine(content.Language);
                if (content.Language == "C#" && repositorio.Count <5)
                {
                    var repo = new Repository(
                      content.FullName,
                      content.Description
                    );

                    repositorio.Add(repo);
                }
            }
            repositorio.OrderBy(repository => repository.Name);
            return repositorio;
        }

    }
    class Repository
    {
        private string _name;
        private string _description;

        public Repository(string name,string description)
        {
            _name = name;
            _description = description;

        }

        public string Name { get => _name;}
        public string Description { get => _description;}
    }
}
