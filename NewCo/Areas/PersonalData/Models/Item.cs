using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
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

        public Item(DataRow dr)
        {
            Id = Convert.ToInt32(dr["Id"]);
            Description = dr["Description"].ToString();
            UnitPrice = Convert.ToDecimal(dr["UnitPrice"]);
            Inventory = Convert.ToDecimal(dr["Inventory"]);
            No = dr["No"].ToString();
        }

        public void UpdateDataRow(ref DataRow dr)
        {
            dr["Id"] = Id;
            dr["Description"] = Description;
            dr["UnitPrice"] = UnitPrice;
            dr["Inventory"] = Inventory;
            dr["No"] = No;
        }

        public int Id { get; set; }

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
    }

}
