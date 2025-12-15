using Microsoft.Extensions.DependencyInjection;
using OperaMaster.View;
using OperaMaster.ViewModel;

namespace OperaMaster.Service;
internal static class RegisterViews
{
    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        services.AddTransient<LoginWindow>();
        services.AddTransient<MainWindow>();
        
        return services;
    }


    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddSingleton<MainWindowViewModel>();

        return services;
    }
}
