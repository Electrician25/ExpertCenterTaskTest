using ExpertCenterTestTask.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace ExpertCenterTestTask.Notifiers;

public abstract class Notifier
{
	public const string ReceiveClientMethodName = "Receive";
	protected readonly IHubContext<NotificationHub> HubContext;

	public Notifier(IHubContext<NotificationHub> hubContext)
	{
		HubContext = hubContext;
	}

	public abstract string GroupName { get; }

	protected async Task Notify<T>(string dataType, T data)
		=> await HubContext.Clients.Group(GroupName)
			.SendAsync(ReceiveClientMethodName, GroupName, dataType, data);
}