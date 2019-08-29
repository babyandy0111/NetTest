using System.ComponentModel.DataAnnotations.Schema;

namespace AndyNetTest.Entities.UsersAndInfo
{
    [Table("users")]
    public class UsersAndInfo
    {
        [Column("id")]
        public int ID { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("address")]
        public string Address { get; set; }
    }
}