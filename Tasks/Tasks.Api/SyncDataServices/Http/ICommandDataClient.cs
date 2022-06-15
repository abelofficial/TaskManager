using Tasks.Api.Models;

namespace Tasks.Api.SyncDataServices.Http;

public interface ICommandDataClient
{
    Task SendPlatformToCommand(User plat);
}
