namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SysStatic")]
    public partial class SysStatic
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Text { get; set; }

        [StringLength(64)]
        public string Value { get; set; }

        public int? PID { get; set; }

        public int Sort { get; set; }

        public bool IsRoot { get; set; }

        [StringLength(255)]
        public string Note { get; set; }
    }
}
