using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NewCo.Areas.Sales.Models
{
    public class Order
    {
        public Order()
        {
            Lines = new List<OrderLine>();
        }

        public Order(SqlDataReader reader)
        {
            Lines = new List<OrderLine>();
        }

        public string No { get; set; }
        public DateTime? Date { get; set; }
        public int CustomerId { get; set; }
        public List<OrderLine> Lines { get; set; }
    }
}
