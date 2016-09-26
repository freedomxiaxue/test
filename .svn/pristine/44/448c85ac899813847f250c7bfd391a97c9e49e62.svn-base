namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Link")]
    public partial class Link
    {
        public int ID { get; set; }

        [Required]
        [StringLength(128)]
        public string LinkName { get; set; }

        [StringLength(256)]
        public string LinkUrl { get; set; }

        [StringLength(256)]
        public string LinkImg { get; set; }

        public int LinkClass { get; set; }

        public int Sort { get; set; }

        [StringLength(16)]
        public string ProvinceID { get; set; }

        [StringLength(16)]
        public string CityID { get; set; }

        public int LinkState { get; set; }

        public bool IsNoFollow { get; set; }

        [StringLength(32)]
        public string AddUserName { get; set; }

        public DateTime AddTime { get; set; }
    }
}
