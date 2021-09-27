using Microsoft.Extensions.Configuration;
using NewCo.Areas.PersonalData.Models;
using NewCo.Commons;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NewCo.Services
{
    public class DataBaseService : IDatabaseService, IDisposable
    {
        IConfiguration _configuration;
        SqlConnection _sqlConnection;

        public DataBaseService(IConfiguration configuration)
        {
            _configuration = configuration;

            connect();
        }

        private void connect()
        {
            _sqlConnection = new SqlConnection();
            _sqlConnection.ConnectionString = _configuration.GetConnectionString("SQL");
            _sqlConnection.Open();
        }

        public void Dispose()
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Open)
                _sqlConnection.Close();
        }

        #region County

        public async Task<List<County>> CountiesAsync()
        {
            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "SELECT [ID], [Name], [Code] FROM [County]"
            };

            var itemsFound = new List<County>();

            using (var sqlReader = await sqlCommand.ExecuteReaderAsync())
            {
                while (await sqlReader.ReadAsync())
                {
                    var currentItem = new County(sqlReader);
                    itemsFound.Add(currentItem);
                }
            }
            //sqlReader.Close();

            return itemsFound;
        }

        public async Task<Bundle> UpdateAsync(County itemToUpdate)
        {
            var bundle = new Bundle();

            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "UPDATE [County] SET [Name] = @Name, [Code] = @Code FROM [County] WHERE [ID] = @ID"
            };

            sqlCommand.Parameters.AddWithValue("@Name", itemToUpdate.Name);
            sqlCommand.Parameters.AddWithValue("@Code", itemToUpdate.Code);
            sqlCommand.Parameters.AddWithValue("@ID", itemToUpdate.ID);

            try
            {
                await sqlCommand.ExecuteNonQueryAsync();
                bundle.Result = true;
            }
            catch(Exception ex)
            {
                bundle.Result = false;
                bundle.Message = ex.Message;
            }

            return bundle;
        }
      

        public async Task<County> CountyAsync(int id)
        {
            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "SELECT [ID], [Name], [Code] FROM [County] WHERE [ID] = @ID"
            };

            sqlCommand.Parameters.AddWithValue("@ID", id);

            var sqlReader = await sqlCommand.ExecuteReaderAsync();

            await sqlReader.ReadAsync();
            var currentItem = new County(sqlReader);

            sqlReader.Close();

            return currentItem;
        }

        public async Task<Bundle> DeleteAsync(County item)
        {
            var bundle = new Bundle();

            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "DELETE FROM [County] WHERE [ID] = @ID"
            };

            sqlCommand.Parameters.AddWithValue("@ID", item.ID);

            try
            {
                await sqlCommand.ExecuteNonQueryAsync();
                bundle.Result = true;
            }
            catch (Exception ex)
            {
                bundle.Result = false;
                bundle.Message = ex.Message;
            }

            return bundle;
        }

        public async Task<Bundle> InsertAsync(County itemToAdd)
        {
            var bundle = new Bundle();

            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "INSERT INTO [County] ([Name], [Code]) VALUES (@Name, @Code)"
            };

            sqlCommand.Parameters.AddWithValue("@Name", itemToAdd.Name);
            sqlCommand.Parameters.AddWithValue("@Code", itemToAdd.Code);

            try
            {
                await sqlCommand.ExecuteNonQueryAsync();
                bundle.Result = true;
            }
            catch (Exception ex)
            {
                bundle.Result = false;
                bundle.Message = ex.Message;
            }

            return bundle;
        }

        #endregion

        #region Country

        public async Task<List<Country>> CountriesAsync()
        {
            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "SELECT [ID], [Name] FROM [Country]"
            };

            var itemsFound = new List<Country>();

            using (var sqlReader = await sqlCommand.ExecuteReaderAsync())
            {
                while (await sqlReader.ReadAsync())
                {
                    var currentItem = new Country(sqlReader);
                    itemsFound.Add(currentItem);
                }
            }
            //sqlReader.Close();

            return itemsFound;
        }

        public async Task<Bundle> UpdateAsync(Country itemToUpdate)
        {
            var bundle = new Bundle();

            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "UPDATE [Country] SET [Name] = @Name FROM [Country] WHERE [ID] = @ID"
            };

            sqlCommand.Parameters.AddWithValue("@Name", itemToUpdate.Name);
            sqlCommand.Parameters.AddWithValue("@ID", itemToUpdate.ID);

            try
            {
                await sqlCommand.ExecuteNonQueryAsync();
                bundle.Result = true;
            }
            catch (Exception ex)
            {
                bundle.Result = false;
                bundle.Message = ex.Message;
            }

            return bundle;
        }


        public async Task<Country> CountryAsync(int id)
        {
            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "SELECT [ID], [Name] FROM [Country] WHERE [ID] = @ID"
            };

            sqlCommand.Parameters.AddWithValue("@ID", id);

            var sqlReader = await sqlCommand.ExecuteReaderAsync();

            await sqlReader.ReadAsync();
            var currentItem = new Country(sqlReader);

            sqlReader.Close();

            return currentItem;
        }

        public async Task<Bundle> DeleteAsync(Country item)
        {
            var bundle = new Bundle();

            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "DELETE FROM [Country] WHERE [ID] = @ID"
            };

            sqlCommand.Parameters.AddWithValue("@ID", item.ID);

            try
            {
                await sqlCommand.ExecuteNonQueryAsync();
                bundle.Result = true;
            }
            catch (Exception ex)
            {
                bundle.Result = false;
                bundle.Message = ex.Message;
            }

            return bundle;
        }

        public async Task<Bundle> InsertAsync(Country itemToAdd)
        {
            var bundle = new Bundle();

            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "INSERT INTO [Country] ([Name]) VALUES (@Name)"
            };

            sqlCommand.Parameters.AddWithValue("@Name", itemToAdd.Name);

            try
            {
                await sqlCommand.ExecuteNonQueryAsync();
                bundle.Result = true;
            }
            catch (Exception ex)
            {
                bundle.Result = false;
                bundle.Message = ex.Message;
            }

            return bundle;
        }


        #endregion

        #region Customer

        public async Task<List<Customer>> CustomersAsync()
        {
            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "SELECT [ID], [Name], [Code], [Address], [Post Code], [City], [County ID], [Country ID], " +
                              "[VAT Registration Code] FROM [Customer]"
            };

            var itemsFound = new List<Customer>();

            using (var sqlReader = await sqlCommand.ExecuteReaderAsync())
            {
                while (await sqlReader.ReadAsync())
                {
                    var currentItem = new Customer(sqlReader);

                    //Get County
                    if (currentItem.CountyId != 0)
                    {
                        var countyItem = await CountyAsync(currentItem.CountyId);
                        currentItem.CountyRef = countyItem;
                    }

                    //Get Country
                    if (currentItem.CountryId != 0)
                    {
                        var countryItem = await CountryAsync(currentItem.CountryId);
                        currentItem.CountryRef = countryItem;
                    }

                    itemsFound.Add(currentItem);
                }
            }
            //sqlReader.Close();

            return itemsFound;
        }

        public async Task<Bundle> UpdateAsync(Customer itemToUpdate)
        {
            var bundle = new Bundle();

            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "UPDATE [Customer] SET [Name] = @Name, [Code] = @Code, [Address] = @Address, [Post Code] = @PostCode, " +
                              "[City] = @City, [County ID] = @CountyID, [Country ID] = @CountryID, " +
                              "[VAT Registration Code] = @VATRegistrationCode FROM Customer WHERE [ID] = @ID"
            };

            sqlCommand.Parameters.AddWithValue("@Name", itemToUpdate.Name);
            sqlCommand.Parameters.AddWithValue("@Code", itemToUpdate.Code);
            sqlCommand.Parameters.AddWithValue("@Address", itemToUpdate.Address);
            sqlCommand.Parameters.AddWithValue("@PostCode", itemToUpdate.PostCode);
            sqlCommand.Parameters.AddWithValue("@City", itemToUpdate.City);
            sqlCommand.Parameters.AddWithValue("@CountyID", itemToUpdate.CountyId);
            sqlCommand.Parameters.AddWithValue("@CountryID", itemToUpdate.CountryId);
            sqlCommand.Parameters.AddWithValue("@VATRegistrationCode", itemToUpdate.VATRegistrationCode);
            sqlCommand.Parameters.AddWithValue("@ID", itemToUpdate.ID);

            try
            {
                await sqlCommand.ExecuteNonQueryAsync();
                bundle.Result = true;
            }
            catch (Exception ex)
            {
                bundle.Result = false;
                bundle.Message = ex.Message;
            }

            return bundle;
        }


        public async Task<Customer> CustomerAsync(int id)
        {
            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "SELECT [ID], [Name], [Code], [Address], [Post Code], [City], [County ID], [Country ID], " +
                              "[VAT Registration Code] FROM [Customer] WHERE [ID] = @ID"
            };

            sqlCommand.Parameters.AddWithValue("@ID", id);

            var sqlReader = await sqlCommand.ExecuteReaderAsync();

            await sqlReader.ReadAsync();
            var currentItem = new Customer(sqlReader);

            //Get County
            if (currentItem.CountyId != 0)
            {
                var countyItem = await CountyAsync(currentItem.CountyId);
                currentItem.CountyRef = countyItem;
            }

            //Get Country
            if (currentItem.CountryId != 0)
            {
                var countryItem = await CountryAsync(currentItem.CountryId);
                currentItem.CountryRef = countryItem;
            }

            sqlReader.Close();

            return currentItem;
        }

        public async Task<Bundle> DeleteAsync(Customer item)
        {
            var bundle = new Bundle();

            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "DELETE FROM [Customer] WHERE [ID] = @ID"
            };

            sqlCommand.Parameters.AddWithValue("@ID", item.ID);

            try
            {
                await sqlCommand.ExecuteNonQueryAsync();
                bundle.Result = true;
            }
            catch (Exception ex)
            {
                bundle.Result = false;
                bundle.Message = ex.Message;
            }

            return bundle;
        }

        public async Task<Bundle> InsertAsync(Customer itemToAdd)
        {
            var bundle = new Bundle();

            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "INSERT INTO [dbo].[Customer] ([Code], [Name], [Address], [Post Code], [City], "+
                              "                              [County ID], [Country ID], [VAT Registration Code]) " +
                              "VALUES (@Code, @Name, @Address, @PostCode, @City, "+
                              "        @CountyID, @CountryID, @VATRegistrationCode)"
            };

            sqlCommand.Parameters.AddWithValue("@Code", itemToAdd.Code); 
            sqlCommand.Parameters.AddWithValue("@Name", itemToAdd.Name);
            sqlCommand.Parameters.AddWithValue("@Address", itemToAdd.Address);
            sqlCommand.Parameters.AddWithValue("@PostCode", itemToAdd.PostCode);
            sqlCommand.Parameters.AddWithValue("@City", itemToAdd.City);
            sqlCommand.Parameters.AddWithValue("@CountyID", itemToAdd.CountyId);
            sqlCommand.Parameters.AddWithValue("@CountryID", itemToAdd.CountryId);
            sqlCommand.Parameters.AddWithValue("@VATRegistrationCode", itemToAdd.VATRegistrationCode);

            try
            {
                await sqlCommand.ExecuteNonQueryAsync();
                bundle.Result = true;
            }
            catch (Exception ex)
            {
                bundle.Result = false;
                bundle.Message = ex.Message;
            }

            return bundle;
        }

        #endregion
    }
}
