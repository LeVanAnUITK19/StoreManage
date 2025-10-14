using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Models
{
    public class CaLam
    {
        public int MaCa {  get; set; }
        public string TenCa { get; set; }
        public TimeOnly GioVaoCa { get; set; }
        public TimeOnly GioRaCa { get; set; }
        public DateOnly NgayLam { get; set; }

        public bool TrangThaiCa { get; set; }

        public CaLam() { }
    }
}
