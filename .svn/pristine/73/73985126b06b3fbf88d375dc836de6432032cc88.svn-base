namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class viewUserRecords
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(128)]
        public string FullName { get; set; }

        public int? RegisterType { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime RegisterTime { get; set; }

        [StringLength(16)]
        public string ProvinceID { get; set; }

        [StringLength(16)]
        public string CityID { get; set; }

        [StringLength(16)]
        public string DistrictID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(32)]
        public string Phone { get; set; }

        public int? upcount { get; set; }

        public int? quotecount { get; set; }

        public int? okcount { get; set; }

        public int? cancelcount { get; set; }
    }
}
