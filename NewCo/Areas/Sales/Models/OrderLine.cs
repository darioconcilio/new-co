using NewCo.Areas.PersonalData.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NewCo.Areas.Sales.Models
{
    public class OrderLine
    {
        public OrderLine()
        {

        }

        public OrderLine(SqlDataReader reader)
        {
            OrderNo = reader["OrderNo"].ToString();
            LineNo = Convert.ToInt32(reader["LineNo"]);
            ItemId = Convert.ToInt32(reader["ItemId"]);
            Description = reader["Description"].ToString();
            Quantity = Convert.ToDouble(reader["Quantity"]);
            UnitPrice = Convert.ToDouble(reader["UnitPrice"]);
            LineAmount = Convert.ToDouble(reader["LineAmount"]);
        }

        public string OrderNo { get; set; }
        public int LineNo { get; set; }
        public int ItemId { get; set; }
        public Item ItemRef { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double LineAmount { get; set; }
    }
}
