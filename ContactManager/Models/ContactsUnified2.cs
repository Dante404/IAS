using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactManager.Models
{
    public partial class ContattiDB2 : DbContext
    {
        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactsUni>().ToTable("ContactsUni");
            throw new UnintentionalCodeFirstException();
        }*/

        public System.Data.Entity.DbSet<ContactManager.Models.Contatti> Contatti { get; set; }
        public System.Data.Entity.DbSet<ContactManager.Models.ContactsUni2> ContactsUni2 { get; set; }
    }

    public partial class ContactsUni2
    {

        [Key, ForeignKey("Contatti")]
        public int ContattoID { get; set; }
        public List<Contatti> Contattis { get; set; }
        public List<Companies> Companies { get; set; }
        public List<Contact> Contacts { get; set; }
        public virtual Contatti Contatti { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual Companies Company { get; set; }
    }
}