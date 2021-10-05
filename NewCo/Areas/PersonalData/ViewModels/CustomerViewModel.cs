using NewCo.Areas.PersonalData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewCo.Areas.PersonalData.ViewModels
{
    public class CustomerViewModel : Customer
    {
        public CustomerViewModel()
        {
            //Init collections for dropdown
            Counties = new List<County>();
            Countries = new List<Country>();
        }

        public CustomerViewModel(Customer customer) : base ()
        {
            ID = customer.ID;
            Name = customer.Name;
            Code = customer.Code;
            Address = customer.Address;
            PostCode = customer.PostCode;
            City = customer.City;
            CountryId = customer.CountryId;
            CountryRef = customer.CountryRef;
            CountyId = customer.CountyId;
            CountyRef = customer.CountyRef;
            VATRegistrationCode = customer.VATRegistrationCode;

            //Init collections for dropdown
            Counties = new List<County>();
            Countries = new List<Country>();
        }

        public List<County> Counties { get; set; }

        public List<Country> Countries { get; set; }

    }
}
