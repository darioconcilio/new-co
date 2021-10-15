using System;
using System.Collections.Generic;
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
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public double Inventory { get; set; }
    }
}
