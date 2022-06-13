using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KiemTra_TranDanTruong.Models
{
    public class Sinhvien
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicYeaar { get; set; }
        public double Price { get; set; }
        public string Cover { get; set; }


    }
}