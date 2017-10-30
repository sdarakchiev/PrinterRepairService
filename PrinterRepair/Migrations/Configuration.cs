using Newtonsoft.Json;
using PrinterRepairService.Models;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;

namespace PrinterRepair.Migrations
{


    internal sealed class Configuration : DbMigrationsConfiguration<PrinterRepair.Data.PrinterServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(PrinterRepair.Data.PrinterServiceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            using (StreamReader reader = new StreamReader(@"C:\Users\Lenovo\Documents\Visual Studio 2017\Projects\PrinterRepair/Users.json"))
            {
                string json = reader.ReadToEnd();
                IList<User> users = JsonConvert.DeserializeObject<IList<User>>(json);

                for (int i = 0; i < users.Count - 1; i++)
                {
                    User user = users[i];
                    if (!context.Users.Any(x => x.FirstName == user.FirstName))
                    {
                        context.Users.Add(user);

                    }
                    context.SaveChanges();
                }

            }
        }


    }
}
