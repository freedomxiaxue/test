namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viewUserDetail")]
    public partial class viewUserDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(32)]
        public string Phone { get; set; }

        public DateTime? LastLoginTime { get; set; }

        [StringLength(16)]
        public string ProvinceID { get; set; }

        [StringLength(16)]
        public string CityID { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(128)]
        public string FullName { get; set; }

        public int? ALBearerLevel { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Identor { get; set; }
    }
}
