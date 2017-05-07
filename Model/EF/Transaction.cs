namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaction")]
    public partial class Transaction
    {
        public int transactionId { get; set; }

        public DateTime? transactionTime { get; set; }

        public int? methodId { get; set; }

        [Column(TypeName = "money")]
        public decimal? money { get; set; }

        public int? userId { get; set; }

        public virtual User User { get; set; }
    }
}
