using assignments_api.Models;
using JsonNet.PrivateSettersContractResolvers;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace assignments_api.Persistence
{
    public class Seeding
    {
    public static void Seed(string jsonData,
                            IServiceProvider serviceProvider)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new PrivateSetterContractResolver()
            };
            List<Assignment> assignments =
             JsonConvert.DeserializeObject<List<Assignment>>(
               jsonData, settings);
            using (
             var serviceScope = serviceProvider
               .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope
                              .ServiceProvider.GetService<AssignmentDbContext>();
                if (!context.Assignments.Any())
                {
                    context.AddRange(assignments);
                    context.SaveChanges();
                }
            }
        } 
    }
}