using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace Qks.Code
{
    public class ColumnDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string FieldName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        public int MaxLength { get; set; }

        public bool IsPrimaryKey { get; set; }

        public bool IsAllowNull { get; set; }

        public int TableId { get; set; }
    }
}
