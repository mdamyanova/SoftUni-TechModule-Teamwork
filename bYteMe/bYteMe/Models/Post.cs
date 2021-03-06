namespace bYteMe
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Post
    {      
        public Post()
        {
            this.Date = DateTime.Now;
        }

        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }
        
        [Column(Order = 1)]
        public string AuthorId { get; set; }

        [Column(Order = 2)]
        [StringLength(200)]
        public string Title { get; set; }
    
        [Column(Order = 3, TypeName = "ntext")]
        public string Body { get; set; }
    
        [Column(Order = 4)]
        public DateTime Date { get; set; }
    }
}