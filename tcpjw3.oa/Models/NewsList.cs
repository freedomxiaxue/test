namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NewsList")]
    public partial class NewsList
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nclassid { get; set; }

        [Required]
        [StringLength(50)]
        public string Classname { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Imgtitleurl { get; set; }

        [StringLength(255)]
        public string Seo_title { get; set; }

        [StringLength(255)]
        public string Seo_keywords { get; set; }

        [StringLength(255)]
        public string Seo_desciption { get; set; }

        [StringLength(255)]
        public string Fromnew { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        [StringLength(50)]
        public string Editor { get; set; }

        public DateTime? Edittime { get; set; }

        [StringLength(50)]
        public string Publisher { get; set; }

        public DateTime? Publishtime { get; set; }

        public int? AuditState { get; set; }

        [StringLength(50)]
        public string Auditor { get; set; }

        public DateTime? AuditTime { get; set; }

        public int? Isslide { get; set; }

        [StringLength(255)]
        public string Slideurl { get; set; }

        public int? Isrecommend { get; set; }

        public int? Istop { get; set; }

        public int? Iscolor { get; set; }

        [StringLength(100)]
        public string Spare1 { get; set; }

        [StringLength(100)]
        public string Spare2 { get; set; }

        [StringLength(100)]
        public string Spare3 { get; set; }

        [StringLength(100)]
        public string Spare4 { get; set; }

        [StringLength(100)]
        public string Spare5 { get; set; }

        [StringLength(255)]
        public string NDescription { get; set; }
    }
}
