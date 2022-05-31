using NewCoEF.Shared.Areas.Sales.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Shared.Areas.PersonalData.Models
{
    [JsonObject]
    public partial class Item
    {
        public Item()
        {
            OrderLines = new HashSet<OrderLine>();
        }

        [JsonProperty("id")]
        public Guid Id { get; set; }


        [Display(Name = "Descrizione")]
        [JsonProperty("description")]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Prezzo Unitario")]
        [DataType(DataType.Currency)]
        [JsonProperty("unitPrice")]
        public decimal UnitPrice { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        [Display(Name = "Magazzino")]
        [JsonProperty("inventory")]
        public decimal Inventory { get; set; }

        [Display(Name = "Codice")]
        [JsonProperty("no")]
        public string No { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
