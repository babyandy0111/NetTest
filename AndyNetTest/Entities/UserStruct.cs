using System.ComponentModel.DataAnnotations.Schema;

namespace Snai.Mysql.Entities
{
    [Table("users")]
    public class Users
    {
        [Column("id")]
        public int ID { get; set; }

        [Column("name")]
        public string Name { get; set; }
    }
}