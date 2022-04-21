using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCoEF.Commons
{
    public static class ErrorHelper
    {
        public static string GetError(Exception ex)
        {
            StringBuilder sb = new StringBuilder(ex.Message);

            if(ex.InnerException!=null)
            {
                sb.AppendLine(ex.InnerException.Message);
            }

            return sb.ToString();
        }
    }
}
