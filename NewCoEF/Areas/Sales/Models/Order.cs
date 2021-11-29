using NewCoEF.Areas.PersonalData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Areas.Sales.Models
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid();
            Lines = new HashSet<OrderLine>();
        }

        public Guid Id { get; set; }

        [Display(Name = "Nr. Ordine")]
        [Required]
        public string No { get; set; }

        [Display(Name = "Data Ordine")]
        [Required]
        public DateTime Date { get; set; }

        public ICollection<OrderLine> Lines { get; set; }

        public Customer CustomerRef { get; set; }

    }
}
