using NewCo.Areas.PersonalData.Models;
using NewCo.Areas.Sales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewCo.Areas.Sales.ViewModels
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
            No = order.No;
            Date = order.Date;
            CustomerId = order.CustomerId;
            CustomerRef = order.CustomerRef;

            //Init collections for dropdown
            Customers = new List<Customer>();
        }

        public List<Customer> Customers { get; set; }

    }
}
