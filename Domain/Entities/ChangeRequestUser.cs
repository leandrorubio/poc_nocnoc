using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ChangeRequestUser
    {
        [JsonProperty("display_value")]
        public string AssignedToName { get; set; }

        [JsonProperty("value")]
        public string AssignedToId { get; set; }
    }
}
