using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

namespace Minimarket
{
    public partial class dangnhap : Form
    {
        DbConnection connection = new SqlConnection("Data Source=DESKTOP-EXAMPLE;Initial Catalog=MinimarketDB;Integrated Security=True");
        public dangnhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTK.Text == "" || txtMK.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (cboVaiTro.SelectedIndex > -1)
                {
                    if (cboVaiTro.SelectedItem.ToString() == "Admin")
                    {
                        if (txtTK.Text == "hung" && txtMK.Text == "hung")
                        {
                            Nhân_viên nhanVien = new Nhân_viên();
                            nhanVien.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        string selectQuery = "SELECT * FROM NhanVien WHERE TaiKhoan = @TaiKhoan AND MatKhau = @MatKhau";
                        DataTable table = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, (SqlConnection)connection);
                        adapter.Fill(table);
                        if (table.Rows.Count > 0)
                        {
                            cuahang cuahang = new cuahang();
                            cuahang.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }


                }
                else
                {
                    MessageBox.Show("Vui lòng chọn vai trò!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtTK_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
