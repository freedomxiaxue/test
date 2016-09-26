namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserCenter")]
    public partial class UserCenter
    {
        public int ID { get; set; }

        [StringLength(128)]
        public string Email { get; set; }

        [Required]
        [StringLength(32)]
        public string Phone { get; set; }

        [Required]
        [StringLength(32)]
        public string Password { get; set; }

        public DateTime RegisterTime { get; set; }

        [StringLength(32)]
        public string RegisterIP { get; set; }

        public DateTime? LastLoginTime { get; set; }

        [StringLength(32)]
        public string LastLoginIP { get; set; }

        public int LoginType { get; set; }

        public int UserState { get; set; }

        [StringLength(128)]
        public string Question1 { get; set; }

        [StringLength(128)]
        public string Question2 { get; set; }

        [StringLength(128)]
        public string Question3 { get; set; }

        [StringLength(128)]
        public string Answer1 { get; set; }

        [StringLength(128)]
        public string Answer2 { get; set; }

        [StringLength(128)]
        public string Answer3 { get; set; }

        [StringLength(128)]
        public string Salt { get; set; }

        [StringLength(128)]
        public string Note { get; set; }

        public int? LoginMode { get; set; }
    }
}
