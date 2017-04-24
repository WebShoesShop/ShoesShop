namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductImage
    {
        [Key]
        public int imgId { get; set; }

        [StringLength(150)]
        public string imgAbsolutPath { get; set; }

        public bool? flag { get; set; }

        public int? productId { get; set; }

        public virtual Product Product { get; set; }
    }
}
