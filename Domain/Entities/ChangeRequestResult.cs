using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ChangeRequestResult
    {
        [JsonProperty("assigned_to")]
        public ChangeRequestUser User { get; set; }

    }
}
