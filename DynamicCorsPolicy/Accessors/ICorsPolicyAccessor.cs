using Microsoft.AspNetCore.Cors.Infrastructure;

namespace DynamicCorsPolicy.Accessors
{
    public interface ICorsPolicyAccessor
    {
        CorsPolicy GetPolicy();
        CorsPolicy GetPolicy(string name);
    }
}