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

        [Display(Name ="Time")]
        public DateTime? transactionTime { get; set; }

        [Display(Name ="Method")]
        public int? methodId { get; set; }

        [Column(TypeName = "money")]
        [Display(Name ="Money")]
        public decimal? money { get; set; }

        [Display(Name ="User")]
        public int? userId { get; set; }

        public virtual Method Method { get; set; }

        public virtual User User { get; set; }
    }
}
