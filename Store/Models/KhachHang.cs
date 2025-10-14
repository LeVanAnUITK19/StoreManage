using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class KhachHang
    {
        public int    MaKH { get; set; }
        public string TenKH { get; set; }
        public string SDTKH { get; set; }
        public string EmailKH { get; set; }
        public string DiaChiKH { get; set; }
        public string GioiTinhKH { get; set; }
        public string HangKH { get; set; }
        public string GhiChu { get; set; }

        public KhachHang() { }
    }
}
