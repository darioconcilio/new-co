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

        [Display(Name = "Descrizione")]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Prezzo Unitario")]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        [Display(Name = "Magazzino")]
        public decimal Inventory { get; set; }

        [Display(Name = "Codice")]
        public string No { get; set; }

        public virtual ICollection<OrderLines> OrderLines { get; set; }
    }
}
