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

        }

        public int Id { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
    }
}
