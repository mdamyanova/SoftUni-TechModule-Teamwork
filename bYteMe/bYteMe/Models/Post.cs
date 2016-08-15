namespace bYteMe
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Post
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AuthorId { get; set; }
        
        [Column(Order = 1)]
        public int PostId { get; set; }

  
        [Column(Order = 2)]
        [StringLength(200)]
        public string Title { get; set; }

    
        [Column(Order = 3, TypeName = "ntext")]
        public string Body { get; set; }

    
        [Column(Order = 4)]
        public DateTime Date { get; set; }
    }
}
