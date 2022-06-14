﻿using NewCoEF.Shared.Areas.PersonalData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Shared.Areas.Sales.Models
{
    public class OrderLine
    {
        /// <summary>
        /// Guid dell'ordine
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Guid della riga
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nr. Riga")]
        public int LineNo { get; set; }

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

        public Guid? ItemId { get; set; }

        //public Item ItemRef { get; set; }
        public virtual Item ItemRef { get; set; }


        //public Order OrderRef { get; set; }
        public virtual Order OrderRef { get; set; }
    }
}