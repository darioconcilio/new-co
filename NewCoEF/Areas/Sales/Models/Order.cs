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
            Lines = new List<OrderLines>();
        }

        public Guid Id { get; set; }

        [Display(Name = "Nr. Ordine")]
        [Required]
        public string No { get; set; }

        [Display(Name = "Data Ordine")]
        [Required]
        public DateTime Date { get; set; }

        [Display(Name = "Cliente")]
        [Required]
        public Guid? CustomerId { get; set; }

        [Display(Name = "Cliente")]
        public Customer CustomerRef { get; set; }

        public List<OrderLines> Lines { get; set; }
    }
}
