namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viewTicketDiscountAuditOA")]
    public partial class viewTicketDiscountAuditOA
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TicketID { get; set; }

        public int? TicketType { get; set; }

        public int? BankType { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(64)]
        public string BankName { get; set; }

        public int? TicketCategory { get; set; }

        public int? TermType { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal TicketPrice { get; set; }

        public DateTime? TicketStartTime { get; set; }

        public DateTime? TicketEndTime { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(256)]
        public string TicketFaceImg { get; set; }

        [StringLength(256)]
        public string TicketBackImg { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(16)]
        public string ProvinceID { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(16)]
        public string CityID { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TradeState { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime PublishTime { get; set; }

        public DateTime? LastEditTime { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Key]
        [Column(Order = 9)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PublishTunes { get; set; }

        public int? AuditorID { get; set; }

        [StringLength(128)]
        public string AuditorName { get; set; }

        public int? AuditState { get; set; }

        [StringLength(256)]
        public string AuditNote { get; set; }

        public DateTime? AuditTime { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Hits { get; set; }

        public int? LoginMode { get; set; }

        [StringLength(256)]
        public string UserNote { get; set; }

        public decimal? BidPrice { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UploadChannel { get; set; }

        public DateTime? JjzTime { get; set; }

        public DateTime? QryyTime { get; set; }

        public DateTime? ZfdjTime { get; set; }

        public DateTime? CprbsTime { get; set; }

        public DateTime? QsjdTime { get; set; }

        public DateTime? WcjyTime { get; set; }

        public DateTime? ZzjyTime { get; set; }

        public DateTime? YykbTime { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(32)]
        public string Phone { get; set; }
    }
}
