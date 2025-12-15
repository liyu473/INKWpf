using LogExtension.Builder;
using LogExtension.Extensions;
using LyuEModbus.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OperaMaster.Service;
using OperaMaster.View;
using System.Windows;
using ZLogger;
using ZLogger.Providers;

namespace OperaMaster;

public partial class App : Application
{
    private IHost? _host;
    private ILogger<App>? _logger;

    public static IServiceProvider Services { get; private set; } = null!;

    #region 服务获取方法

    /// <summary>
    /// 获取指定类型的服务
    /// </summary>
    public static T GetService<T>()
        where T : notnull => Services.GetRequiredService<T>();

    /// <summary>
    /// 尝试获取指定类型的服务
    /// </summary>
    public static T? GetServiceOrDefault<T>()
        where T : class => Services.GetService<T>();

    /// <summary>
    /// 获取配置对象
    /// </summary>
    public static IConfiguration GetConfiguration() =>
        Services.GetRequiredService<IConfiguration>();

    /// <summary>
    /// 获取指定类型的 Logger
    /// </summary>
    public static ILogger<T> GetLogger<T>() => Services.GetRequiredService<ILogger<T>>();

    #endregion

    public App()
    {
        SetupExceptionHandling();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        _host = CreateHostBuilder(e.Args).Build();
        Services = _host.Services;
        _logger = Services.GetRequiredService<ILogger<App>>();

        await _host.StartAsync();

        var loginWindow = Services.GetRequiredService<LoginWindow>();
        if (loginWindow.ShowDialog() == true)
        {
            ShutdownMode = ShutdownMode.OnMainWindowClose;
            var mainWindow = Services.GetRequiredService<MainWindow>();
            MainWindow = mainWindow;
            mainWindow.Show();
        }
        else
        {
            Shutdown();
        }
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        if (_host is not null)
        {
            await _host.StopAsync();
            _host.Dispose();
        }

        base.OnExit(e);
    }

    /// <summary>
    /// 创建并配置 Host 构建器
    /// </summary>
    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(ConfigureAppConfiguration)
            .ConfigureServices(ConfigureServices);

    /// <summary>
    /// 配置应用程序配置源
    /// </summary>
    private static void ConfigureAppConfiguration(
        HostBuilderContext context,
        IConfigurationBuilder config
    )
    {
        config
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile(
                $"appsettings.{context.HostingEnvironment.EnvironmentName}.json",
                optional: true,
                reloadOnChange: true
            );
    }

    /// <summary>
    /// 注册服务
    /// </summary>
    private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddSingleton(context.Configuration);

        services.AddViews().AddViewModels();

        services.AddZLogger(builder =>
            builder
                .WithRetentionDays(30) //保留30天
                .WithCleanupInterval(TimeSpan.FromHours(2))
                .FilterMicrosoft()
                .FilterSystem()
                .WithRollingInterval(RollingInterval.Hour) // 按小时滚动
                .WithRollingSizeKB(10 * 1024) // 单文件最大 10MB
                .AddInfoOutput()
                .AddFileOutput(
                    "logs/trace",
                    LogLevel.Trace,
                    LogLevel.Critical,
                    RollingInterval.Hour,
                    50 * 1024
                )
                .WithoutGlobalFilters()
                .WithOutputFilter("System", LogLevel.Information)
                .WithOutputFilter("Microsoft", LogLevel.Information)
        );

        services.AddModbus(); // 暂时不创建预主站
    }

    /// <summary>
    /// 设置全局异常捕获
    /// </summary>
    private void SetupExceptionHandling()
    {
        // UI 线程未处理异常
        DispatcherUnhandledException += (s, e) =>
        {
            _logger?.ZLogError($"UI线程异常{e.Exception}");
            e.Handled = true;
        };

        // 非 UI 线程未处理异常
        AppDomain.CurrentDomain.UnhandledException += (s, e) =>
        {
            _logger?.ZLogError($"非UI线程异常{e.ExceptionObject as Exception}");
        };

        // Task 未观察到的异常
        TaskScheduler.UnobservedTaskException += (s, e) =>
        {
            _logger?.ZLogError($"Task异常{e.Exception}");
            e.SetObserved();
        };
    }
}
