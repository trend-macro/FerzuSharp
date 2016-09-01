using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;


namespace ShitKit
{
    /// <summary>
    /// I want to fucking Die
    /// </summary>
    public static class FurryFucker
    {
        static string AccessKey { get; set; }
        const string BASE = "https://www.ferzu.com/Api";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessKey">Base64 encoded access key</param>
        public static void Init(string username, string password)
        {
            // they have some weird as shit basic auth shit going on
            var encodedPass = Base64Encode(password);
            var baseString = $"{username}:__b64__{encodedPass}";

            AccessKey = "Basic " + Base64Encode(baseString);

            FlurlHttp.Configure(c =>
            {
                c.BeforeCall = Authorize;
            });
        }

        private static void Authorize(HttpCall obj)
        {
            obj.Request.Headers.Add("Authorization", AccessKey);
        }

        async public static Task<List<Status>> GetNewsFeed(int page = 1, long? skip = null, int count = 20, bool skipAnnouncement = true, NewsFeedType list = NewsFeedType.Global)
        {
            var path = BASE.AppendPathSegments("List", "Newsfeed");
            switch(list){
                case NewsFeedType.Global:
                    path.AppendPathSegment("Global");
                    break;
                case NewsFeedType.Local:
                    path.AppendPathSegment("Local");
                    break;
            }

            if (skip.HasValue)
                path.SetQueryParam("skip", skip.Value);

            if (skipAnnouncement)
                count++;

            path.SetQueryParam("page", page);
            path.SetQueryParam("count", count);

            var statuses = (await path.GetJsonAsync<StatusRoot>()).Statuses;
            if (skipAnnouncement)
                statuses.RemoveAll(x => x.IsNotification == true);

            return statuses;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public enum NewsFeedType
        {
            Global,
            Local
        }
    }
}
