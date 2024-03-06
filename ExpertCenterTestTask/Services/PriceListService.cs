//using ExpertCenterTestTask.Data;
//using ExpertCenterTestTask.Entities;
//using ExpertCenterTestTask.Hubs;
//using Microsoft.AspNetCore.SignalR;

//namespace ExpertCenterTestTask.Services;

//public class PriceListService
//{
//    private readonly ApplicationContext _applicationContext;
//    private readonly IHubContext<PriceListHub> _hubContext;

//    public PriceListService(ApplicationContext applicationContext, IHubContext<PriceListHub> hubContext)
//    {
//        _applicationContext = applicationContext;
//        _hubContext = hubContext;
//    }

//    public async Task AddPriceListAsync(PriceList priceList)
//    {
//        try
//        {
//            await _applicationContext.AddAsync(priceList);
//            _hubContext.Clients.All.SendAsync("ReceiveInfo",

//        }
//        catch (Exception ex)
//        {

//        }
//        // repository add
//        // notify hub
//    }
//}

//// hub subscribe
// Handle. SendTo("groupName":, onreceive, nameof(T), T);