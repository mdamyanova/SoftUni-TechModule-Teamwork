namespace bYteMe
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [Key]
        [Column(Order = 0)]
        public int OrderId { get; set; }

        
        [Column(Order = 1)]
        public byte[] Photo { get; set; }

        
        [Column(Order = 2, TypeName = "ntext")]
        public string Description { get; set; }

       
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RequiredDislikes { get; set; }
    }
}
