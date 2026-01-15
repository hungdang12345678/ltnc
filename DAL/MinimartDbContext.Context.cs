using System.Data.Entity;
using Entity;

namespace DAL
{
    public class MinimartDbContext : DbContext
    {
        public MinimartDbContext()
            : base("name=MinimartDb")
        {
        }

        public DbSet<CuaHang> CuaHangs { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
    }
}
