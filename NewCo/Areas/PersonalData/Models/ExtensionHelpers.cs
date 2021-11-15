using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NewCo.Areas.PersonalData.Models
{
    public static class ExtensionHelpers
    {
        //Alternativa al contruttore con SqlDataReader come parametro all'interno del modello Item
        public static Item ToItem(this SqlDataReader reader)
        {
            var itemConverted = new Item
            {
                Id = (int)reader["Id"],
                Description = reader["Description"].ToString(),
                No = reader["No"].ToString(),
                Inventory = Convert.ToDecimal(reader["Inventory"]),
                UnitPrice = Convert.ToDecimal(reader["UnitPrice"])
            };

            return itemConverted;
        }

        public static List<Item> ToItems(this DataRowCollection rows)
        {
            List<Item> items = new List<Item>();

            foreach (DataRow dr in rows)
                items.Add(new Item(dr));

            return items;
        }
    }
}
