using CardGame.Ui.Services;
using Entities.Models;

namespace CardGame.Ui.Extensions;
public static class ServiceExtensions
{
    public static void ConfigureCardHistory(this IServiceCollection services) => services.AddScoped<CardHistory>();
    public static void ConfigureServiceManager(this IServiceCollection services) => services.AddScoped<IRequestService, RequestService>();
}
