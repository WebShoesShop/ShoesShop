namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        public int adminId { get; set; }

        [StringLength(100)]
        public string adminName { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(50)]
        public string password { get; set; }

        public int? role { get; set; }
    }
}
