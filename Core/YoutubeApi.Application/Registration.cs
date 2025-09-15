using System.Globalization;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using YoutubeApi.Application.Exceptions;
using FluentValidation;
using MediatR;
using YoutubeApi.Application.Bases;
using YoutubeApi.Application.Behaviors;
using YoutubeApi.Application.Features.Products.Rules;

namespace YoutubeApi.Application;

public static class Registration
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddTransient<ExceptionMiddleware>();
        services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(assembly);
        ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr-TR");
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
    }

    private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services,
        Assembly assembly, Type type)
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
            services.AddTransient(item);
        return services;
    }
    
}
