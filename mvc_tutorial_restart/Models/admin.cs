namespace mvc_tutorial_restart.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        public int AdminID { get; set; }

        [StringLength(60)]
        public string Admin_Login { get; set; }

        [StringLength(60)]
        public string Secret { get; set; }
    }
}
