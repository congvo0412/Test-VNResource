using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestVNR.Models
{
    public partial class KhoaHoc
    {
        public KhoaHoc()
        {
            MonHoc = new HashSet<MonHoc>();
        }

        public int Id { get; set; }
        public string TenKhoaHoc { get; set; }

        public virtual ICollection<MonHoc> MonHoc { get; set; }
    }
}
