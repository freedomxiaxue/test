namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiscountBidding")]
    public partial class DiscountBidding
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TicketID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BidUserID { get; set; }

        public decimal BidPrice { get; set; }

        public decimal BidRate { get; set; }

        public DateTime BidTime { get; set; }

        public DateTime? LastEditTime { get; set; }

        public int BidResult { get; set; }

        [StringLength(256)]
        public string BidResultNote { get; set; }

        public int BidRelateResult { get; set; }

        public int? LoginMode { get; set; }

        public decimal? TotalPrice { get; set; }
    }
}
