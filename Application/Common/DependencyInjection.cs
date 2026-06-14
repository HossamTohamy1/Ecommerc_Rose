// Application/DependencyInjection.cs
using Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers MediatR, FluentValidation validators, and the ValidationBehaviour
        /// pipeline for the Application layer.
        /// Call this from Program.cs: builder.Services.AddApplicationServices();
        /// </summary>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            // ── MediatR ──────────────────────────────────────────────────
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(assembly);

                // Validation runs before every handler automatically
                cfg.AddBehavior(typeof(IPipelineBehavior<,>),
                                typeof(ValidationBehaviour<,>));
            });

            // ── FluentValidation — scan & register all validators ────────
            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}