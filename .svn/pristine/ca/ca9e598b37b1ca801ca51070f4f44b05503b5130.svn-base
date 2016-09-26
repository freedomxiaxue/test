namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viewEleTicketDiscount")]
    public partial class viewEleTicketDiscount
    {
        [Key]
        [Column(Order = 0)]
        public int TicketID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        public int? BankType { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(64)]
        public string BankName { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal TicketPrice { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime PublishTime { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(16)]
        public string ProvinceID { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(16)]
        public string CityID { get; set; }

        public decimal? BidPrice { get; set; }

        public DateTime? AuditTime { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TradeState { get; set; }

        public int? AuditState { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UploadChannel { get; set; }

        public int? TicketCategory { get; set; }

        public int? TermType { get; set; }

        public DateTime? TicketStartTime { get; set; }

        public DateTime? YykbTime { get; set; }

        public DateTime? JjzTime { get; set; }

        public DateTime? CprbsTime { get; set; }

        public DateTime? WcjyTime { get; set; }

        public DateTime? ZzjyTime { get; set; }

        public DateTime? QryyTime { get; set; }

        public DateTime? ZfdjTime { get; set; }

        public DateTime? QsjdTime { get; set; }

        public DateTime? TicketEndTime { get; set; }

        public DateTime? LastEditTime { get; set; }
    }
}
