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
    public partial class Nhân_viên : Form
    {
        BLL_NhanVien bll_NhanVien = new BLL.BLL_NhanVien();
        private void loadData()
        {
            List<Entity.Nhân_viên> list = bll_NhanVien.getAllNhanVien();
            dgvNhanVien.DataSource = list;
        }
        private void Nhân_viên_Load(object sender, EventArgs e)
        {
            loadData();
        }
        public Nhân_viên()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnSieuThi_Click(object sender, EventArgs e)
        {
            cuahang cuahang = new cuahang();
            cuahang.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "" || txtTenNV.Text == "" || txtGioiTinh.Text == "" || txtMatKhau.Text == "" || txtSoDienThoai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Entity.Nhân_viên nv = new Entity.Nhân_viên();
            nv.MaNV = txtMaNV.Text;
            nv.TenNV = txtTenNV.Text;
            nv.GioiTinh = txtGioiTinh.Text;
            nv.MatKhau = txtMatKhau.Text;
            nv.SoDienThoai = txtSoDienThoai.Text;
            bll_NhanVien.themNhanVien(nv);
            loadData();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bll_NhanVien.xoaNhanVien(txtMaNV.Text);
            loadData();
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "" || txtTenNV.Text == "" || txtGioiTinh.Text == "" || txtMatKhau.Text == "" || txtSoDienThoai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Entity.Nhân_viên nv = new Entity.Nhân_viên();
            nv.MaNV = txtMaNV.Text;
            nv.TenNV = txtTenNV.Text;
            nv.GioiTinh = txtGioiTinh.Text;
            nv.MatKhau = txtMatKhau.Text;
            nv.SoDienThoai = txtSoDienThoai.Text;
            bll_NhanVien.capnhatNhanVien(nv);
            loadData();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            khachhang khachhang = new khachhang();
            khachhang.Show();
            this.Hide();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            hoadon hoadon = new hoadon();
            hoadon.Show();
            this.Hide();
        }
    }
}
