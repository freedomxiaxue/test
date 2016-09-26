namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BAT_GoldAccount
    {
        public int ID { get; set; }

        public int Userid { get; set; }

        [Required]
        [StringLength(50)]
        public string CjrecvAccNo { get; set; }

        [Required]
        [StringLength(200)]
        public string RecvAccNm { get; set; }

        public bool CjsameBank { get; set; }

        [StringLength(20)]
        public string CjrecvTgfi { get; set; }

        [StringLength(122)]
        public string CjrecvBankNm { get; set; }
    }
}
