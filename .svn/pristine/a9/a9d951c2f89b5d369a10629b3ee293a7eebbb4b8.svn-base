namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viewDiscountBidding")]
    public partial class viewDiscountBidding
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TicketID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BidUserID { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal BidPrice { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal BidRate { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime BidTime { get; set; }

        public DateTime? LastEditTime { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BidResult { get; set; }

        [StringLength(256)]
        public string BidResultNote { get; set; }

        public int? LoginMode { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(32)]
        public string Phone { get; set; }

        [StringLength(16)]
        public string ProvinceID { get; set; }

        [StringLength(16)]
        public string CityID { get; set; }

        [StringLength(128)]
        public string Name { get; set; }
    }
}
