using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;  
using Entity;   

namespace Minimarket
{
    public partial class cuahang : Form
    {
        BLL_CuaHang bll_CuaHang = new BLL_CuaHang();
        private void loadData()
        {
            List<CuaHang> list = bll_CuaHang.getAllCuaHang();
            dgvSieuThi.DataSource = list;
        }
        private void cuahang_Load(object sender, EventArgs e)
        {
            loadData();
        }
        public cuahang()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaSp.Text == "" || txtTenSP.Text == "" || txtGia.Text == "" || txtChatLuong.Text == "" || txtSoLuong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            CuaHang ch = new CuaHang();
            ch.MaSP = int.Parse(txtMaSp.Text); 
            ch.TenSP = txtTenSP.Text;
            ch.Gia = (int)decimal.Parse(txtGia.Text);
            ch.ChatLuong = txtChatLuong.Text;
            ch.SoLuong = int.Parse(txtSoLuong.Text);
            bll_CuaHang.themCuaHang(ch);
            loadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSp.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMaSp.Text == "" || txtTenSP.Text == "" || txtGia.Text == "" || txtChatLuong.Text == "" || txtSoLuong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            Nhân_viên f = new Nhân_viên();
            f.Show();
            this.Hide();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            khachhang f = new khachhang();
            f.Show();
            this.Hide();
        }

        private void btnHoadon_Click(object sender, EventArgs e)
        {
            hoadon f = new hoadon();
            f.Show();
            this.Hide();

        }
    }
}
