namespace DatabaseProvider
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("playlist")]
    public partial class playlist
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string MaTK { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string MaBH { get; set; }

        [StringLength(10)]
        public string TenPL { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string MaPL { get; set; }
    }
}
