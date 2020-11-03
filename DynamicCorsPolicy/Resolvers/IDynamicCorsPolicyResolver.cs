using System.Threading.Tasks;

namespace DynamicCorsPolicy.Resolvers
{
    public interface IDynamicCorsPolicyResolver
    {
        Task<bool> ResolveForOrigin(string origin);
    }
}