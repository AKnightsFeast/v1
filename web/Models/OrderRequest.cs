using web.Models.Enums;

namespace web.Models
{
    public class OrderRequest
    {
        public MealsServiceType OrderType { get; set; }

        public PaymentToken PaymentToken { get; set; }

        public ShippingAddress ShippingAddress { get; set; }
    }

    public class PaymentToken
    {
        public string Id { get; set; }
    }

    public class ShippingAddress
    {
        public string Email { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
    }

    public class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
    }

    //public class Address
    //{
    //    public string AddressLine1
    //    {
    //        get;
    //        set;
    //    }
    //    public string AddressLine2
    //    {
    //        get;
    //        set;
    //    }
    //    public string AdminArea2
    //    {
    //        get;
    //        set;
    //    }
    //    public string AdminArea1
    //    {
    //        get;
    //        set;
    //    }
    //    public string PostalCode
    //    {
    //        get;
    //        set;
    //    }
    //    public string CountryCode
    //    {
    //        get;
    //        set;
    //    }
    //}
}