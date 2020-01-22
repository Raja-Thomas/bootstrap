using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bootstrap.Models
{
    public class CountryMaster 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }

        public ICollection< RegisterViewModel> registerViewModels { get; set; }

    }
}
