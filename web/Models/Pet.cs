using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using web.Models.Enums;

namespace web.Models
{
    [Serializable]
    [Table("Pets", Schema = "lknight1")]
    public class Pet
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; private set; }
        public int AID { get; private set; }

        [Required] public string Name { get; set; }
        [Required] public string Breed { get; set; }

        public bool IsFriendly { get; set; }
        public PetLocation Location { get; set; }

        [ForeignKey("AID")]
        public virtual Assessment Assessment { get; set; }
    }
}