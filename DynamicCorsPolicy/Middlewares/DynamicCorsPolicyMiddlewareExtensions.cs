using System;
using DynamicCorsPolicy.Accessors;
using DynamicCorsPolicy.Enums;
using DynamicCorsPolicy.Resolvers;
using DynamicCorsPolicy.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace DynamicCorsPolicy.Middlewares
{

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class DynamicCorsPolicyMiddlewareExtensions
    {
        public static IApplicationBuilder UseDynamicCorsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DynamicCorsPolicyMiddleware>();
        }

        public static IServiceCollection AddDynamicCors<TDynamicCorsPolicyResolver>(this IServiceCollection services, 
            Action<CorsOptions> setupAction)
            where TDynamicCorsPolicyResolver : class, IDynamicCorsPolicyResolver
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            services.TryAdd(ServiceDescriptor.Transient<IDynamicCorsPolicyService, DynamicCorsPolicyService>());
            services.TryAdd(ServiceDescriptor.Transient<ICorsPolicyAccessor, CorsPolicyAccessor>());
            services.TryAdd(ServiceDescriptor.Transient<IDynamicCorsPolicyResolver, TDynamicCorsPolicyResolver>());

            services.AddOptions();
            services.AddSingleton<IConfigureOptions<CorsOptions>>(
                new ConfigureNamedOptions<CorsOptions>(CorsPoliciesEnums.DynamicCorsPolicyName, setupAction)
            );

            return services;
        }
    }
}