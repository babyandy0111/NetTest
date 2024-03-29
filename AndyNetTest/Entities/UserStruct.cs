﻿using System.ComponentModel.DataAnnotations.Schema;

namespace AndyNetTest.Entities.Users
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