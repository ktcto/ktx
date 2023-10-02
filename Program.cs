/** KT开源社区 ktcto.com 使用MIT开源协议 */
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
//用https://访问虚拟域名时，需要先运行命令生成本地自签名证书 dotnet dev-certs https --trust
//builder.WebHost.UseUrls("http://*:80", "https://*:443");
//builder.WebHost.UseUrls("http://*:80;https://*:443");
//builder.WebHost.UseUrls("http://*:80"); //用http://访问虚拟域名时，不需要生成本地自签名证书
var Listen = builder.Configuration.GetValue<string>("Listen") ?? "http://*:80";
builder.WebHost.UseUrls(Listen);
var app = builder.Build();
app.MapReverseProxy();
app.Run();

