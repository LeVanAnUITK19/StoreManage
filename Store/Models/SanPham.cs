using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class SanPham
    {
        public int      MaSP { get; set; }
        public string   TenSP { get; set; }
        public decimal  GiaSP { get; set; }
        public int      SoLuongSP { get; set; }
        public string   HinhAnhSP { get; set; }
        public string   KichThuocSP { get; set; }
        public string   MoTaSP { get; set; }

        public SanPham() { }
    }
}