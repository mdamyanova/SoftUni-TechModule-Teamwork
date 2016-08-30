namespace bYteMe.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Delivery
    {
        // TODO: Add validations
        public string FullName { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Phone { get; set; }

        public string Comment { get; set; }
    }
}