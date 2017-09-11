using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
    [Serializable]
    [Table("People", Schema = "lknight1")]
    public class Person
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; private set; }
        public int AID { get; private set; }

        [Required, Column("FName")]
        public string FirstName { get; set; }

        [Required, Column("LName")]
        public string LastName { get; set; }

        public string MiddleInitial { get; set; }
        public DateTime? DOB { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        [ForeignKey("AID")]
        public virtual Assessment Assessment { get; set; }
    }
}