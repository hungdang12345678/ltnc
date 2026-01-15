using DAL;
using Entity;
using System.Collections.Generic;
using System.Linq; 

public class DAL_HoaDon
{
    MinimartDbContext db = new MinimartDbContext();

    public List<hoadon> GetAllHoaDon()
    {
        return db.HoaDons.ToList();
    }

    public void ThemHoaDon(hoadon hd)
    {
        db.HoaDons.Add(hd);
        db.SaveChanges();
    }

    public void XoaHoaDon(int maSP)
    {
        var list = db.HoaDons.Where(x => x.MaSP == maSP).ToList();
        db.HoaDons.RemoveRange(list);
        db.SaveChanges();
    }
}
