namespace tcpjw3.oa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MachineRecords
    {
        public int ID { get; set; }

        public int? Mtype { get; set; }

        public DateTime? Regtime { get; set; }

        [StringLength(50)]
        public string ModelName { get; set; }

        [StringLength(255)]
        public string Note { get; set; }
    }
}
