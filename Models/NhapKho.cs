using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class NhapKho
    {
        public int      MaNK { get; set; }
        public DateOnly NgayNhap { get; set; }
        public string   NhaCungCap { get; set; }
        public int      MaUser { get; set; }
        public User User { get; set; }
        public NhapKho() { }
    }
}
