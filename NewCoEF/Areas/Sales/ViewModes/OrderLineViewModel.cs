using NewCoEF.Shared.Areas.PersonalData.Models;
using NewCoEF.Shared.Areas.Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Areas.Sales.ViewModels
{
    public class OrderLineViewModel : OrderLine
    {
        public OrderLineViewModel()
        {
            //Init collections for dropdown
            Items = new List<Item>();
        }

        public OrderLineViewModel(OrderLine orderLine) : base ()
        {
            OrderId = orderLine.OrderId;
            Id = orderLine.Id;

            LineNo = orderLine.LineNo;
            ItemId = orderLine.ItemId;
            Quantity = orderLine.Quantity;
            UnitPrice = orderLine.UnitPrice;
            LineAmount = orderLine.LineAmount;

            //Init collections for dropdown
            Items = new List<Item>();
        }

        public List<Item> Items { get; set; }

    }
}
