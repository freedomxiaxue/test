namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BAT_TradingRecords
    {
        public int ID { get; set; }

        public int JYQQBH { get; set; }

        [StringLength(2)]
        public string ZXZT { get; set; }

        public DateTime? CZSJ { get; set; }

        public int? CZR { get; set; }
    }
}
