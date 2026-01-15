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
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Entity;

namespace DAL
{

    public class DAL : Control
    {
        static DAL()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DAL), new FrameworkPropertyMetadata(typeof(DAL)));
        }
    }
    class DBConnect
    {
        private SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-8MNKNMM\SQLEXPRESS;Initial Catalog=minimartdb;Integrated Security=True;");

        public SqlConnection getConnection()
        {
            return connection;
        }

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
    public class DAL_CuaHang
    {
        DBConnect dbConnect = new DBConnect();
        public DataTable getAllSanPham()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM CuaHang", dbConnect.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool ThemSanPham(CuaHang sp)
        {
            SqlConnection conn = dbConnect.getConnection();

            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM CuaHang WHERE MaSP = @MaSP", conn);
            checkCmd.Parameters.AddWithValue("@MaSP", sp.MaSP);

            conn.Open();
            int count = (int)checkCmd.ExecuteScalar();
            conn.Close();

            if (count > 0)
            {

                return false;
            }


            SqlCommand insertCmd = new SqlCommand("INSERT INTO CuaHang (MaSP, TenSP, Gia, ChatLuong, SoLuong) VALUES (@MaSP, @TenSP, @Gia, @ChatLuong, @SoLuong)", conn);
            insertCmd.Parameters.AddWithValue("@MaSP", sp.MaSP);
            insertCmd.Parameters.AddWithValue("@TenSP", sp.TenSP);
            insertCmd.Parameters.AddWithValue("@Gia", sp.Gia);
            insertCmd.Parameters.AddWithValue("@ChatLuong", sp.ChatLuong);
            insertCmd.Parameters.AddWithValue("@SoLuong", sp.SoLuong);

            conn.Open();
            insertCmd.ExecuteNonQuery();
            conn.Close();

            return true;
        }
        public void xoaSanPham(int maSP)
        {
            SqlCommand command = new SqlCommand("DELETE FROM CuaHang WHERE MaSP = @MaSP", dbConnect.getConnection());
            command.Parameters.AddWithValue("@MaSP", maSP);
            dbConnect.openConnection();
            command.ExecuteNonQuery();
            dbConnect.closeConnection();
        }
        public void capnhatSanPham(CuaHang sp)
        {
            SqlCommand command = new SqlCommand("UPDATE CuaHang SET TenSP = @TenSP, Gia = @Gia, ChatLuong = @ChatLuong, SoLuong = @SoLuong WHERE MaSP = @MaSP", dbConnect.getConnection());
            command.Parameters.AddWithValue("@MaSP", sp.MaSP);
            command.Parameters.AddWithValue("@TenSP", sp.TenSP);
            command.Parameters.AddWithValue("@Gia", sp.Gia);
            command.Parameters.AddWithValue("@ChatLuong", sp.ChatLuong);
            command.Parameters.AddWithValue("@SoLuong", sp.SoLuong);
            dbConnect.openConnection();
            command.ExecuteNonQuery();
            dbConnect.closeConnection();
        }
    }
    public class DAL_NhanVien
    {
        DBConnect dbConnect = new DBConnect();
        public DataTable getAllNhanVien()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM NhanVien", dbConnect.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public void themNhanVien(Nhân_viên nv)
        {
            SqlCommand command = new SqlCommand("INSERT INTO NhanVien (MaNV, TenNV, GioiTinh, Sodienthoai, MatKhau) VALUES (@MaNV, @TenNV, @GioiTinh, @Sodienthoai, @MatKhau)", dbConnect.getConnection());
            command.Parameters.AddWithValue("@MaNV", nv.MaNV);
            command.Parameters.AddWithValue("@TenNV", nv.TenNV);
            command.Parameters.AddWithValue("@Gioitinh", nv.GioiTinh);
            command.Parameters.AddWithValue("@Sodienthoai", nv.SoDienThoai);
            command.Parameters.AddWithValue("@MatKhau", nv.MatKhau);
            dbConnect.openConnection();
             command.ExecuteNonQuery();
            dbConnect.closeConnection();
        }
        public void xoaNhanVien(int maNV)
        {
            SqlCommand command = new SqlCommand("DELETE FROM NhanVien WHERE MaNV = @MaNV", dbConnect.getConnection());
            command.Parameters.AddWithValue("@MaNV", maNV);
            dbConnect.openConnection();
            command.ExecuteNonQuery();
            dbConnect.closeConnection();
        }
        public void capnhatNhanVien(Nhân_viên nv)
        {
            SqlCommand command = new SqlCommand("UPDATE NhanVien SET TenNV = @TenNV, GioiTinh = @GioiTinh, Sodienthoai = @Sodienthoai, MatKhau = @MatKhau WHERE MaNV = @MaNV", dbConnect.getConnection());
            command.Parameters.AddWithValue("@MaNV", nv.MaNV);
            command.Parameters.AddWithValue("@TenNV", nv.TenNV);
            command.Parameters.AddWithValue("@Gioitinh", nv.GioiTinh);
            command.Parameters.AddWithValue("@Sodienthoai", nv.SoDienThoai);
            command.Parameters.AddWithValue("@MatKhau", nv.MatKhau);
            dbConnect.openConnection();
            command.ExecuteNonQuery();
            dbConnect.closeConnection();
        }
    }
    public class DAL_KhachHang
    {
        DBConnect dbConnect = new DBConnect();
        public DataTable getAllKhachHang()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM KhachHang", dbConnect.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public void themKhachHang(khachhang kh)
        {
            SqlCommand command = new SqlCommand("INSERT INTO KhachHang (MaKH, TenKH, GioiTinh, Sodienthoai) VALUES (@MaKH, @TenKH, @GioiTinh, @Sodienthoai)", dbConnect.getConnection());
            command.Parameters.AddWithValue("@MaKH", kh.MaKH);
            command.Parameters.AddWithValue("@TenKH", kh.TemKH);
            command.Parameters.AddWithValue("@Gioitinh", kh.GioiTinht);
            command.Parameters.AddWithValue("@Sodienthoai", kh.SoDienThoai);
            dbConnect.openConnection();
            command.ExecuteNonQuery();
            dbConnect.closeConnection();
        }

        public void xoaKhachHang(string maKH)
        {
            SqlCommand command = new SqlCommand("DELETE FROM KhachHang WHERE MaKH = @MaKH", dbConnect.getConnection());
            command.Parameters.AddWithValue("@MaKH", maKH);
            dbConnect.openConnection();
            command.ExecuteNonQuery();
            dbConnect.closeConnection();
        }
        public void capnhatKhachHang(khachhang kh)
        {
            SqlCommand command = new SqlCommand("UPDATE KhachHang SET TenKH = @TenKH, GioiTinh = @GioiTinh, Sodienthoai = @Sodienthoai WHERE MaKH = @MaKH", dbConnect.getConnection());
            command.Parameters.AddWithValue("@MaKH", kh.MaKH);
            command.Parameters.AddWithValue("@TenKH", kh.TemKH);
            command.Parameters.AddWithValue("@Gioitinh", kh.GioiTinht);
            command.Parameters.AddWithValue("@Sodienthoai", kh.SoDienThoai);
            dbConnect.openConnection();
            command.ExecuteNonQuery();
            dbConnect.closeConnection();
        }

    }
    public class DAL_HoaDon
    {
        DBConnect dbConnect = new DBConnect();
        public DataTable getAllHoaDon()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM HoaDon", dbConnect.getConnection());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public void themHoaDon(hoadon hd)
        {
            SqlCommand command = new SqlCommand("INSERT INTO HoaDon (MaSP, TenNV, TenSP, Gia, SoLuong, ThanhTien, ChatLuong, NgayBan) VALUES (@MaSP, @TenNV, @TenSP, @Gia, @SoLuong, @ThanhTien, @ChatLuong, @NgayBan)", dbConnect.getConnection());
            command.Parameters.AddWithValue("@MaSP", hd.MaSP);
            command.Parameters.AddWithValue("@TenNV", hd.TenNV);
            command.Parameters.AddWithValue("@TenSP", hd.TenSP);
            command.Parameters.AddWithValue("@Gia", hd.Gia);
            command.Parameters.AddWithValue("@SoLuong", hd.SoLuong);
            command.Parameters.AddWithValue("@ThanhTien", hd.ThanhTien);
            command.Parameters.AddWithValue("@ChatLuong", hd.ChatLuong);
            command.Parameters.AddWithValue("@NgayBan", hd.NgayBan);
            dbConnect.openConnection();
            command.ExecuteNonQuery();
            dbConnect.closeConnection();
        }
    }   
    public class DAL_Login
    {
        DBConnect dbConnect = new DBConnect();
        public bool Login(string username, string password)
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM NhanVien WHERE MaNV = @username AND MatKhau = @password", dbConnect.getConnection());
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            dbConnect.openConnection();
            int count = (int)command.ExecuteScalar();
            dbConnect.closeConnection();
            return count > 0;
        }
    }
    public class DAL_Report
    {
        DBConnect dbConnect = new DBConnect();
        public DataTable getHoaDonByDateRange(DateTime startDate, DateTime endDate)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM HoaDon WHERE NgayBan BETWEEN @startDate AND @endDate", dbConnect.getConnection());
            command.Parameters.AddWithValue("@startDate", startDate);
            command.Parameters.AddWithValue("@endDate", endDate);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
    public class DAL_Statistics
    {
        DBConnect dbConnect = new DBConnect();
        public DataTable getTopSellingProducts(int topN)
        {
            SqlCommand command = new SqlCommand("SELECT TOP(@topN) MaSP, SUM(SoLuong) AS TotalSold FROM HoaDon GROUP BY MaSP ORDER BY TotalSold DESC", dbConnect.getConnection());
            command.Parameters.AddWithValue("@topN", topN);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
    public class DAL_Inventory
    {
        DBConnect dbConnect = new DBConnect();
        public DataTable getLowStockProducts(int threshold)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM CuaHang WHERE SoLuong < @threshold", dbConnect.getConnection());
            command.Parameters.AddWithValue("@threshold", threshold);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
    public class DAL_BackupRestore
    {
        DBConnect dbConnect = new DBConnect();
        public void backupDatabase(string backupPath)
        {
            SqlCommand command = new SqlCommand($"BACKUP DATABASE minimartdb TO DISK = '{backupPath}'", dbConnect.getConnection());
            dbConnect.openConnection();
            command.ExecuteNonQuery();
            dbConnect.closeConnection();
        }
        public void restoreDatabase(string backupPath)
        {
            SqlCommand command = new SqlCommand($"RESTORE DATABASE minimartdb FROM DISK = '{backupPath}'", dbConnect.getConnection());
            dbConnect.openConnection();
            command.ExecuteNonQuery();
            dbConnect.closeConnection();
        }
    }
    public class DAL_UserManagement
    {
        DBConnect dbConnect = new DBConnect();
        public void changePassword(string maNV, string newPassword)
        {
            SqlCommand command = new SqlCommand("UPDATE NhanVien SET MatKhau = @newPassword WHERE MaNV = @maNV", dbConnect.getConnection());
            command.Parameters.AddWithValue("@maNV", maNV);
            command.Parameters.AddWithValue("@newPassword", newPassword);
            dbConnect.openConnection();
            command.ExecuteNonQuery();
            dbConnect.closeConnection();
        }
    }
    public class DAL_XoaHoaDon
    { 
        DBConnect dbConnect = new DBConnect();
        public void xoaHoaDon(int maSP)
        {
            SqlCommand command = new SqlCommand("DELETE FROM HoaDon WHERE MaSP = @MaSP", dbConnect.getConnection());
            command.Parameters.AddWithValue("@MaSP", maSP);
            dbConnect.openConnection();
            command.ExecuteNonQuery();
            dbConnect.closeConnection();
        }
    }
    
    
    
}
