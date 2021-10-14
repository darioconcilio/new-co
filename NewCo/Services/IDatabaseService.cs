using Microsoft.Extensions.Configuration;
using NewCo.Areas.PersonalData.Models;
using NewCo.Areas.Sales.Models;
using NewCo.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewCo.Services
{
    public interface IDatabaseService
    {
        #region County  

        public Task<List<County>> CountiesAsync();
        public Task<County> CountyAsync(int id);
        public Task<Bundle> InsertAsync(County itemToAdd);
        public Task<Bundle> UpdateAsync(County itemToUpdate);
        public Task<Bundle> DeleteAsync(County itemToDelete);

        #endregion

        #region Country  

        public Task<List<Country>> CountriesAsync();
        public Task<Country> CountryAsync(int id);
        public Task<Bundle> InsertAsync(Country itemToAdd);
        public Task<Bundle> UpdateAsync(Country itemToUpdate);
        public Task<Bundle> DeleteAsync(Country itemToDelete);

        #endregion

        #region Customer  

        public Task<List<Customer>> CustomersAsync();
        public Task<Customer> CustomerAsync(int id);
        public Task<Bundle> InsertAsync(Customer itemToAdd);
        public Task<Bundle> UpdateAsync(Customer itemToUpdate);
        public Task<Bundle> DeleteAsync(Customer itemToDelete);

        #endregion

        #region Items

        public Task<List<Item>> ItemsAsync();
        public Task<Item> ItemAsync(int id);
        public Task<Bundle> InsertAsync(Item itemToAdd);
        public Task<Bundle> UpdateAsync(Item itemToUpdate);
        public Task<Bundle> DeleteAsync(Item itemToDelete);

        #endregion

        #region Orders

        public Task<List<Order>> OrdersAsync();
        public Task<Order> OrderAsync(int id);
        public Task<Bundle> InsertAsync(Order itemToAdd);
        public Task<Bundle> UpdateAsync(Order itemToUpdate);
        public Task<Bundle> DeleteAsync(Order itemToDelete);


        public Task<List<OrderLine>> OrderLinesAsync();
        public Task<OrderLine> OrderLineAsync(int id);
        public Task<Bundle> InsertAsync(OrderLine itemToAdd);
        public Task<Bundle> UpdateAsync(OrderLine itemToUpdate);
        public Task<Bundle> DeleteAsync(OrderLine itemToDelete);

        #endregion
    }
}
