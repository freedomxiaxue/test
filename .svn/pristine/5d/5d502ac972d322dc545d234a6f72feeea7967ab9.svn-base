namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserMap")]
    public partial class UserMap
    {
        public int ID { get; set; }

        public int AgencyId { get; set; }

        public int UserId { get; set; }

        [StringLength(500)]
        public string Note { get; set; }
    }
}
