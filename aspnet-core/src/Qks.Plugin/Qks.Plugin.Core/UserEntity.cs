using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Qks.Plugin.Core
{
    [Table("QksUsers")]
    public class UserEntity : FullAuditedEntity
    {
        [MaxLength(200)]
        public string Name { get; set; }

        public int Age { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; }
    }
}
