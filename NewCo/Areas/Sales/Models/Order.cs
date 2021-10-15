using NewCo.Areas.PersonalData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

            No = reader["No"].ToString();
            Date = Convert.ToDateTime(reader["Date"]);
            CustomerId = Convert.ToInt32(reader["CustomerId"]);
        }

        [Display(Name = "Nr. Ordine")]
        public string No { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Data Ordine")]
        public DateTime? Date { get; set; }

        [Display(Name = "Cliente")]
        public int CustomerId { get; set; }
        
        public List<OrderLine> Lines { get; set; }
        public Customer CustomerRef { get; set; }
    }
}
