using NewCoEF.Areas.PersonalData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Areas.Sales.Models
{
    public class OrderLine
    {
        public OrderLine()
        {
            Id = Guid.NewGuid();
        }

        public OrderLine(Guid orderId)
        {
            Id = Guid.NewGuid();
            OrderId = orderId;
        }

        /// <summary>
        /// Guid dell'ordine
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Guid della riga
        /// </summary>
        public Guid Id { get; set; }

        [Display(Name = "Nr. Riga")]
        public int LineNo { get; set; }



        double quantity;
        [DisplayFormat(DataFormatString = "{0:N0}")]
        [Display(Name = "Quantità")]
        [Required]
        public double Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                LineAmount = quantity * unitPrice;
            }
        }

        [Required]
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

        [Required]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Importo Riga")]
        public double LineAmount { get; set; }

        #region Navigation Property

        public Item ItemRef { get; set; }

        public Order OrderRef { get; set; }

        #endregion
    }
}
