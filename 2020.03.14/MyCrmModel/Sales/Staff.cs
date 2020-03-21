
using System.Collections.Generic;

namespace MyCrmModel.Sales
{
    public class Staff
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool Active { get; set; }

        public virtual List<Order> Orders { get; set; }

        public virtual Store Store { get; set; }

        public int StoreId { get; set; }

        public int ManagerId { get; set; }
    }
}