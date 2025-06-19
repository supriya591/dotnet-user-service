using RaftLabs.Core.Models;
using System.Net.Http;
using System.Text.Json;

namespace RaftLabs.Core.Clients
{
    public class ReqResClient
    {
        private readonly HttpClient _httpClient;

        public ReqResClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://reqres.in/api/");
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"users/{id}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($"User not found: {id}");

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<SingleUserResponse>(
                content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return result?.Data;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = new List<User>();
            int page = 1;

            while (true)
            {
                var response = await _httpClient.GetAsync($"users?page={page}");
                if (!response.IsSuccessStatusCode) break;

                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<UserResponse>(
                    content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                if (result?.Data == null || result.Data.Count == 0) break;

                users.AddRange(result.Data);

                if (page >= result.Total_Pages) break;
                page++;
            }

            return users;
        }
    }
}