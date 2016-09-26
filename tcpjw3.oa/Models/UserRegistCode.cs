namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserRegistCode")]
    public partial class UserRegistCode
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(6)]
        public string Code { get; set; }

        public DateTime ExecTime { get; set; }

        public DateTime EndTime { get; set; }

        public int VerifyState { get; set; }
    }
}
