namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("viewTicketDiscountPush")]
    public partial class viewTicketDiscountPush
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TicketID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string BankName { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal TicketPrice { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime TicketEndTime { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(32)]
        public string ProvinceID { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(32)]
        public string CityID { get; set; }

        public int? TicketType { get; set; }

        public int? BankType { get; set; }

        public int? TicketCategory { get; set; }

        public int? TermType { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int State { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ToUserID { get; set; }

        [Key]
        [Column(Order = 10)]
        public DateTime PushTime { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TradeState { get; set; }
    }
}
