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
            Lines = new List<OrderLine>();
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

        public List<OrderLine> Lines { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Importo Totale")]
        public double TotalAmount
        {
            get
            {
                return Lines.Sum(r => r.LineAmount); 
            }
        }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        [Display(Name = "Nr .Righe")]
        public int RowCount
        {
            get
            {
                return Lines.Count;
            }
        }
    }
}
