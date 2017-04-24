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
        [Display (Name = "Ten dang nhap")]
        public string adminName { get; set; }

        [StringLength(100)]
        [Display(Name = "Email")]
        public string email { get; set; }

        [StringLength(50)]
        [Display(Name = "Mat khau")]
        public string password { get; set; }
        [Display(Name = "Quyen truy cap")]
        public int? role { get; set; }
    }
}
