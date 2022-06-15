using System.Text;
using System.Text.Json;
using Tasks.Api.Models;

namespace Tasks.Api.SyncDataServices.Http;

public class HttpCommandDataClient : ICommandDataClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task SendPlatformToCommand(User dto)
    {
        var httpContent = new StringContent(
                JsonSerializer.Serialize(new { Id = 0, Email = dto.Email, Username = dto.FullName }),
                Encoding.UTF8,
                "application/json");

        var response = await _httpClient.PostAsync($"http://localhost:5206/users", httpContent);

        Console.WriteLine("--> \n\nResponse:" + await response.Content.ReadAsStringAsync());

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("--> Sync POST to CommandService was OK!");
        }
        else
        {
            Console.WriteLine("--> \n\nSync POST to CommandService was NOT OK!\n\n" + response.Content);
            throw new HttpRequestException("Bad request");
        }
    }
}