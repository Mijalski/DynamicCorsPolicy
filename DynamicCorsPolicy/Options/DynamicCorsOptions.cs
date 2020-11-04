using System;
using System.Threading.Tasks;
using DynamicCorsPolicy.Resolvers;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace DynamicCorsPolicy.Options
{
    public class DynamicCorsOptions : CorsOptions
    {
        private IDynamicCorsPolicyResolver _dynamicCorsPolicyResolver;

        public void AddDynamicCorsPolicyResolver(
            IDynamicCorsPolicyResolver dynamicCorsPolicyResolver)
        {
            _dynamicCorsPolicyResolver = dynamicCorsPolicyResolver;
        }

        public IDynamicCorsPolicyResolver GetDynamicCorsPolicyResolver()
        {
            return _dynamicCorsPolicyResolver;
        }
    }
}