namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BAT_CapitalDealInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int YHBH { get; set; }

        public int? JYCGS { get; set; }

        public int? JYSBS { get; set; }

        public int? PJJYHS { get; set; }
    }
}
