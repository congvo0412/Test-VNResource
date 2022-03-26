using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestVNR.Models
{
    public partial class MonHoc
    {
        public int Id { get; set; }
        public string TenMonHoc { get; set; }
        public string MoTa { get; set; }
        public int KhoaHocId { get; set; }

        public virtual KhoaHoc KhoaHoc { get; set; }
    }
}
