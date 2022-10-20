
using buberDinner.Application.Services.Authentication.Commands;
using buberDinner.Application.Services.Authentication.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace buberDinner.Application;

public static class DependencyInjection{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        return services;
    }
}