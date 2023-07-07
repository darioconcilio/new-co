using Microsoft.AspNetCore.DataProtection;
using NewCo.Shared;
using NewCo.Shared.Resources.Item;
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
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorsResource))]
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
        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ErrorsResource))]
        public string No { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderLine> OrderLines { get; set; }

        #region data protection

        public void ApplyProtection()
        {
            var dataProtectionProvider = DataProtectionProvider.Create("NewCoShared");
            var protector = dataProtectionProvider.CreateProtector("NewCoEF.Shared.Areas.PersonalData.Models.Item");

            try
            {
                Description = protector.Protect(Description);
                No = protector.Protect(No);
            }
            catch
            {
                // Non faccio nulla, i dati non sono stati mai codificati prima d'ora
            }


        }

        public void RemoveProtection()
        {
            var dataProtectionProvider = DataProtectionProvider.Create("NewCoShared");
            var protector = dataProtectionProvider.CreateProtector("NewCoEF.Shared.Areas.PersonalData.Models.Item");

            try
            {
                Description = protector.Unprotect(Description);
                No = protector.Unprotect(No);
            }
            catch
            {
                // Non faccio nulla, i dati non sono stati mai codificati prima d'ora
            }
        }

        #endregion
    }
}
