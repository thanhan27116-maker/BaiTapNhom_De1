using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace De1_BaiTapNhom_Nhom3
{
    public class DanhSachDeTaiDAL
    {
        List<DeTai> dsdtai = new List<DeTai>();
        public List<DeTai> Dsdtai { get => dsdtai; set => dsdtai = value; }

        public List<DeTai> ReadXML(string fileName)
        {
            List<DeTai> dsdtai = new List<DeTai>();
            XmlDocument data = new XmlDocument();

            try
            {
                string solutionPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)                   
                    .Parent.Parent.Parent.FullName;
                string fullPath = Path.Combine(solutionPath, "Data", fileName);

                if (!File.Exists(fullPath))
                {
                    Console.WriteLine($"Lỗi: Không tìm thấy file {fullPath}");
                    return dsdtai;
                }
                data.Load(fullPath);

                XmlNodeList nodeList = data.SelectNodes("/DANHSACHDETAI/DETAI");

                foreach (XmlNode node in nodeList)
                {
                    DeTai dt = new DeTai();
                    dt.MaSo = node["MASO"].InnerText;
                    dt.TenDeTai = node["TENDETAI"].InnerText;
                    dt.NgayBatDau = node["NGAYBATDAU"].InnerText;
                    dt.NgayKetThuc = node["NGAYKETTHUC"].InnerText;
                    dt.ChuTri = node["TRUONGNHOM"].InnerText;
                    dt.GiangVienHD = node["GIANGVIENHD"].InnerText;

                    int loai = int.Parse(node.Attributes["Loai"].Value);

                    if (loai == 1)
                    {
                        var lvlt = new DeTaiLyThuyet();
                        bool Adtt = bool.Parse(node["APDUNGTHUCTE"].InnerText);
                        lvlt.ApDungThucTe = Adtt;
                        lvlt.TinhKinhPhi();
                        dt.Lv = lvlt;
                    }
                    else if (loai == 2)
                    {
                        var lv = new DeTaiKinhTe();
                        lv.SoCauHoi = int.Parse(node["SOCAUHOI"].InnerText);
                        lv.HoTro = double.Parse(node["PHIHOTRO"].InnerText);
                        lv.TinhKinhPhi();
                        dt.Lv = lv;
                    }
                    else if (loai == 3)
                    {
                        var lv = new DeTaiCongNghe();
                        lv.MoiTruong = node["MOITRUONG"].InnerText;
                        lv.HoTro = double.Parse(node["PHIHOTRO"].InnerText);
                        lv.TinhKinhPhi();
                        dt.Lv = lv;
                    }

                    dsdtai.Add(dt);
                }
            }
            catch (XmlException)
            {
                Console.WriteLine("⚠️ Lỗi: File XML không đúng định dạng!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Lỗi không xác định: {ex.Message}");
            }

            return dsdtai;
        }
    }
}
