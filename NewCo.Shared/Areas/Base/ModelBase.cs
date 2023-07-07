using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewCo.Shared.Areas.Base
{
    public class ModelBase
    {


        #region data protection

        IDataProtectionProvider dataProtectionProvider;
        IDataProtector protector;

        public void InitProtectionProvider()
        {
            dataProtectionProvider = DataProtectionProvider.Create("NewCoShared");
            protector = dataProtectionProvider.CreateProtector("NewCo.Shared.Areas.Base.ModelBase");
        }

        public string Protect(string dataToProtect)
        {
            try
            {
                return protector.Protect(dataToProtect);
            }
            catch
            {

                return dataToProtect;
            }
        }

        public string Unprotect(string dataToUnProtect)
        {
            try
            {
                return protector.Unprotect(dataToUnProtect);
            }
            catch
            {
                return dataToUnProtect;
            }

        }

        #endregion
    }
}
