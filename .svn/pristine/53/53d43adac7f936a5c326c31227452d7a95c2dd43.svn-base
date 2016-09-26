namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AgentUser")]
    public partial class AgentUser
    {
        public int ID { get; set; }

        [Required]
        [StringLength(32)]
        public string UserName { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(256)]
        public string Address { get; set; }

        [StringLength(16)]
        public string Zip { get; set; }

        [StringLength(16)]
        public string ProvinceID { get; set; }

        [StringLength(16)]
        public string CityID { get; set; }

        [StringLength(16)]
        public string AreaID { get; set; }

        [StringLength(32)]
        public string Telephone { get; set; }

        [StringLength(32)]
        public string Fax { get; set; }

        [StringLength(32)]
        public string Phone { get; set; }

        [StringLength(128)]
        public string Email { get; set; }

        [StringLength(256)]
        public string Picture1 { get; set; }

        [StringLength(256)]
        public string Picture2 { get; set; }

        [StringLength(256)]
        public string Picture3 { get; set; }

        [StringLength(256)]
        public string Picture4 { get; set; }

        [StringLength(256)]
        public string Picture5 { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? LastLoginTime { get; set; }

        [StringLength(32)]
        public string LastLoginIP { get; set; }
    }
}
