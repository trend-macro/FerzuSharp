using Newtonsoft.Json;

namespace ShitKit
{
    public class User
    {
        public long Id { get; set; }

        [JsonProperty(PropertyName = "UserName")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "IconUrl")]
        public string Avatar { get; set; }

        [JsonProperty(PropertyName = "IsOnline")]
        public bool IsOnline { get; set; }

        [JsonProperty(PropertyName = "Status")]
        public string Status { get; set; }
    }
}