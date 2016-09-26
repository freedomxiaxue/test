namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BAT_VirtualAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int YHBH { get; set; }

        [StringLength(500)]
        public string QYMC { get; set; }

        [StringLength(20)]
        public string LXR { get; set; }

        [StringLength(50)]
        public string LXRDH { get; set; }

        [StringLength(30)]
        public string XNZH { get; set; }

        [StringLength(20)]
        public string SJR { get; set; }

        [StringLength(50)]
        public string SJRDH { get; set; }

        [StringLength(500)]
        public string YJDZ { get; set; }

        [StringLength(1)]
        public string JS { get; set; }

        public DateTime? SQSJ { get; set; }

        [StringLength(2)]
        public string SHJD { get; set; }

        public DateTime? SHSJ { get; set; }

        [StringLength(50)]
        public string SHR { get; set; }

        [StringLength(500)]
        public string BZ { get; set; }

        [StringLength(200)]
        public string KDGS { get; set; }

        [StringLength(100)]
        public string KDDH { get; set; }

        [StringLength(500)]
        public string BankUp1 { get; set; }

        [StringLength(500)]
        public string BankUp2 { get; set; }

        [StringLength(500)]
        public string BankUp3 { get; set; }

        [StringLength(500)]
        public string BankUp4 { get; set; }

        [StringLength(500)]
        public string BankUp5 { get; set; }
    }
}
