using System.Globalization;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using YoutubeApi.Application.Exceptions;
using FluentValidation;
using MediatR;
using YoutubeApi.Application.Behaviors;

namespace YoutubeApi.Application;

public static class Registration
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddTransient<ExceptionMiddleware>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(assembly);
        ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr-TR");
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));
    }
}
