using ExpertCenterTestTask.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace ExpertCenterTestTask.Notifiers;

public class PriceListNotifier2 : Notifier
{
    public PriceListNotifier2(IHubContext<NotificationHub> hubContext) : base(hubContext) { }

    public override string GroupName => "ws";

    public async Task NotifyDeletionAsync(float ids)
        => await Notify(nameof(Single), ids);

    public async Task NotifyUpdatingAsync(double db)
        => await Notify(nameof(Double), db);
}