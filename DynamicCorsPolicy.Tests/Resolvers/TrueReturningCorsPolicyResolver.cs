using System.Threading.Tasks;
using DynamicCorsPolicy.Resolvers;

namespace DynamicCorsPolicy.Tests.Resolvers
{
    public class TrueReturningCorsPolicyResolver : IDynamicCorsPolicyResolver
    {
        public async Task<bool> ResolveForOrigin(string origin)
        {
            return true;
        }
    }
}