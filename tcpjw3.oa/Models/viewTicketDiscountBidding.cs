namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viewTicketDiscountBidding")]
    public partial class viewTicketDiscountBidding
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TicketID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(64)]
        public string BankName { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal TicketPrice { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime PublishTime { get; set; }

        public DateTime? TicketEndTime { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(16)]
        public string CityID { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(16)]
        public string ProvinceID { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TradeState { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BidResult { get; set; }

        [Key]
        [Column(Order = 8)]
        public decimal BidPrice { get; set; }

        public decimal? TotalPrice { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UploadChannel { get; set; }

        public int? AuditState { get; set; }

        public DateTime? AuditTime { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BidUserID { get; set; }

        [Key]
        [Column(Order = 12)]
        public DateTime BidTime { get; set; }

        public DateTime? JjzTime { get; set; }

        public DateTime? QryyTime { get; set; }

        public DateTime? ZfdjTime { get; set; }

        public DateTime? CprbsTime { get; set; }

        public DateTime? QsjdTime { get; set; }

        public DateTime? WcjyTime { get; set; }

        public DateTime? ZzjyTime { get; set; }

        public DateTime? YykbTime { get; set; }
    }
}
