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

        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "Admin Name")]
        [Required(ErrorMessage = "Ten admin sai")]
        public string adminName { get; set; }

        [StringLength(100)]
        [Display(Name = "Email")]
        public string email { get; set; }

        [StringLength(50)]
        [Display(Name = "Password")]
        [Required]
        public string password { get; set; }

        [Display(Name = "Role")]
        [Range(0, 1, ErrorMessage = "ban chi dc nhap 0 hoac 1")]
        public int? role { get; set; }
    }
}
