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
        [Display(Name ="Admin Name")]
        public string adminName { get; set; }

        [StringLength(100)]
        [Display(Name = "Email")]
        public string email { get; set; }

        [StringLength(50)]
        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "Role")]
        public int? role { get; set; }
    }
}
