namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viewUserDiscountQuote")]
    public partial class viewUserDiscountQuote
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TicketID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal TicketPrice { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TradeState { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BidUserID { get; set; }

        [StringLength(128)]
        public string BidUserName { get; set; }

        [Key]
        [Column(Order = 5)]
        public decimal BidPrice { get; set; }

        [StringLength(32)]
        public string BidContactor { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(32)]
        public string BidUserPhone { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime BidTime { get; set; }

        [Key]
        [Column(Order = 8)]
        public decimal BidRate { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BidResult { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BidRelateResult { get; set; }

        [StringLength(256)]
        public string note { get; set; }
    }
}
