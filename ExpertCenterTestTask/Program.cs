using ExpertCenterTestTask.ActionResult;
using ExpertCenterTestTask.Extensions;
using ExpertCenterTestTask.Hubs;
using ExpertCenterTestTask.Notifiers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting();
builder.Services.AddCategoryCrudServices();
builder.Services.AddControllers();
builder.AddApplicationContext();
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddTransient<PriceListNotifier>();
builder.Services.AddTransient<PriceListNotifier2>();

builder.Services.AddTransient(provider =>
{
	return new Func<string, HtmlResult>(
		path => ActivatorUtilities.CreateInstance<HtmlResult>(provider, path));
});

var app = builder.Build();
app.UseRouting();
app.MapControllers();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDefaultFiles();

app.UseAuthorization();

app.MapRazorPages();
app.MapHub<NotificationHub>(NotificationHub.Path);

app.Run();