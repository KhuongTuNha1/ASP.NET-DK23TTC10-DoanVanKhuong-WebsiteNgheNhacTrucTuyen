namespace DatabaseProvider
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("casi")]
    public partial class casi
    {
        [Key]
        [StringLength(100)]
        public string MaCs { get; set; }

        [StringLength(100)]
        public string TenCs { get; set; }
        public string Picture { get; set; }
        public string Infor { get; set; }
        [StringLength(50)]
        public string QuocGia { get; set; }
    }
}
