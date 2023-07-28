using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LittleCash.Infra.Extensions;

public static class OptionsExtensions
{
    public static void AddSettings<T>(this IServiceCollection serviceCollection, IConfiguration rootConfiguration,
        string? sectionName = null)
        where T : class
    {
        var configuration = rootConfiguration.GetSection(sectionName ?? typeof(T).Name);
        serviceCollection.AddOptions<T>().Bind(configuration);
        var settings = Activator.CreateInstance(typeof(T), new object[] { });
        if (settings == null) throw new ArgumentNullException(nameof(settings));
        configuration.Bind(settings);
    }
    
    public static T GetSettingsBySection<T>(this IConfiguration rootConfiguration, string? sectionName = null)
        where T : class
    {
        var configuration = rootConfiguration.GetSection(sectionName ?? typeof(T).Name);
        var settings = Activator.CreateInstance(typeof(T), new object[] { });
        if (settings == null) throw new ArgumentNullException(nameof(settings));
        configuration.Bind(settings);
        return (settings as T)!;
    }
}