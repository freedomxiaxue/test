namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BAT_CiticForceTransfer
    {
        [Key]
        public int Ft_id { get; set; }

        [Required]
        [StringLength(20)]
        public string Ft_clientid { get; set; }

        [Required]
        [StringLength(19)]
        public string Ft_accountno { get; set; }

        [Required]
        [StringLength(19)]
        public string Ft_payaccno { get; set; }

        [Required]
        [StringLength(2)]
        public string Ft_trantype { get; set; }

        [StringLength(19)]
        public string Ft_recvaccno { get; set; }

        [StringLength(122)]
        public string Ft_recvaccnm { get; set; }

        public decimal Ft_tranamt { get; set; }

        [StringLength(22)]
        public string Ft_freezeno { get; set; }

        [StringLength(102)]
        public string Ft_memo { get; set; }

        [Required]
        [StringLength(1)]
        public string Ft_tranflag { get; set; }

        public DateTime? Ft_recordtime { get; set; }
    }
}
