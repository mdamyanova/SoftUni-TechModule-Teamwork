namespace bYteMe
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

     
        [Column(Order = 1)]
        [StringLength(50)]
        public string Username { get; set; }

       
        [Column(Order = 2)]
        [StringLength(100)]
        public string FullName { get; set; }

       
        [Column(Order = 3)]
        [MaxLength(64)]
        public byte[] PasswordHash { get; set; }

        
        [Column(Order = 4)]
        public byte[] ProfilePhoto { get; set; }

        [Column(TypeName = "ntext")]
        public string Biography { get; set; }

        public int? Likes { get; set; }

        public int? Dislikes { get; set; }
    }
}
