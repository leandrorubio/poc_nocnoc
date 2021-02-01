using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ViewModel
{
    public class AlertRequest
    {
        public string Ic { get; set; }
        public string Type  {get; set;}
        public string PopId { get; set; }
    }
}
