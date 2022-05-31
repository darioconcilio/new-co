using NewCoEF.Shared.Areas.PersonalData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewCoEF.Areas.PersonalData.ViewModels
{
    public class IndexByExtendedQueryViewModel
    {
        public IndexByExtendedQueryViewModel()
        {
            CountiesFound = new List<County>();
        }

        public string Filter { get; set; } = string.Empty;

        public IEnumerable<County> CountiesFound { get; set; }
    }
}
