using Xunit;

namespace Qks.Tests
{
    public sealed class MultiTenantFactAttribute : FactAttribute
    {
        public MultiTenantFactAttribute()
        {
            //if (!QksConsts.MultiTenancyEnabled)
            //{
            //    Skip = "MultiTenancy is disabled.";
            //}
        }
    }
}
