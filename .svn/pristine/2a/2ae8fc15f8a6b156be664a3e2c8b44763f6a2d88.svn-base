namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viewReturnRsgUserinfo")]
    public partial class viewReturnRsgUserinfo
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int uid { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(32)]
        public string Phone { get; set; }

        [StringLength(128)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime RegisterTime { get; set; }

        public DateTime? LastLoginTime { get; set; }

        [StringLength(128)]
        public string SName { get; set; }

        [StringLength(128)]
        public string FName { get; set; }

        [StringLength(256)]
        public string Avatar { get; set; }

        [StringLength(16)]
        public string CityID { get; set; }

        [StringLength(256)]
        public string Address { get; set; }

        [StringLength(16)]
        public string Zip { get; set; }

        [StringLength(16)]
        public string ProvinceID { get; set; }

        [StringLength(32)]
        public string NameOfPIC { get; set; }
    }
}
