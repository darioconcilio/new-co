using Microsoft.Extensions.Configuration;
using NewCo.Areas.PersonalData.Models;
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
    }
}
