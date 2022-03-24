using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Template.Application.Common.Behaviours;
using Template.WebUI.Shared.Common.Behaviours;

namespace Template.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly())
                    .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                    .AddMediatR(Assembly.GetExecutingAssembly())
                    .AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>))
                    .AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>))
                    .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>))
                    .AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
                    //.AddTransient<ITokenGeneratorService, TokenGeneratorService>();

            return services;
        }
    }
}
