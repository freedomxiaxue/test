namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BAT_CITICOrderTransaction
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Version { get; set; }

        [Required]
        [StringLength(8)]
        public string Bizcode { get; set; }

        [Required]
        [StringLength(8)]
        public string Mctno { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string Mctjnlno { get; set; }

        [StringLength(20)]
        public string Lamagno { get; set; }

        [Required]
        [StringLength(20)]
        public string Orderno { get; set; }

        [Required]
        [StringLength(2)]
        public string Bsnno { get; set; }

        [Required]
        [StringLength(19)]
        public string Payeraccno { get; set; }

        [Required]
        [StringLength(19)]
        public string Payeeaccno { get; set; }

        public decimal Orderamt { get; set; }

        public decimal Tranamt { get; set; }

        public decimal Loanamt { get; set; }

        [Required]
        [StringLength(5)]
        public string Crycode { get; set; }

        [StringLength(20)]
        public string Resume { get; set; }

        [StringLength(60)]
        public string Purpose { get; set; }

        [Required]
        [StringLength(14)]
        public string Ordertime { get; set; }

        public bool Isloan { get; set; }

        public bool Isautopayback { get; set; }

        [StringLength(20)]
        public string Stfreezeno { get; set; }

        [StringLength(20)]
        public string Ctrtno { get; set; }

        [StringLength(20)]
        public string Dlvorderno { get; set; }

        [StringLength(20)]
        public string Dlvodrtime { get; set; }

        [StringLength(20)]
        public string Dlvctrtno { get; set; }

        [StringLength(256)]
        public string Dlvername { get; set; }

        public decimal? Dlvfee { get; set; }

        [Required]
        [StringLength(20)]
        public string Stockno { get; set; }

        [Required]
        [StringLength(8)]
        public string Startdate { get; set; }

        [Required]
        [StringLength(8)]
        public string Enddate { get; set; }

        public decimal Totalamt { get; set; }

        [Required]
        [StringLength(20)]
        public string Warehousecode { get; set; }

        [Required]
        [StringLength(300)]
        public string Warehousenm { get; set; }

        [Required]
        [StringLength(64)]
        public string Productcode { get; set; }

        [Required]
        [StringLength(100)]
        public string Productnm { get; set; }

        [Required]
        [StringLength(20)]
        public string Unit { get; set; }

        public int Productnum { get; set; }

        public decimal Dealunitprt { get; set; }

        public bool Insflag { get; set; }

        [Required]
        [StringLength(300)]
        public string Whpos { get; set; }

        [StringLength(2)]
        public string R_stt { get; set; }

        [StringLength(7)]
        public string R_rstcode { get; set; }

        public DateTime? Recordtime { get; set; }

        public DateTime? Updatetime { get; set; }

        public int Tranperiod { get; set; }

        [StringLength(22)]
        public string Freezeno { get; set; }
    }
}
