namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TicketPush")]
    public partial class TicketPush
    {
        public int ID { get; set; }

        public int TicketID { get; set; }

        [Required]
        [StringLength(255)]
        public string BankName { get; set; }

        public decimal TicketPrice { get; set; }

        public DateTime TicketEndTime { get; set; }

        public int UserID { get; set; }

        [Required]
        [StringLength(32)]
        public string ProvinceID { get; set; }

        [Required]
        [StringLength(32)]
        public string CityID { get; set; }

        public int? TicketType { get; set; }

        public int? BankType { get; set; }

        public int? TicketCategory { get; set; }

        public int? TermType { get; set; }

        public int State { get; set; }

        public int ToUserID { get; set; }

        public DateTime PushTime { get; set; }
    }
}
