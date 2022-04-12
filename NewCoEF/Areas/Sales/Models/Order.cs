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
        public Guid? CustomerRefId { get; set; }

        [Display(Name = "Cliente")]
        public Customer CustomerRef { get; set; }

        [Display(Name = "Importo Totale")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [DataType(DataType.Currency)]
        public double TotalAmount
        {
            get { return Lines.Sum(r => r.LineAmount); }
        }

        [Display(Name = "Nr. Righe")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int LinesCount
        {
            get { return Lines.Count; }
        }

        public List<OrderLines> Lines { get; set; }
    }
}
