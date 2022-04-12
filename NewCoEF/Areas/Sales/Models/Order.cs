using NewCoEF.Areas.PersonalData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Areas.Sales.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderLines = new HashSet<OrderLines>();
        }

        public Guid Id { get; set; }
        public string No { get; set; }
        public DateTime Date { get; set; }
        public Guid? CustomerRefId { get; set; }

        public virtual Customer CustomerRef { get; set; }
        public virtual ICollection<OrderLines> OrderLines { get; set; }
    }
}
