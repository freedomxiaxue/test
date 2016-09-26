namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Enroll")]
    public partial class Enroll
    {
        public int ID { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        public string Email { get; set; }

        [StringLength(128)]
        public string Note { get; set; }

        [Required]
        [StringLength(128)]
        public string Company { get; set; }

        [Required]
        [StringLength(128)]
        public string Department { get; set; }

        [Required]
        [StringLength(32)]
        public string Phone { get; set; }

        public DateTime JoinTime { get; set; }
    }
}
