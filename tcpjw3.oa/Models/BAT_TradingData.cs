namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BAT_TradingData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public decimal CountM { get; set; }

        public decimal YesDayCountM { get; set; }

        [Required]
        [StringLength(100)]
        public string AvergeTime { get; set; }

        public DateTime OperTime { get; set; }

        [StringLength(100)]
        public string backup1 { get; set; }

        [StringLength(100)]
        public string backup2 { get; set; }

        [StringLength(100)]
        public string backup3 { get; set; }
    }
}
