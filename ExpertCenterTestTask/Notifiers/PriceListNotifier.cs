using ExpertCenterTestTask.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace ExpertCenterTestTask.Notifiers;

public class PriceListNotifier : Notifier
{
    public PriceListNotifier(IHubContext<NotificationHub> hubContext) : base(hubContext) { }

    public override string GroupName => "PriceList";

    public async Task NotifyDeletionAsync(List<int> ids)
        => await Notify(nameof(List<int>), ids);

    public async Task NotifyUpdatingAsync(string str)
        => await Notify(nameof(String), str);
}