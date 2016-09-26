namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TicketImage")]
    public partial class TicketImage
    {
        public int ID { get; set; }

        public int? TicketID { get; set; }

        [StringLength(255)]
        public string OriginImg { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [StringLength(255)]
        public string ThumbImg { get; set; }
    }
}
