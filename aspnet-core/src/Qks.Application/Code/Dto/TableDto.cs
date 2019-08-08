using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace Qks.Code
{
    public class TableDto : EntityDto<int>
    {
        [Required]
        [MaxLength(QksConsts.Field.Len50)]
        public string Name { get; set; }

        [MaxLength(QksConsts.Field.Len50)]
        public string DbName { get; set; }

        [Required]
        [MaxLength(QksConsts.Field.Len200)]
        public string Namespace { get; set; }

        [Required]
        [MaxLength(QksConsts.Field.Len50)]
        public string ServiceName { get; set; }

        [Required]
        [MaxLength(QksConsts.Field.Len50)]
        public string DtoName { get; set; }

        [MaxLength(QksConsts.Field.Len50)]
        public string AuthorizeName { get; set; }

        [MaxLength(QksConsts.Field.Len50)]
        public string GetAllInputName { get; set; }

        [MaxLength(QksConsts.Field.Len50)]
        public string CreateInputName { get; set; }

        [MaxLength(QksConsts.Field.Len50)]
        public string UpdateInputName { get; set; }

        [MaxLength(QksConsts.Field.Len100)]
        public string CreatePermissionName { get; set; }
        [MaxLength(QksConsts.Field.Len100)]
        public string GetAllPermissionName { get; set; }
        [MaxLength(QksConsts.Field.Len100)]
        public string GetPermissionName { get; set; }
        [MaxLength(QksConsts.Field.Len100)]
        public string UpdatePermissionName { get; set; }
        [MaxLength(QksConsts.Field.Len100)]
        public string DeletePermissionName { get; set; }

        public List<ColumnDto> Columns { get; set; }
    }
}
