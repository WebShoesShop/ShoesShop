namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            CartDetails = new HashSet<CartDetail>();
            ProductImages = new HashSet<ProductImage>();
        }

        public int productId { get; set; }

        [StringLength(100)]
        [Display(Name = "Produce Name")]
        public string productName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]
        public DateTime? releaseDate { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM/dd/yyyy")]
        [Display(Name = "Start Date")]
        public DateTime? startDate { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Price")]
        public decimal? price { get; set; }

        [Display(Name = "Manafacturer")]
        public int? manufacturerId { get; set; }

        [Display(Name = "Category")]
        public int? categoryId { get; set; }

        [Display(Name = "Is Available")]
        public bool? isAvailable { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Introduction")]
        public string introduction { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Description")]
        public string description { get; set; }

        [StringLength(100)]
        public string productAva { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartDetail> CartDetails { get; set; }

        public virtual Category Category { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
