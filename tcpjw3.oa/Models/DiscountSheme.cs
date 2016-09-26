namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiscountSheme")]
    public partial class DiscountSheme
    {
        [Key]
        public int D_ID { get; set; }

        [StringLength(10)]
        public string UserName { get; set; }

        [StringLength(20)]
        public string D_Phone { get; set; }

        public decimal? D_Bill { get; set; }

        public DateTime? D_Time { get; set; }

        [StringLength(50)]
        public string ProvinceValue { get; set; }

        [StringLength(50)]
        public string CityValue { get; set; }

        public bool? Status { get; set; }

        [StringLength(255)]
        public string ALNote { get; set; }
    }
}
