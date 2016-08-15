namespace bYteMe
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Photo
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AuthorId { get; set; }

        [Column(Order = 1)]
        public int PhotoId { get; set; }

        [Column("Photo", Order = 2)]
        public byte[] PhotoPicture { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }
    }
}
