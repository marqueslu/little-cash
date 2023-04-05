using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LittleCash.CrossCutting.Extensions;

public static class OptionsExtensions
{
    public static void AddOptions<T>(this IServiceCollection serviceCollection, IConfiguration rootConfiguration,
        string? sectionName = null) where T : class
    {
        var configuration = rootConfiguration.GetSection(sectionName ?? typeof(T).Name);
        serviceCollection.AddOptions<T>().Bind(configuration);
    }

    public static T GetOptionsBySection<T>(this IConfiguration rootConfiguration, string? sectionName = null)
        where T : class
    {
        var configuration = rootConfiguration.GetSection(sectionName ?? typeof(T).Name);
        var options = Activator.CreateInstance(typeof(T), new object[] { });
        if (options is null) throw new ArgumentNullException(nameof(options));
        configuration.Bind(options);
        return (options as T)!;
    }
}