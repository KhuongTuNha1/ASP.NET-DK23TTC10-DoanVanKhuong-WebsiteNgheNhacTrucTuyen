namespace DatabaseProvider
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nhac")]
    public partial class nhac
    {
        [Key]
        [StringLength(100)]
        public string MaBH { get; set; }

        public string TenBH { get; set; }

        public string FileLuu { get; set; }

        public string Image { get; set; }

        public DateTime? NgayPH { get; set; }

        [StringLength(100)]
        public string MaCS { get; set; }

        [StringLength(100)]
        public string MaTL { get; set; }

        [StringLength(100)]
        public string MaCD { get; set; }
        public string CaSi { get; set; }
        public string CD { get; set; }
        public string TL { get; set; }
        public int LuotNghe { get; set; }
    }
}
