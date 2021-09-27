using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NewCo.Areas.PersonalData.Models
{
    public static class ExtensionHelpers
    {
        //Alternativa al contruttore con SqlDataReader come parametro all'interno del modello County
        public static County ToCounty(this SqlDataReader reader)
        {
            var itemConverted = new County
            {
                ID = (int)reader["ID"],
                Name = reader["Name"].ToString(),
                Code = reader["Code"].ToString()
            };

            return itemConverted;
        }
    }
}
