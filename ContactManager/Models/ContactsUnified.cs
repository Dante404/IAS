using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    public partial class ContattiDB2 : DbContext
    {
        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactsUni>().ToTable("ContactsUni");
            throw new UnintentionalCodeFirstException();
        }*/

        public System.Data.Entity.DbSet<ContactManager.Models.Contatti> Contatti2 { get; set; }
        public System.Data.Entity.DbSet<ContactManager.Models.ContactsUni> ContactsUnis { get; set; }
    }

    public partial class ContactsUni
    {
        public ContactsUni()
        {
        }
        public DbSet<Contatti> Contattis { get; set; }
        public DbSet<Companies> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        [Key]
         public int ContactId { get; set; }
         public string Nome { get; set; }
         public string Via { get; set; }
         public string Citta { get; set; }
         public string Stato { get; set; }
         public string CodicePostale { get; set; }
         public string Email { get; set; }
         public string Zip { get; set; }
         public int CompanyId { get; set; }
         public string City { get; set; }
         public string State { get; set; }
     }

    }