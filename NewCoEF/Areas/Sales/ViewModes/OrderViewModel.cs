using NewCoEF.Shared.Areas.PersonalData.Models;
using NewCoEF.Shared.Areas.Sales.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace NewCoEF.Areas.Sales.ViewModels
{
    public class OrderViewModel : Order
    {
        public OrderViewModel()
        {
            //Init collections for dropdown
            Customers = new List<Customer>();
        }

        public OrderViewModel(Order order) : base()
        {
            Id = order.Id;
            No = order.No;
            Date = order.Date;
            CustomerId = order.CustomerId;
            CustomerRef = order.CustomerRef;

            Lines = order.Lines;

            //Init collections for dropdown
            Customers = new List<Customer>();
        }

        public List<Customer> Customers { get; set; }

        

    }
}
