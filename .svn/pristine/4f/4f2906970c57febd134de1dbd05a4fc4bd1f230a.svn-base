namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viewTicketBiddingPush")]
    public partial class viewTicketBiddingPush
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

        public DateTime? TicketEndTime { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime PublishTime { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TradeState { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(16)]
        public string ProvinceID { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(16)]
        public string CityID { get; set; }

        public int? TicketType { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(256)]
        public string TicketFaceImg { get; set; }

        [StringLength(256)]
        public string TicketBackImg { get; set; }

        public DateTime? TicketStartTime { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UploadChannel { get; set; }

        public decimal? MaxRate { get; set; }

        public decimal? MaxPrice { get; set; }

        public DateTime? LastBidTime { get; set; }

        public int? CT { get; set; }

        public int? TP { get; set; }
    }
}
