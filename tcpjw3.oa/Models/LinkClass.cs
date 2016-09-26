namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LinkClass")]
    public partial class LinkClass
    {
        public int ID { get; set; }

        [Required]
        [StringLength(128)]
        public string ClassName { get; set; }

        public bool IsLock { get; set; }

        public int Sort { get; set; }
    }
}
