using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace web.Models
{
    [ComplexType]
    public class Address
    {
        [Column("Address1")] public string Address1 { get; set; }
        [Column("Address2")] public string Address2 { get; set; }
        [Column("City")] public string City { get; set; }
        [Column("State")] public string State { get; set; }
        [Column("ZipCode"), Display(Name = "Zip Code")] public string ZipCode { get; set; }
        [NotMapped] public string CountryCode { get; set; }

        public bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(Address1) && !string.IsNullOrEmpty(City) && !string.IsNullOrEmpty(State);
            }
        }
    }
}