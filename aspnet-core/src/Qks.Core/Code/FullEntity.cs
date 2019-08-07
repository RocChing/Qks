using Abp.Domain.Entities.Auditing;

namespace Qks.Code
{
    public class FullEntity<TKey> : FullAuditedEntity<TKey>
    {
        public int Order { get; set; }

        public string Description { get; set; }

        public FullEntity()
        {
            Order = QksConsts.DefaultOrderValue;
        }
    }

    public class FullEntity : FullEntity<int>
    {

    }
}
