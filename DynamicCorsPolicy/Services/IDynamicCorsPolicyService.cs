using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;

namespace DynamicCorsPolicy.Services
{
    internal interface IDynamicCorsPolicyService
    {
        void ApplyResult(CorsResult result, HttpResponse response);

        Task<CorsResult> EvaluatePolicy(HttpContext context, CorsPolicy policy);
    }
}