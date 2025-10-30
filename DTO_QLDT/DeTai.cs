using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace De1_BaiTapNhom_Nhom3
{
    public class DeTai
    {
        private string maSo;
        private string tenDeTai;
        private string ngayBatDau;
        private string ngayKetThuc;
        private string chuTri;
        private string giangVienHD;
        private LinhVuc lv;

        public DeTai()
        {
        }
        public DeTai(string maSo, string tenDeTai, string ngayBatDau, string ngayKetThuc, string chuTri, string giangVienHD, LinhVuc lv)
        {
            MaSo = maSo;
            TenDeTai = tenDeTai;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            ChuTri = chuTri;
            GiangVienHD = giangVienHD;
            this.Lv = lv;
        }

        public string MaSo { get => maSo; set => maSo = value; }
        public string TenDeTai { get => tenDeTai; set => tenDeTai = value; }
        public string NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public string NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public string ChuTri { get => chuTri; set => chuTri = value; }
        public string GiangVienHD { get => giangVienHD; set => giangVienHD = value; }
        public LinhVuc Lv { get => lv; set => lv = value; }

        public void XuatTT()
        {
            Console.WriteLine($"|Mã số đề tài:\t{MaSo}");
            Console.WriteLine($"|Tên đề tài:\t{TenDeTai}");
            Console.WriteLine($"|Ngày bắt đầu - kết thúc: {NgayBatDau} - {NgayKetThuc}");
            Console.WriteLine($"|Chủ trì của nhóm:\t{ChuTri}\t");
            Console.WriteLine($"|Giảng viên hướng dẫn của nhóm:\t{GiangVienHD}");
        }

    }
}