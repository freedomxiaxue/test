namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viewMessageGroupped")]
    public partial class viewMessageGroupped
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? SNID { get; set; }

        public int? TicketType { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(64)]
        public string BankName { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal TicketPrice { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(64)]
        public string MsgTitle { get; set; }

        [StringLength(255)]
        public string MsgContent { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MsgState { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MsgType { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime MsgTime { get; set; }
    }
}
