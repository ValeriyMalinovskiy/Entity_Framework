using System.ComponentModel.DataAnnotations.Schema;

namespace StudentLibrary.DAL.Model
{
    public class Address
    {
        public virtual int Id { get; set; }

        public virtual string Country { get; set; }

        public virtual string City { get; set; }

        public virtual string LocalAddress { get; set; }

        public virtual int PostalCode { get; set; }

        public virtual Student Student { get; set; }

        public override string ToString()
        {
            return this.Country + ", " + this.City +", " + this.LocalAddress;
        }
    }
}
