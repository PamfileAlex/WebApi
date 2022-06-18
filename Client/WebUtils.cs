using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client
{
    public static class WebUtils
    {
        private static readonly HttpClient _httpClient;
        private static JsonSerializerOptions Options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        static WebUtils()
        {
            _httpClient = new();
            _httpClient.DefaultRequestHeaders.Add("Accept", "text/plain");
        }

        public static async Task<T> GetAsyncJson<T>(string url)
        {
            string message = await GetAsyncText(url);
            return JsonSerializer.Deserialize<T>(message, Options);
        }

        public static async Task<string> GetAsyncText(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Request not successful!");
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
