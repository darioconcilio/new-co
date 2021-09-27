using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NewCo.Areas.PersonalData.Models
{
    public class County
    {
        public County()
        {

        }

        public County(SqlDataReader dr)
        {
            ID = Convert.ToInt32(dr["ID"]);
            Name = dr["Name"].ToString();
            Code = dr["Code"].ToString();
        }

        public int ID { get; set; }

        [Display(Name = "Provincia")]
        public string Name { get; set; }

        [Display(Name = "Codice")]
        public string Code { get; set; }
    }
}
