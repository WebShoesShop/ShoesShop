namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Carts = new HashSet<Cart>();
            Transactions = new HashSet<Transaction>();
        }

        public int userId { get; set; }

        [StringLength(100)]
        public string userName { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(15)]
        public string phoneNum { get; set; }

        [StringLength(100)]
        public string address { get; set; }

        [Column(TypeName = "money")]
        public decimal? money { get; set; }

        [StringLength(150)]
        public string userAva { get; set; }

        public bool? flag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
