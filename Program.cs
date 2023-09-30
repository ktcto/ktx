/** KT开源社区 ktcto.com 使用MIT开源协议 */

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
builder.WebHost.UseUrls("http://*:5023", "https://*:44357", "http://*:80", "https://*:443");
var app = builder.Build();
app.MapReverseProxy();
app.Run();
