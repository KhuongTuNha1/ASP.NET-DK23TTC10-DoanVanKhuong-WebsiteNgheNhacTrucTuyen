namespace DatabaseProvider
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("theloai")]
    public partial class theloai
    {
        [Key]
        [StringLength(100)]
        public string MaTl { get; set; }

        [StringLength(100)]
        public string TenTl { get; set; }
        public string Hinh { get; set; }
    }
}
