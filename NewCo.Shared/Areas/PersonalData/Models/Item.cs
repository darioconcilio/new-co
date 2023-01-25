using NewCo.Shared;
using NewCoEF.Shared.Areas.Sales.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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


        [Display(Name = "Item_Description", ResourceType = typeof(ItemResource))]
        [JsonProperty("description")]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Item_UnitPrice", ResourceType = typeof(ItemResource))]
        [DataType(DataType.Currency)]
        [JsonProperty("unitPrice")]
        public decimal UnitPrice { get; set; }

        [DisplayFormat(DataFormatString = "{0:N0}")]
        [Display(Name = "Item_Inventory", ResourceType = typeof(ItemResource))]
        [JsonProperty("inventory")]
        public decimal Inventory { get; set; }

        [Display(Name = "Item_No", ResourceType = typeof(ItemResource))]
        [JsonProperty("no")]
        public string No { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
