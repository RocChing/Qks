using System.ComponentModel.DataAnnotations.Schema;
namespace Qks.Code
{
    [Table("SysColumns")]
    public class Column : FullEntity
    {
        public string Name { get; set; }

        public string FieldName { get; set; }

        public string Type { get; set; }

        public int Length { get; set; }

        public bool IsPrimaryKey { get; set; }

        public bool IsNull { get; set; }
    }
}
