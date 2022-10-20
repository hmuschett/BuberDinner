
using buberDinner.Application.Services.Authentication.Commands;
using buberDinner.Application.Services.Authentication.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace buberDinner.Application;

public static class DependencyInjection{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        
        return services;
    }
}