using System.Collections.Generic;
using System.Linq;
using Entity;

namespace DAL
{
    public class DAL_NhanVien
    {
        MinimartDbContext db = new MinimartDbContext();

        public List<NhanVien> GetAll()
        {
            return db.NhanViens.ToList();
        }

        public void Add(NhanVien nv)
        {
            db.NhanViens.Add(nv);
            db.SaveChanges(); 
        }

        public void Delete(int maNV)
        {
            var nv = db.NhanViens.Find(maNV);
            if (nv != null)
            {
                db.NhanViens.Remove(nv);
                db.SaveChanges();
            }
        }

        public void Update(NhanVien nv)
        {
            var old = db.NhanViens.Find(nv.MaNV);
            if (old != null)
            {
                old.TenNV = nv.TenNV;
                old.GioiTinh = nv.GioiTinh;
                old.SoDienThoai = nv.SoDienThoai;
                old.MatKhau = nv.MatKhau;
                db.SaveChanges();
            }
        }
    }
}
