namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BAT_ParValueInfo
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JYQQBH { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Pvid { get; set; }

        public decimal? PMJE { get; set; }

        public DateTime? DQR { get; set; }

        [StringLength(200)]
        public string CDHQC { get; set; }

        [StringLength(500)]
        public string PMJT { get; set; }

        public decimal? CJYLL { get; set; }

        public decimal? CJMSWJG { get; set; }

        public decimal? CJJG { get; set; }
    }
}
