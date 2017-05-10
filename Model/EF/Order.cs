namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [Key]
        public int OderID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CustomerID { get; set; }

        [StringLength(50)]
        public string ShipName { get; set; }

        [MaxLength(50)]
        public byte[] ShipMobile { get; set; }

        [StringLength(50)]
        public string ShipAdress { get; set; }

        [StringLength(50)]
        public string ShipEmail { get; set; }

        public int? Status { get; set; }
    }
}
