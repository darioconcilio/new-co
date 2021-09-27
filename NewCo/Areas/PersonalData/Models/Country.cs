using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NewCo.Areas.PersonalData.Models
{
    public class Country
    {
        public Country()
        {
            
        }

        public Country(SqlDataReader dr)
        {
            ID = Convert.ToInt32(dr["ID"]);
            Name = dr["Name"].ToString();
        }

        public int ID { get; set; }

        [Display(Name = "Paese")]
        public string Name { get; set; }

    }
}
