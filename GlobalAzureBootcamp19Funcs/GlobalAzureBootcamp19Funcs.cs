using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GlobalAzureBootcamp19Funcs
{
    public static class GlobalAzureBootcamp19Funcs
    {
        [FunctionName("GetMonkeys")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string filter = req.Query["filter"];
            if (!string.IsNullOrEmpty(filter) && filter.ToLower() == "monkey")
            {
                var list = new List<Person>
                {
                    new Person{Name = "Rodrigo", Avatar = "https://loremflickr.com/320/240/monkey?random=0"},
                    new Person{Name = "Lucas", Avatar = "https://loremflickr.com/320/240/monkey?random=0"},
                    new Person{Name = "Álvaro", Avatar = "https://loremflickr.com/320/240/monkey?random=0"},
                    new Person{Name = "Gerson", Avatar = "https://loremflickr.com/320/240/monkey?random=0"},
                    new Person{Name = "Rogério", Avatar = "https://loremflickr.com/320/240/monkey?random=0"}

                };
                var data = JsonConvert.SerializeObject(list);
                return (ActionResult)new OkObjectResult(data);
            }
            else
            {
                return (ActionResult)new BadRequestObjectResult("Não foram encontrados registros para a sua busca");

            }
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
    }
}
