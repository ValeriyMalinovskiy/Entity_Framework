using System.Collections.Generic;

namespace MyCrmModel.Sales
{
    internal class Staff
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool Active { get; set; }

        public ICollection<Order> Orders { get; set; }

        public Store Store { get; set; }

        public int StoreId { get; set; }

        public int ManagerId { get; set; }
    }
}
