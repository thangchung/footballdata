using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CiK.FootballData
{
    /// <summary>
    /// http://pastebin.com/raw/mqsegRyd
    /// </summary>
    public class SimpleRequest
    {
        public static HttpClient NewClient(Protocol protocol, string apiKey)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri($"{protocol.GetProtocolByString()}://{FootballDataClient.FootballDataApiUrl}");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrWhiteSpace(apiKey))
                client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);

            return client;
        }

        public static async Task<T> GetPayloadAsync<T>(HttpResponseMessage response) where T : class
        {
            var payload = await response.Content.ReadAsStringAsync();
            return Deserialize<T>(payload);
        }

        public static T Deserialize<T>(string payload) where T : class => JsonConvert.DeserializeObject<T>(payload);

        public static string Serialize<T>(T obj) => JsonConvert.SerializeObject(obj);

        public static HttpContent JsonPayload<T>(T obj) where T : class
            => new StringContent(Serialize(obj), Encoding.UTF8, "application/json");

        public async Task<T> GetAsync<T>(string path, string apiKey, Protocol protocol = Protocol.HTTP) where T : class
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            var client = NewClient(protocol, apiKey);
            var response = await client.GetAsync(path);
            var data = await GetPayloadAsync<T>(response);

            return data;
        }
    }
}