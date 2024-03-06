using Microsoft.AspNetCore.SignalR;

namespace ExpertCenterTestTask.Hubs;

public class NotificationHub : Hub
{
    public const string Path = "/Hubs/Notification";

    public async Task SubsrcribeAsync(string groupName)
        => await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
}