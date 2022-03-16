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


// Chạy file Partition_QuanLy_DiemDanhNV.sql trước
namespace CSDLNC_CosplayBanHoa
{
    public partial class HieuSuatNV_QL : Form
    {
        // Hai mảng này dùng cho việc tối ưu truy vấn dựa trên partition
        int[] nam2020 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        int[] nam2021 = { 0, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25 };

        int Thang, Nam;
        int ThuTu; // Biến này dùng để lưu vị trí của phần dữ liệu sau khi đã partition
        int[] soNgay = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        string manv;
        int soNgayLam, soNgayNghi;
        int SoLuongDon, SoLuongHang;

        decimal DoanhThu;

        public HieuSuatNV_QL()
        {
            InitializeComponent();
        }

        private void Resetvalues_HieuSuatNV()
        {
            tb_MaCN_QL.Text = "";
            tb_MaNV_QL.Text = "";
            tb_Nam_QL.Text = "";
            tb_SoDHChot_QL.Text = "";
            tb_SoLuongHangBan_QL.Text = "";
            tb_SoNgayNghi_QL.Text = "";
            tb_TenNV_QL.Text = "";
            tb_Thang_QL.Text = "";
            tb_TongDoanhThu_QL.Text = "";
        }

        private void Run_SP_QuanLy_SoNgayDiLamTrongThang()
        {
            SqlCommand cmd = new SqlCommand("SP_QuanLy_SoNgayDiLamTrongThang", Functions.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@MANV", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@THUTU", SqlDbType.Int);

            cmd.Parameters.Add("@SONGAYLAM", SqlDbType.Int).Direction = ParameterDirection.Output;

            // set giá trị
            cmd.Parameters["@MANV"].Value = manv;
            cmd.Parameters["@THUTU"].Value = ThuTu;

            cmd.ExecuteNonQuery();

            soNgayLam = Convert.ToInt32(cmd.Parameters["@SONGAYLAM"].Value);
        }

        private void Panel_HSNV_QL_MouseClick(object sender, MouseEventArgs e)
        {
            Resetvalues_HieuSuatNV();
            tb_Thang_QL.Enabled = true;
            tb_Nam_QL.Enabled = true;
        }

        private void Run_SP_QuanLy_HieuSuatNVTrongThang()
        {
            SqlCommand cmd = new SqlCommand("SP_QuanLy_HieuSuatNVTrongThang", Functions.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@MANV", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@THANG", SqlDbType.Int);
            cmd.Parameters.Add("@NAM", SqlDbType.Int);

            cmd.Parameters.Add("@SOLUONGDON", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@SOLUONGHANG", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@DOANHTHU", SqlDbType.Decimal).Direction = ParameterDirection.Output;

            // set giá trị
            cmd.Parameters["@MANV"].Value = manv;
            cmd.Parameters["@THANG"].Value = Thang;
            cmd.Parameters["@NAM"].Value = Nam;

            cmd.ExecuteNonQuery();

            SoLuongDon = Convert.ToInt32(cmd.Parameters["@SOLUONGDON"].Value);
            SoLuongHang = Convert.ToInt32(cmd.Parameters["@SOLUONGHANG"].Value);
            DoanhThu = Convert.ToDecimal(cmd.Parameters["@DOANHTHU"].Value);

        }

        private void Dgv_HSNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tb_Thang_QL.Enabled = false;
            tb_Nam_QL.Enabled = false;

            tb_MaNV_QL.Text = dgv_HSNV.Rows[e.RowIndex].Cells[0].Value.ToString();
            tb_TenNV_QL.Text = dgv_HSNV.Rows[e.RowIndex].Cells[1].Value.ToString();
            tb_MaCN_QL.Text = dgv_HSNV.Rows[e.RowIndex].Cells[2].Value.ToString();

            // Hien thi so ngay nghi
            manv = tb_MaNV_QL.Text.Trim().ToString();
            Run_SP_QuanLy_SoNgayDiLamTrongThang();
            for (int i = 0; i < soNgay.Length; i++)
            {
                if (ThuTu == i)
                    soNgayNghi = soNgay[i] - soNgayLam;
            }
            tb_SoNgayNghi_QL.Text = soNgayNghi.ToString();

            //Hiển thi số lượng đơn, số lượng hàng hóa, doanh số của nhân viên
            Run_SP_QuanLy_HieuSuatNVTrongThang();

            tb_SoDHChot_QL.Text = SoLuongDon.ToString();
            tb_SoLuongHangBan_QL.Text = SoLuongHang.ToString();
            tb_TongDoanhThu_QL.Text = DoanhThu.ToString();
        }

        private void Btn_TimNV_QL_Click(object sender, EventArgs e)
        {
            // Kiem tra thang va namw da duoc nhap day du thong tin chua
            if (tb_Thang_QL.Text.Trim().Length == 0 | tb_Nam_QL.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tháng và năm để tìm dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Kiem tra thang nhap vao la hop le
            int checkThang = Int32.Parse(tb_Thang_QL.Text.Trim().ToString());
            if (checkThang < 1 | checkThang > 12)
            {
                MessageBox.Show("Tháng vừa nhập không hợp lệ !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            Thang = Int32.Parse(tb_Thang_QL.Text.Trim().ToString());
            Nam = Int32.Parse(tb_Nam_QL.Text.Trim().ToString());
            if (Nam == 2020)
            {
                for (int i = 0; i < nam2020.Length; i++)
                {
                    if (Thang == i)
                        ThuTu = nam2020[i];
                }
            }
            else if (Nam == 2021)
            {
                for (int i = 0; i < nam2021.Length; i++)
                {
                    if (Thang == i)
                        ThuTu = nam2021[i];
                }
            }
            else
            {
                ThuTu = 0;
            }

            DataTable ngayDiLamTrongThangNV;
            string sql = "SP_QuanLy_XuatNgayLamViecCuaNVTrongThang '" + ThuTu + "'";
            ngayDiLamTrongThangNV = Functions.GetDataToTable(sql);
            dgv_HSNV.DataSource = ngayDiLamTrongThangNV;

        }
    }
}
