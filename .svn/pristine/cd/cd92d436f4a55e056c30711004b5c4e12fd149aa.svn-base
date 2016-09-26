namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BAT_CiticPlatformOfGold
    {
        [Key]
        [Column(Order = 0)]
        public int Pf_id { get; set; }

        [Required]
        [StringLength(20)]
        public string Pf_clientid { get; set; }

        [Required]
        [StringLength(19)]
        public string Pf_accountno { get; set; }

        [Required]
        [StringLength(32)]
        public string Pf_recvaccno { get; set; }

        [Required]
        [StringLength(122)]
        public string Pf_recvaccnm { get; set; }

        public decimal Pf_tranamt { get; set; }

        [Required]
        [StringLength(1)]
        public string Pf_samebank { get; set; }

        [StringLength(20)]
        public string Pf_recvtgfi { get; set; }

        [StringLength(122)]
        public string Pf_recvbanknm { get; set; }

        [StringLength(102)]
        public string Pf_memo { get; set; }

        [Required]
        [StringLength(1)]
        public string Pf_preflg { get; set; }

        [StringLength(8)]
        public string Pf_predate { get; set; }

        [StringLength(6)]
        public string Pf_pretime { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Pf_ticketid { get; set; }

        [StringLength(100)]
        public string Pf_fkaccount { get; set; }

        [StringLength(100)]
        public string pf_skaccount { get; set; }

        public DateTime? Pf_recordtime { get; set; }
    }
}
