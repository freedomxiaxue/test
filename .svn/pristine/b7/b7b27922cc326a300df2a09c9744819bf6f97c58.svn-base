namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Message")]
    public partial class Message
    {
        public int ID { get; set; }

        public int? SNID { get; set; }

        public int UserID { get; set; }

        [Required]
        [StringLength(64)]
        public string MsgTitle { get; set; }

        [StringLength(255)]
        public string MsgContent { get; set; }

        public int MsgState { get; set; }

        public int MsgType { get; set; }

        public DateTime MsgTime { get; set; }
    }
}
