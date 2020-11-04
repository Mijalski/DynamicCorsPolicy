using System.Threading.Tasks;

namespace DynamicCorsPolicy.Resolvers
{
    public class DefaultDynamicCorsPolicyResolver : IDynamicCorsPolicyResolver
    {
        /// <summary>
        /// Returns always false
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public async Task<bool> ResolveForOrigin(string origin)
        {
            return false;
        }
    }
}