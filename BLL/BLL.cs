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
using DAL;
using Entity;   
namespace BLL
{
   
    public class BLL : Control
    {
        static BLL()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BLL), new FrameworkPropertyMetadata(typeof(BLL)));
        }
    }
    public class BLL_CuaHang
    {
        DAL_CuaHang dal_CuaHang = new DAL_CuaHang();
        public List<CuaHang> getAllCuaHang()
        {
            var dt = dal_CuaHang.getAllSanPham();
            List<CuaHang> list = new List<CuaHang>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CuaHang ch = new CuaHang();
                ch.MaSP = Convert.ToInt32(dt.Rows[i]["MaSP"]);
                ch.TenSP = dt.Rows[i]["TenSP"].ToString();
                ch.Gia = Convert.ToInt32(dt.Rows[i]["Gia"]);
                ch.ChatLuong = dt.Rows[i]["ChatLuong"].ToString();
                ch.SoLuong = Convert.ToInt32(dt.Rows[i]["SoLuong"]);
                list.Add(ch);
            }
            return list;
        }
        public void themCuaHang(CuaHang ch)
        {
            DAL_CuaHang dal_CuaHang = new DAL.DAL_CuaHang();
            dal_CuaHang.ThemSanPham(ch);
        }
        public void xoaCuaHang(int maSP)
        {
            DAL_CuaHang dal_CuaHang = new DAL.DAL_CuaHang();
            dal_CuaHang.xoaSanPham(maSP);
        }
        public void capnhatCuaHang(CuaHang ch)
        {
            DAL_CuaHang dal_CuaHang = new DAL.DAL_CuaHang();
            dal_CuaHang.capnhatSanPham(ch);
        }
    }
   public class BLL_NhanVien
    {
        DAL_NhanVien dal_NhanVien = new DAL_NhanVien();
        public List<Nhân_viên> getAllNhanVien()
        {
            var dt = dal_NhanVien.getAllNhanVien();
            List<Nhân_viên> list = new List<Nhân_viên>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Nhân_viên nv = new Nhân_viên();
                nv.MaNV = dt.Rows[i]["MaNV"].ToString();
                nv.TenNV = dt.Rows[i]["TenNV"].ToString();
                nv.GioiTinh = dt.Rows[i]["GioiTinh"].ToString();
                nv.MatKhau = dt.Rows[i]["MatKhau"].ToString();
                nv.SoDienThoai = dt.Rows[i]["SoDienThoai"].ToString();
                list.Add(nv);
            }
            return list;
        }
        public void themNhanVien(Nhân_viên nv)
        {
            DAL_NhanVien dal_NhanVien = new DAL.DAL_NhanVien();
            dal_NhanVien.themNhanVien(nv);
        }
        public void xoaNhanVien(string maNV)
        {
            DAL_NhanVien dal_NhanVien = new DAL.DAL_NhanVien();
            dal_NhanVien.xoaNhanVien(Convert.ToInt32(maNV));
        }
        public void capnhatNhanVien(Nhân_viên nv)
        {
            DAL_NhanVien dal_NhanVien = new DAL.DAL_NhanVien();
            dal_NhanVien.capnhatNhanVien(nv);
        }
    }
    public class BLL_KhachHang
    {
        DAL_KhachHang dal_KhachHang = new DAL_KhachHang();
        public List<khachhang> getAllKhachHang()
        {
            var dt = dal_KhachHang.getAllKhachHang();
            List<khachhang> list = new List<khachhang>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                khachhang kh = new khachhang();
                kh.MaKH = dt.Rows[i]["MaKH"].ToString();
                kh.TemKH = dt.Rows[i]["TenKH"].ToString();
                kh.GioiTinht = dt.Rows[i]["GioiTinh"].ToString();
                kh.SoDienThoai = dt.Rows[i]["SoDienThoai"].ToString();
                list.Add(kh);
            }
            return list;
        }
        public void themKhachHang(khachhang kh)
        {
            DAL_KhachHang dal_KhachHang = new DAL.DAL_KhachHang();
            dal_KhachHang.themKhachHang(kh);
        }
        public void xoaKhachHang(string maKH)
        {
            DAL_KhachHang dal_KhachHang = new DAL.DAL_KhachHang();
            dal_KhachHang.xoaKhachHang(maKH);
        }
        public void capnhatKhachHang(khachhang kh)
        {
            DAL_KhachHang dal_KhachHang = new DAL.DAL_KhachHang();
            dal_KhachHang.capnhatKhachHang(kh);
        }
    }
    public class BLL_HoaDon
    {
        DAL_HoaDon dal_HoaDon = new DAL_HoaDon();
        public List<hoadon> getAllHoaDon()
        {
            var dt = dal_HoaDon.getAllHoaDon();
            List<hoadon> list = new List<hoadon>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                hoadon hd = new hoadon();
                hd.MaSP = Convert.ToInt32( dt.Rows[i]["MaSP"]);
                hd.TenNV = dt.Rows[i]["TenNV"].ToString();
                hd.TenSP = dt.Rows[i]["TenSP"].ToString();
                hd.Gia = Convert.ToInt32( dt.Rows[i]["Gia"]);
                hd.SoLuong = Convert.ToInt32( dt.Rows[i]["SoLuong"]);
                hd.ThanhTien = Convert.ToInt32( dt.Rows[i]["ThanhTien"]);
                hd.ChatLuong = dt.Rows[i]["ChatLuong"].ToString();
                hd.NgayBan = Convert.ToDateTime( dt.Rows[i]["NgayBan"]);
                list.Add(hd);
            }
            return list;
        }
        public void themHoaDon(hoadon hd)
        {
            DAL_HoaDon dal_HoaDon = new DAL.DAL_HoaDon();
            dal_HoaDon.themHoaDon(hd);
        }
        }
    }




