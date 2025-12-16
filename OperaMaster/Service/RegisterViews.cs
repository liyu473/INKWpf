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
        services.AddTransient<LaserParameterView>();
        services.AddTransient<SettingsView>();
        
        return services;
    }


    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<LaserParameterViewModel>();
        services.AddSingleton<SettingsViewModel>();

        return services;
    }
}
