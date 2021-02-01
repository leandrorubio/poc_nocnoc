using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ChangeRequest
    {
        [JsonProperty("result")]
        public List<ChangeRequestResult> Result { get; set; }
    }
}
