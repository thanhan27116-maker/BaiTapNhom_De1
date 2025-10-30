using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace De1_BaiTapNhom_Nhom3
{
    public class DeTaiKinhTe : LinhVuc, IDeTai
    {
        private int soCauHoi;
        private double hoTro;

        public int SoCauHoi { get => soCauHoi; set => soCauHoi = value; }
        public double HoTro { get => hoTro; set => hoTro = value; }

        public override void XuatTT()
        {
            base.XuatTT();
            Console.WriteLine($"|- Số câu hỏi: {SoCauHoi}");
            Console.WriteLine($"|- Kinh Phí của lĩnh vực kinh tế:\t{KinhPhi} tr (VNĐ)\t");
            Console.WriteLine($"|- Phi Hỗ Trợ cho lĩnh vực kinh tế:\t{PhiHoTro()} nghìn (VNĐ)\t");
        }

        public override void TinhKinhPhi()
        {
            if (SoCauHoi > 100)
                KinhPhi = 12;
            else
                KinhPhi = 7;
            KinhPhi = KinhPhi * HeSoTang;
        }

        public double PhiHoTro()
        {
            if (soCauHoi > 100)
                return HoTro = 5.5 * SoCauHoi;
            else
                return HoTro = 4.5 * SoCauHoi;
        }
    }
}