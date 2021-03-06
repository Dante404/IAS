﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ContactManager.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<ContactManager.Models.Contact> Contacts { get; set; }

        public System.Data.Entity.DbSet<ContactManager.Models.Companies> Companies { get; set; }

        public System.Data.Entity.DbSet<ContactManager.Models.ContactsUni> ContactsUnis { get; set; }

        public System.Data.Entity.DbSet<ContactManager.Models.ContactsUni2> ContactsUni2 { get; set; }

        public System.Data.Entity.DbSet<ContactManager.Models.Contatti> Contattis { get; set; }

        public System.Data.Entity.DbSet<ContactManager.ViewModels.ContactsUni3> ContactsUni3 { get; set; }
    }
}