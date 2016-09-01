using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitKit
{
    public class Status
    {
        [JsonProperty(PropertyName = "Id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "Text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "DateCreated")]
        private string dateString { get; set; }

        [JsonProperty(PropertyName = "IsNotification")]
        public bool IsNotification { get; set; }

        public DateTime Date
        {
            get
            {
                if (!string.IsNullOrEmpty(dateString))
                    return DateTime.Parse(dateString);
                else
                    return DateTime.Now;
            }
        }

        [JsonProperty(PropertyName = "Member")]
        public User User { get; set; }
    }
}
