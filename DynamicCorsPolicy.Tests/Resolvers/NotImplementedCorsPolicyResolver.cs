using System.Threading.Tasks;
using DynamicCorsPolicy.Resolvers;

namespace DynamicCorsPolicy.Tests.Resolvers
{
    public class NotImplementedCorsPolicyResolver : IDynamicCorsPolicyResolver
    {
        public Task<bool> ResolveForOrigin(string origin)
        {
            throw new System.NotImplementedException();
        }
    }
}