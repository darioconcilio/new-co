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
            OrderId = reader["OrderId"].ToString();
            Id = reader["Id"].ToString();

            LineNo = Convert.ToInt32(reader["LineNo"]);
            ItemId = Convert.ToInt32(reader["ItemId"]);
            Description = reader["Description"].ToString();
            Quantity = Convert.ToDouble(reader["Quantity"]);
            UnitPrice = Convert.ToDouble(reader["UnitPrice"]);
            LineAmount = Convert.ToDouble(reader["LineAmount"]);
        }

        /// <summary>
        /// Guid dell'ordine
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// Guid della riga
        /// </summary>
        public string Id { get; set; }

        [Display(Name = "Nr. Riga")]
        public int LineNo { get; set; }
        public int ItemId { get; set; }

        [Display(Name = "Articolo")]
        public Item ItemRef { get; set; }

        [Display(Name = "Descrizione")]
        public string Description { get; set; }

        double quantity;
        [DisplayFormat(DataFormatString = "{0:N0}")]
        [Display(Name = "Quantità")]
        public double Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                LineAmount = quantity * unitPrice;
            }
        }

        double unitPrice;
        [DisplayFormat(DataFormatString = "{0:c}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Prezzo Unitario")]
        public double UnitPrice
        {
            get { return unitPrice; }
            set
            {
                unitPrice = value;
                LineAmount = quantity * unitPrice;
            }
        }

        [DisplayFormat(DataFormatString = "{0:c}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Importo Riga")]
        public double LineAmount { get; set; }

        public bool Updated { get; set; }
    }
}
