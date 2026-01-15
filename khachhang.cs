using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;

namespace Minimarket
{
    public partial class khachhang : Form
    {
        BLL_KhachHang bll_KhachHang = new BLL.BLL_KhachHang();
        private void loadData()
        {
            List<Entity.khachhang> list = bll_KhachHang.getAllKhachHang();
            dgvKhachHang.DataSource = list;
        }
        private void khachhang_Load(object sender, EventArgs e)
        {
            loadData();
        }
        public khachhang()
        {
            InitializeComponent();
        }

        private void btnSieuThi_Click(object sender, EventArgs e)
        {
            cuahang cuahang = new cuahang();
            cuahang.Show();
            this.Hide();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            Nhân_viên nhan_Vien = new Nhân_viên();
            nhan_Vien.Show();
            this.Hide();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            hoadon hoadon = new hoadon();
            hoadon.Show();
            this.Hide();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "" || txtTenKH.Text == "" || txtSoDienThoai.Text == "" || txtGioiTinh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            Entity.khachhang kh = new Entity.khachhang();
            kh.MaKH = txtMaKH.Text;
            kh.TemKH = txtTenKH.Text;
            kh.GioiTinht = txtGioiTinh.Text;
            kh.SoDienThoai = txtSoDienThoai.Text;
            bll_KhachHang.themKhachHang(kh);
            loadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            BLL.BLL_KhachHang bll_KhachHang = new BLL.BLL_KhachHang();
            bll_KhachHang.xoaKhachHang(txtMaKH.Text);
            loadData();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "" || txtTenKH.Text == "" || txtSoDienThoai.Text == "" || txtGioiTinh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Entity.khachhang nv = new Entity.khachhang();
            nv.MaKH = txtMaKH.Text;
            nv.TemKH = txtTenKH.Text; 
            nv.GioiTinht = txtGioiTinh.Text;
            nv.SoDienThoai = txtSoDienThoai.Text;
            BLL.BLL_KhachHang bll_KhachHang = new BLL.BLL_KhachHang();
            loadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
