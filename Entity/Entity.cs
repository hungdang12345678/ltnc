using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Entity
{
    
    public class Entity : Control
    {
        static Entity()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Entity), new FrameworkPropertyMetadata(typeof(Entity)));
        }
    }
    public class CuaHang
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int Gia { get; set; }
        public string ChatLuong { get; set; }
        public int SoLuong { get; set; }
    }
    public class Nhân_viên
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public string GioiTinh { get; set; }
        public string MatKhau { get; set; }
        public string SoDienThoai { get; set; }
    }
    public class khachhang
    {
        public string MaKH { get; set; }
        public string TemKH { get; set; }
        public string GioiTinht { get; set; }
        public string SoDienThoai { get; set; }

    }
    public class hoadon
    {
        public int MaSP { get; set; }
        public string TenNV { get; set; }
        public string TenSP { get; set; }
        public int Gia { get; set; }
        public int SoLuong { get; set; }
        public int ThanhTien { get; set; }
        public string ChatLuong { get; set; }
        public DateTime NgayBan { get; set; }

        public int TongTien { get; set; }
    }   
}
