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
using System.Runtime.Hosting;
using ClosedXML.Excel;
using System.Data;

namespace Minimarket
{
    public partial class hoadon : Form
    {

        public hoadon()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-8MNKNMM\SQLEXPRESS;Initial Catalog=minimartdb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void hoadon_Load(object sender, EventArgs e)
        {
            labelNgay.Text = DateTime.Now.ToShortDateString();
            getTable();
            getCategory();
            getSellTable();
        }
        private void getTable()
        {
            string selectQuery = "SELECT TenSP, Gia, ChatLuong FROM CuaHang";
            SqlCommand command = new SqlCommand(selectQuery, (SqlConnection)con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dgvSP.DataSource = dataTable;
        }

        private void getCategory()
        {
            string selectQuery = "SELECT * FROM CuaHang";
            SqlCommand command = new SqlCommand(selectQuery, (SqlConnection)con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cboSP.DataSource = dataTable;
            cboSP.DisplayMember = "TenSP";
        }

        private void dgvSP_Click(object sender, EventArgs e)
        {
            txtTenSP.Text = dgvSP.CurrentRow.Cells[0].Value.ToString();
            txtGia.Text = dgvSP.CurrentRow.Cells[1].Value.ToString();
            txtChatLuong.Text = dgvSP.CurrentRow.Cells[2].Value.ToString();

        }
        int GrantTotal = 0, n = 0;

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtGia.Text, out int gia))
            {
                MessageBox.Show("Giá phải là số!");
                return;
            }

            if (!int.TryParse(txtChatLuong.Text, out int chatLuong))
            {
                MessageBox.Show("Chất lượng phải là số!");
                return;
            }

            int total = gia * chatLuong;

            DataGridViewRow addRow = new DataGridViewRow();
            addRow.CreateCells(dgvSP);
            addRow.Cells[0].Value = gia;
            addRow.Cells[1].Value = chatLuong;
            addRow.Cells[2].Value = total;

            dgvHoadon.Rows.Add(addRow);
            GrantTotal += total;
            labelThanhTien.Text = "Tổng tiền: " + GrantTotal + " VNĐ";
        }
        private void getSellTable()
        {
            string selectQuery = "SELECT * FROM HoaDon";
            SqlCommand command = new SqlCommand(selectQuery, (SqlConnection)con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dgvIn.DataSource = dataTable;

        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelNgay_Click(object sender, EventArgs e)
        {

        }

        private void labelTenNV_Click(object sender, EventArgs e)
        {

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "Excel Files|*.xlsx",
                    FileName = "HoaDon.xlsx"
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add("HoaDon");

                            // Header
                            for (int i = 0; i < dgvIn.Columns.Count; i++)
                                ws.Cell(1, i + 1).Value = dgvIn.Columns[i].HeaderText;

                            // Data
                            for (int i = 0; i < dgvIn.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgvIn.Columns.Count; j++)
                                {
                                    ws.Cell(i + 2, j + 1).Value =
                                        ClosedXML.Excel.XLCellValue.FromObject(dgvIn.Rows[i].Cells[j].Value);
                                }
                            }

                            ws.Columns().AdjustToContents();
                            wb.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("Xuất Excel thành công!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string insertQuery = @"
        INSERT INTO HoaDon (nhanvien, ngayban, tong)
        VALUES (@nhanvien, @ngayban, @tong)";

                SqlCommand command = new SqlCommand(insertQuery, con);

                
                command.Parameters.AddWithValue("@nhanvien", labelTenNV.Text);
                command.Parameters.AddWithValue("@ngayban", labelNgay.Text);
                command.Parameters.AddWithValue("@tong", labelThanhTien.Text);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Đã thêm hóa đơn thành công!");
                getSellTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }


    }
}
