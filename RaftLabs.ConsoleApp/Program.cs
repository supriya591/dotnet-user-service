using RaftLabs.Core.Clients;
using RaftLabs.Core.Services;

var httpClient = new HttpClient();
var client = new ReqResClient(httpClient);
var service = new ExternalUserService(client);

var user = await service.GetUserByIdAsync(2);
Console.WriteLine($"User: {user.First_Name} {user.Last_Name} - {user.Email}");

var allUsers = await service.GetAllUsersAsync();
Console.WriteLine("\nAll Users:");
foreach (var u in allUsers)
{
    Console.WriteLine($"{u.Id}: {u.First_Name} {u.Last_Name}");
}