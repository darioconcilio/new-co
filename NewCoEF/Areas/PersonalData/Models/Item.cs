using NewCoEF.Areas.Sales.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Areas.PersonalData.Models
{
    public partial class Item
    {
        public Item()
        {
            OrderLines = new HashSet<OrderLines>();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Inventory { get; set; }
        public string No { get; set; }

        public virtual ICollection<OrderLines> OrderLines { get; set; }
    }
}
