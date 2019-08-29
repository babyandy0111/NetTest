using System.ComponentModel.DataAnnotations.Schema;

namespace AndyNetTest.Entities.UserInfo
{
    [Table("user_info")]
    public class UserInfo
    {
        [Column("id")]
        public int ID { get; set; }

        [Column("address")]
        public string Address { get; set; }
    }
}
