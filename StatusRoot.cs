using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShitKit;

namespace ShitKit
{
    public class StatusRoot
    {
        [JsonProperty (PropertyName = "PostItems")]
        public List<Status> Statuses { get; set; }
    }
}
