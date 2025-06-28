namespace DatabaseProvider
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chude")]
    public partial class chude
    {
        [Key]
        [StringLength(100)]
        public string MaCD { get; set; }

        [StringLength(100)]
        public string TenCD { get; set; }

        public string Picture { get; set; }

        public int? Color { get; set; }
        [StringLength(100)]
        public string TL { get; set; }
        [StringLength(100)]
        public string CaSi { get; set; }
        [StringLength(100)]
        public string MaCS { get; set; }
    }
}
