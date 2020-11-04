using System.Threading.Tasks;
using DynamicCorsPolicy.Resolvers;

namespace DynamicCorsPolicy.Tests.Resolvers
{
    public class FalseReturningCorsPolicyResolver : IDynamicCorsPolicyResolver
    {
        public async Task<bool> ResolveForOrigin(string origin)
        {
            return false;
        }
    }
}