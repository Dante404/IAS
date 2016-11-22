using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Collections.Generic;
namespace ContactManager.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [ForeignKey("Companies")]
        public int CompanyId { get; set; }
        [ForeignKey("Contatti")]
        public int ContattoID { get; set; }
        public virtual ICollection<Companies> Companies { get; set; }
        [Required]
        //public virtual Contatti Contatti { get; set; }
        public virtual ICollection<Contatti> Contatti { get; set; }
    }
}