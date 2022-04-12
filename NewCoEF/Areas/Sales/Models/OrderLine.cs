using NewCoEF.Areas.PersonalData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Areas.Sales.Models
{
    public partial class OrderLines
    {
        public Guid OrderId { get; set; }
        public Guid Id { get; set; }
        public int LineNo { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineAmount { get; set; }
        public Guid? ItemRefId { get; set; }

        public virtual Item ItemRef { get; set; }
        public virtual Order Order { get; set; }
    }
}
