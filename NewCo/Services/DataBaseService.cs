using Microsoft.Extensions.Configuration;
using NewCo.Areas.PersonalData.Models;
using NewCo.Areas.Sales.Models;
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
            catch (Exception ex)
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
                CommandText = "INSERT INTO [dbo].[Customer] ([Code], [Name], [Address], [Post Code], [City], " +
                              "                              [County ID], [Country ID], [VAT Registration Code]) " +
                              "VALUES (@Code, @Name, @Address, @PostCode, @City, " +
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

        #region Item

        public async Task<List<Item>> ItemsAsync()
        {
            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "SELECT [Id], [No], [Description], [UnitPrice], [Inventory] " +
                              "FROM [Item]"
            };

            var itemsFound = new List<Item>();

            using (var sqlReader = await sqlCommand.ExecuteReaderAsync())
            {
                while (await sqlReader.ReadAsync())
                {
                    var currentItem = new Item(sqlReader);

                    itemsFound.Add(currentItem);
                }
            }

            return itemsFound;
        }

        public async Task<Item> ItemAsync(int id)
        {
            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "SELECT [Id], [No], [Description], [UnitPrice], [Inventory] " +
                              "FROM [Item] WHERE [Id] = @Id"
            };

            sqlCommand.Parameters.AddWithValue("@Id", id);

            var sqlReader = await sqlCommand.ExecuteReaderAsync();

            await sqlReader.ReadAsync();
            var currentItem = new Item(sqlReader);

            sqlReader.Close();

            return currentItem;
        }

        public async Task<Bundle> InsertAsync(Item itemToAdd)
        {
            var bundle = new Bundle();

            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "INSERT INTO [Item] ([No], [Description], [UnitPrice], [Inventory]) " +
                              "VALUES (@No, @Description, @UnitPrice, @Inventory)"
            };

            sqlCommand.Parameters.AddWithValue("@No", itemToAdd.No);
            sqlCommand.Parameters.AddWithValue("@Description", itemToAdd.Description);
            sqlCommand.Parameters.AddWithValue("@UnitPrice", itemToAdd.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@Inventory", itemToAdd.Inventory);

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

        public async Task<Bundle> UpdateAsync(Item itemToUpdate)
        {
            var bundle = new Bundle();

            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "UPDATE [Item] " +
                              "SET [Description] = @Description, " +
                              "[No] = @No, " +
                              "[UnitPrice] = @UnitPrice, " +
                              "[Inventory] = @Inventory " +
                              "WHERE[Id] = @Id"
            };

            sqlCommand.Parameters.AddWithValue("@Description", itemToUpdate.Description);
            sqlCommand.Parameters.AddWithValue("@No", itemToUpdate.No);
            sqlCommand.Parameters.AddWithValue("@UnitPrice", itemToUpdate.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@Inventory", itemToUpdate.Inventory);
            sqlCommand.Parameters.AddWithValue("@Id", itemToUpdate.Id);

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

        public async Task<Bundle> DeleteAsync(Item itemToDelete)
        {
            var bundle = new Bundle();

            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "DELETE FROM [Item] WHERE [ID] = @ID"
            };

            sqlCommand.Parameters.AddWithValue("@ID", itemToDelete.Id);

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

        #region Order

        public async Task<List<Order>> OrdersAsync()
        {
            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "SELECT [No], [Date], [CustomerId] " +
                              "FROM [Order]"
            };

            var OrdersFound = new List<Order>();

            using (var sqlReader = await sqlCommand.ExecuteReaderAsync())
            {
                while (await sqlReader.ReadAsync())
                {
                    var currentOrder = new Order(sqlReader);

                    //Get Customer
                    if (currentOrder.CustomerId != 0)
                    {
                        var customerItem = await CustomerAsync(currentOrder.CustomerId);
                        currentOrder.CustomerRef = customerItem;
                    }

                    OrdersFound.Add(currentOrder);
                }
            }

            return OrdersFound;
        }

        public async Task<string> GetLastOrderNoAsync()
        {
            //Anno corrente a 2 cifre
            var year2 = DateTime.Now.Year.ToString().Substring(2, 2);
            //Lunghezza protocollo 7 fisso
            var lastOrderNo = $"O{year2}0001";

            //Recupero tutti gli ordini (avrei potuto fare una chiamata già filtrata per anno corrente, ma...
            var orders = await OrdersAsync();
            //Filtro gli ordini dell'anno corrente
            var ordersOfCurrentYear = orders.Where(o => o.No.Substring(1, 2) == year2).ToList();
            
            //Verifico se ne esistono già
            if (ordersOfCurrentYear.Count != 0)
            {
                //Estraggo il progressivo corrente dell'ultimo ordine creato
                var lastOrderNoProgress = ordersOfCurrentYear.Last().No.Substring(3, 4);
                //Converto in int
                var lastOrderNoProgressInt = Convert.ToInt32(lastOrderNoProgress);
                //Genero il nuovo progressivo
                var newOrderNo = lastOrderNoProgressInt.ToString().PadLeft(4, '0');
                //Genero il nuovo protocollo
                lastOrderNo = $"O{DateTime.Now.Year.ToString().Substring(2, 2)}{newOrderNo}";
            }

            return lastOrderNo;
        }

        public async Task<Order> OrderAsync(string No)
        {
            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "SELECT [No], [Date], [CustomerId] FROM [Order] WHERE [No] = @No"
            };

            sqlCommand.Parameters.AddWithValue("@No", No);

            var sqlReader = await sqlCommand.ExecuteReaderAsync();

            await sqlReader.ReadAsync();
            var currentItem = new Order(sqlReader);

            //Get Customer
            if (currentItem.CustomerId != 0)
            {
                var customerItem = await CustomerAsync(currentItem.CustomerId);
                currentItem.CustomerRef = customerItem;
            }

            sqlReader.Close();

            return currentItem;
        }

        public async Task<Bundle> InsertAsync(Order itemToAdd)
        {
            var bundle = new Bundle();

            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "INSERT INTO [Order] ([No], [Date], [CustomerId]) " +
                              "VALUES (@No, @Date, @CustomerId)"
            };

            sqlCommand.Parameters.AddWithValue("@No", itemToAdd.No);
            sqlCommand.Parameters.AddWithValue("@Date", itemToAdd.Date);
            sqlCommand.Parameters.AddWithValue("@CustomerId", itemToAdd.CustomerId);

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

        public async Task<Bundle> UpdateAsync(Order itemToUpdate)
        {
            var bundle = new Bundle();

            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "UPDATE [Order] " +
                              "SET [Date] = @Date, " +
                              "[CustomerId] = @CustomerId " +
                              "WHERE [No] = @No"
            };

            sqlCommand.Parameters.AddWithValue("@Date", itemToUpdate.Date);
            sqlCommand.Parameters.AddWithValue("@CustomerId", itemToUpdate.CustomerId);
            sqlCommand.Parameters.AddWithValue("@No", itemToUpdate.No);

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

        public async Task<Bundle> DeleteAsync(Order itemToDelete)
        {
            var bundle = new Bundle();

            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "DELETE FROM [Order] WHERE [No] = @No"
            };

            sqlCommand.Parameters.AddWithValue("@No", itemToDelete.No);

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

        public async Task<List<OrderLine>> OrderLinesAsync(string OrderNo)
        {
            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "SELECT [OrderNo], [LineNo], [ItemId], [Description], [Quantity], [UnitPrice], [LineAmount] " +
                              "FROM [OrderLine] WHERE [OrderNo] = @OrderNo"
            };

            sqlCommand.Parameters.AddWithValue("@OrderNo", OrderNo);

            var OrderLinesFound = new List<OrderLine>();

            using (var sqlReader = await sqlCommand.ExecuteReaderAsync())
            {
                while (await sqlReader.ReadAsync())
                {
                    var currentOrderLine = new OrderLine(sqlReader);

                    //Get Item
                    if (currentOrderLine.ItemId != 0)
                    {
                        var ItemItem = await ItemAsync(currentOrderLine.ItemId);
                        currentOrderLine.ItemRef = ItemItem;
                    }

                    OrderLinesFound.Add(currentOrderLine);
                }
            }

            return OrderLinesFound;
        }

        public async Task<OrderLine> OrderLineAsync(string OrderNo, int LineNo)
        {
            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "SELECT [OrderNo], [LineNo], [ItemId], [Description], [Quantity], [UnitPrice], [LineAmount] " +
                              "FROM [OrderLine] WHERE [OrderNo] = @OrderNo AND [LineNo] = @LineNo"
            };

            sqlCommand.Parameters.AddWithValue("@OrderNo", OrderNo);
            sqlCommand.Parameters.AddWithValue("@LineNo", LineNo);

            var sqlReader = await sqlCommand.ExecuteReaderAsync();

            await sqlReader.ReadAsync();
            var currentItem = new OrderLine(sqlReader);

            //Get Item
            if (currentItem.ItemId != 0)
            {
                var itemItem = await ItemAsync(currentItem.ItemId);
                currentItem.ItemRef = itemItem;
            }

            sqlReader.Close();

            return currentItem;
        }

        

        public async Task<Bundle> InsertAsync(OrderLine itemToAdd)
        {
            var bundle = new Bundle();

            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "INSERT INTO [OrderLine] ([OrderNo], [LineNo], [ItemId], [Description], [Quantity], " +
                              "            [UnitPrice], [LineAmount]) " +
                              "VALUES (@OrderNo, @LineNo, @ItemId, @Description, @Quantity, " +
                              "            @UnitPrice, @LineAmount)"
            };

            sqlCommand.Parameters.AddWithValue("@OrderNo", itemToAdd.OrderNo);
            sqlCommand.Parameters.AddWithValue("@LineNo", itemToAdd.LineNo);
            sqlCommand.Parameters.AddWithValue("@ItemId", itemToAdd.ItemId);
            sqlCommand.Parameters.AddWithValue("@Description", itemToAdd.Description);
            sqlCommand.Parameters.AddWithValue("@Quantity", itemToAdd.Quantity);
            sqlCommand.Parameters.AddWithValue("@UnitPrice", itemToAdd.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@LineAmount", itemToAdd.LineAmount);

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

        public async Task<Bundle> UpdateAsync(OrderLine itemToUpdate)
        {
            var bundle = new Bundle();

            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "UPDATE [OrderLine] " +
                              "SET [ItemId] = @ItemId, " +
                              "[Description] = @Description " +
                              "[Quantity] = @Quantity " +
                              "[UnitPrice] = @UnitPrice " +
                              "[LineAmount] = @LineAmount " +
                              "WHERE [OrderNo] = @OrderNo AND [LineNo] = @LineNo"
            };

            sqlCommand.Parameters.AddWithValue("@ItemId", itemToUpdate.ItemId);
            sqlCommand.Parameters.AddWithValue("@Description", itemToUpdate.Description);
            sqlCommand.Parameters.AddWithValue("@Quantity", itemToUpdate.Quantity);
            sqlCommand.Parameters.AddWithValue("@UnitPrice", itemToUpdate.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@LineAmount", itemToUpdate.LineAmount);
            sqlCommand.Parameters.AddWithValue("@OrderNo", itemToUpdate.OrderNo);
            sqlCommand.Parameters.AddWithValue("@LineNo", itemToUpdate.LineNo);

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

        public async Task<Bundle> DeleteAsync(OrderLine itemToDelete)
        {
            var bundle = new Bundle();

            var sqlCommand = new SqlCommand
            {
                Connection = _sqlConnection,
                CommandText = "DELETE FROM [OrderLine] WHERE [OrderNo] = @OrderNo AND [LineNo] = @LineNo"
            };

            sqlCommand.Parameters.AddWithValue("@OrderNo", itemToDelete.OrderNo);
            sqlCommand.Parameters.AddWithValue("@LineNo", itemToDelete.LineNo);

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
