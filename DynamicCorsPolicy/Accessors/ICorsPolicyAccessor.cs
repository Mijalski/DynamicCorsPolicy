using Microsoft.AspNetCore.Cors.Infrastructure;

namespace DynamicCorsPolicy.Accessors
{
    internal interface ICorsPolicyAccessor
    {
        CorsPolicy GetPolicy();
        CorsPolicy GetPolicy(string name);
    }
}