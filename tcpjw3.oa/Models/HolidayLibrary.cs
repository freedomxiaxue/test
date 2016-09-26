namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HolidayLibrary")]
    public partial class HolidayLibrary
    {
        public int ID { get; set; }

        [StringLength(32)]
        public string HolidayName { get; set; }

        public DateTime HolidayStart { get; set; }

        public DateTime HolidayEnd { get; set; }
    }
}
