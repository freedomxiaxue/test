namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TicketDiscount")]
    public partial class TicketDiscount
    {
        [Key]
        public int TicketID { get; set; }

        public int? TicketType { get; set; }

        public int? BankType { get; set; }

        [Required]
        [StringLength(64)]
        public string BankName { get; set; }

        public int? TicketCategory { get; set; }

        public int? TermType { get; set; }

        public decimal TicketPrice { get; set; }

        public DateTime? TicketStartTime { get; set; }

        public DateTime? TicketEndTime { get; set; }

        [Required]
        [StringLength(256)]
        public string TicketFaceImg { get; set; }

        [StringLength(256)]
        public string TicketBackImg { get; set; }

        [Required]
        [StringLength(16)]
        public string ProvinceID { get; set; }

        [Required]
        [StringLength(16)]
        public string CityID { get; set; }

        public int TradeState { get; set; }

        public DateTime PublishTime { get; set; }

        public DateTime? LastEditTime { get; set; }

        public int UserID { get; set; }

        [Required]
        [StringLength(128)]
        public string UserName { get; set; }

        public int PublishTunes { get; set; }

        public int? AuditorID { get; set; }

        [StringLength(128)]
        public string AuditorName { get; set; }

        public int? AuditState { get; set; }

        [StringLength(256)]
        public string AuditNote { get; set; }

        public DateTime? AuditTime { get; set; }

        public int Hits { get; set; }

        public int? LoginMode { get; set; }

        [StringLength(256)]
        public string UserNote { get; set; }

        public decimal? BidPrice { get; set; }

        public int UploadChannel { get; set; }

        public DateTime? JjzTime { get; set; }

        public DateTime? QryyTime { get; set; }

        public DateTime? ZfdjTime { get; set; }

        public DateTime? CprbsTime { get; set; }

        public DateTime? QsjdTime { get; set; }

        public DateTime? WcjyTime { get; set; }

        public DateTime? ZzjyTime { get; set; }

        public DateTime? YykbTime { get; set; }

        public int? BidId { get; set; }

        [StringLength(50)]
        public string ToAccount { get; set; }
    }
}
