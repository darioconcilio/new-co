using NewCo.Areas.PersonalData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Nr. Ordine")]
        public string OrderNo { get; set; }

        [Display(Name = "Nr. Riga")]
        public int LineNo { get; set; }
        public int ItemId { get; set; }

        [Display(Name = "Articolo")]
        public Item ItemRef { get; set; }

        [Display(Name = "Descrizione")]
        public string Description { get; set; }

        [Display(Name = "Quantità")]
        public double Quantity { get; set; }

        [Display(Name = "Prezzo Unitario")]
        public double UnitPrice { get; set; }

        [Display(Name = "Importo Riga")]
        public double LineAmount { get; set; }

        public bool Updated { get; set; }
    }
}
