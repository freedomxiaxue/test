namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viewUserListOA")]
    public partial class viewUserListOA
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(32)]
        public string UserName { get; set; }

        [StringLength(128)]
        public string FullName { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(256)]
        public string Avatar { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegisterType { get; set; }

        [StringLength(16)]
        public string ProvinceID { get; set; }

        [StringLength(16)]
        public string CityID { get; set; }

        [StringLength(16)]
        public string DistrictID { get; set; }

        [StringLength(32)]
        public string Telephone { get; set; }

        [StringLength(256)]
        public string Address { get; set; }

        [StringLength(32)]
        public string NameOfPIC { get; set; }

        [StringLength(32)]
        public string PositionOfPIC { get; set; }

        [StringLength(32)]
        public string QQOfPIC { get; set; }

        [StringLength(16)]
        public string Zip { get; set; }

        [StringLength(32)]
        public string Fax { get; set; }

        public int? ALTakerLevel { get; set; }

        public int? ALBearerLevel { get; set; }

        [StringLength(128)]
        public string ALAdvantage { get; set; }

        [StringLength(255)]
        public string ALNote { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(32)]
        public string Phone { get; set; }

        [StringLength(128)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime RegisterTime { get; set; }

        public DateTime? LastLoginTime { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Identor { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IsAgency { get; set; }
    }
}
