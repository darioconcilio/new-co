using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NewCo.Areas.PersonalData.Models
{
    public class Item
    {
        public Item()
        {

        }

        public Item(SqlDataReader reader)
        {
            Id = Convert.ToInt32(reader["Id"]);
            Description = reader["Description"].ToString();
            UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
            Inventory = Convert.ToDecimal(reader["Inventory"]);
            No = reader["No"].ToString();
        }

        public int Id { get; set; }

        [Display(Name = "Descrizione")]
        public string Description { get; set; }

        [Display(Name = "Prezzo Unitario")]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Magazzino")]
        public decimal Inventory { get; set; }

        [Display(Name = "Codice")]
        public string No { get; set; }
    }
}
