using System.Collections.Generic;
using System.Linq;
using Entity;

namespace DAL
{
    public class CuaHangDAL
    {
        MinimartDbContext db = new MinimartDbContext();

        public List<CuaHang> GetAllSanPham()
        {
            return db.CuaHangs.ToList();
        }

        public bool ThemSanPham(CuaHang sp)
        {
            if (db.CuaHangs.Any(x => x.MaSP == sp.MaSP))
                return false;

            db.CuaHangs.Add(sp);
            db.SaveChanges();
            return true;
        }

        public void XoaSanPham(int maSP)
        {
            var sp = db.CuaHangs.Find(maSP);
            if (sp != null)
            {
                db.CuaHangs.Remove(sp);
                db.SaveChanges();
            }
        }

        public void CapNhatSanPham(CuaHang sp)
        {
            var old = db.CuaHangs.Find(sp.MaSP);
            if (old != null)
            {
                old.TenSP = sp.TenSP;
                old.Gia = sp.Gia;
                old.ChatLuong = sp.ChatLuong;
                old.SoLuong = sp.SoLuong;
                db.SaveChanges();
            }
        }
    }
}
