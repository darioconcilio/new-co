using System;
using System.Data;
using System.Data.SqlClient;

namespace TestDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=localhost;Database=NewCo;User Id=newco;Password=newco;MultipleActiveResultSets=true";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            DataTable dtItem = new DataTable();

            try
            {
                //Recupero dei dati

                sqlConnection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Item", sqlConnection);

                #region Update Commmand

                SqlCommand command = new SqlCommand(
                    "UPDATE Item SET Description = @Description, UnitPrice = @UnitPrice, " +
                    "Inventory = @Inventory, No = @No " +
                    "WHERE Id = @oldId", sqlConnection);
                
                command.Parameters.Add("@Description", SqlDbType.VarChar, 50, "Description");
                command.Parameters.Add("@UnitPrice", SqlDbType.Money, 0, "UnitPrice");
                command.Parameters.Add("@Inventory", SqlDbType.Decimal, 18, "Inventory");
                command.Parameters.Add("@No", SqlDbType.VarChar, 20, "No");
                
                SqlParameter parameter = command.Parameters.Add("@oldId", SqlDbType.Int, 0, "Id");
                parameter.SourceVersion = DataRowVersion.Original;

                sqlDataAdapter.UpdateCommand = command;

                #endregion

                sqlDataAdapter.Fill(dtItem); //I dati sono in memoria

                sqlConnection.Close();

                //Attività disconnessa

                foreach (DataRow row in dtItem.Rows)
                {
                    if (row["No"].ToString() == "ART-B-0003")
                    {
                        Console.WriteLine($"Articolo {row["No"].ToString()} con descrizione '{row["Description"].ToString()}'");
                        row["Description"] = "Nuova dicitura";
                    }
                }

                //Riconnessione per aggiornamento effettivo
                sqlConnection.Open();

                sqlDataAdapter.Update(dtItem);

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }
    }
}
