using RaftLabs.Core.Clients;
using RaftLabs.Core.Models;

namespace RaftLabs.Core.Services
{
    public class ExternalUserService
    {
        private readonly ReqResClient _client;

        public ExternalUserService(ReqResClient client)
        {
            _client = client;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _client.GetUserByIdAsync(userId);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _client.GetAllUsersAsync();
        }
    }
}