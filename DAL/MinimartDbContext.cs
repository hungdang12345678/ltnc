using Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace DAL
{
    public class MinimartDbContext : DbContext
    {
        public MinimartDbContext()
            : base("name=minimartdb") { }

        public DbSet<CuaHang> CuaHangs { get; set; }
        public DbSet<Nhanvien> NhanViens { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<hoadon> HoaDons { get; set; }
    }
}
