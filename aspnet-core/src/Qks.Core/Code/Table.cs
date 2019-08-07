using System.ComponentModel.DataAnnotations.Schema;

namespace Qks.Code
{
    [Table("SysTables")]
    public class Table : FullEntity
    {
        public string Name { get; set; }

        public string DbName { get; set; }

        public string Namespace { get; set; }

        public Table()
        {
            
        }
    }
}
