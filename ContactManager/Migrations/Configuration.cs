namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ContactManager.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<ContactManager.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        bool AddUserAndRole(ContactManager.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "angelo@gmail.com",
            };
            ir = um.Create(user, "Testing1!");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }

        protected override void Seed(ContactManager.Models.ApplicationDbContext context)
        {
            AddUserAndRole(context);
            context.Contacts.AddOrUpdate(p => p.Name,
               new Contact
               {
                   Name = "Debra Garcia",
                   Address = "1234 Main St",
                   City = "Redmond",
                   State = "WA",
                   Zip = "10999",
                   Email = "debra@example.com",
                   CompanyId = 1,
               },
                new Contact
                {
                    Name = "Thorsten Weinrich",
                    Address = "5678 1st Ave W",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "thorsten@example.com",
                    CompanyId = 2,
                },
                new Contact
                {
                    Name = "Yuhong Li",
                    Address = "9012 State st",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "yuhong@example.com",
                    CompanyId = 1,
                },
                new Contact
                {
                    Name = "Jon Orton",
                    Address = "3456 Maple St",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "jon@example.com",
                    CompanyId = 3,
                },
                new Contact
                {
                    Name = "Diliana Alexieva-Bosseva",
                    Address = "7890 2nd Ave E",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "diliana@example.com",
                    CompanyId = 2,
                }
                );
                context.Companies.AddOrUpdate(p => p.CompanyName,
                new Companies
                {
                    CompanyName = "Microsoft",
                    CompanyAddress = "1234 Main St",
                    CompanyCity = "Redmond",
                    CompanyState = "WA",
                    CompanyZip = "10999",
                    CompanyId = 1,
                    CompanyArea = "IT",
                },
                new Companies
                {
                    CompanyName = "Google",
                    CompanyAddress = "5678 1st Ave W",
                    CompanyCity = "Redmond",
                    CompanyState = "WA",
                    CompanyZip = "10999",
                    CompanyId = 2,
                    CompanyArea = "IT",
                },
                new Companies
                {
                    CompanyName = "Millenium2",
                    CompanyAddress = "9012 State st",
                    CompanyCity = "Redmond",
                    CompanyState = "WA",
                    CompanyZip = "10999",
                    CompanyId = 4,
                    CompanyArea = "Banking",
                },
                new Companies
                {
                    CompanyName = "Millenium3",
                    CompanyAddress = "9012 State st",
                    CompanyCity = "Redmond",
                    CompanyState = "WA",
                    CompanyZip = "10999",
                    CompanyId = 5,
                    CompanyArea = "Banking",
                },
                new Companies
                {
                    CompanyName = "Millenium",
                    CompanyAddress = "9012 State st",
                    CompanyCity = "Redmond",
                    CompanyState = "WA",
                    CompanyZip = "10999",
                    CompanyId = 3,
                    CompanyArea = "Banking",
                }
                );
        }
    }
}
