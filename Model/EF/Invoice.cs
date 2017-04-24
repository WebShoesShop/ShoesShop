namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invoice")]
    public partial class Invoice
    {
        public int invoiceId { get; set; }

        public int? cartId { get; set; }

        public DateTime? dateOfPayment { get; set; }

        [Column(TypeName = "money")]
        public decimal? totalAmount { get; set; }

        public int? methodId { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual Method Method { get; set; }
    }
}
