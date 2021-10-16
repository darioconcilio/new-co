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
            UnitPrice = Convert.ToDouble(reader["UnitPrice"]);
            Inventory = Convert.ToDouble(reader["Inventory"]);
            No = reader["No"].ToString();
        }

        public int Id { get; set; }

        [Display(Name = "Descrizione")]
        public string Description { get; set; }

        [Display(Name = "Prezzo Unitario")]
        public double UnitPrice { get; set; }

        [Display(Name = "Magazzino")]
        public double Inventory { get; set; }

        [Display(Name = "Codice")]
        public string No { get; set; }
    }
}
