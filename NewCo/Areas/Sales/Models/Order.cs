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
            Id = Guid.NewGuid().ToString();
            Lines = new List<OrderLine>();
        }

        public Order(SqlDataReader reader)
        {
            Lines = new List<OrderLine>();

            Id = reader["Id"].ToString();
            No = reader["No"].ToString();
            Date = Convert.ToDateTime(reader["Date"]);
            CustomerId = Convert.ToInt32(reader["CustomerId"]);
        }

        public string Id { get; set; }

        [Display(Name = "Nr. Ordine")]
        [Required]
        public string No { get; set; }

        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        //[DataType(DataType.Date)]
        [Display(Name = "Data Ordine")]
        [Required]
        public DateTime? Date { get; set; }

        [Display(Name = "Cliente")]
        [Required]
        public int CustomerId { get; set; }

        public List<OrderLine> Lines { get; set; }

        [Display(Name = "Cliente")]
        public Customer CustomerRef { get; set; }

        public List<OrderLine> UpdatedLines()
        {
            return Lines.Where(ol => ol.Updated == true).ToList();
        }

    }
}
