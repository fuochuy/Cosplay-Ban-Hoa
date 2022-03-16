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

namespace CSDLNC_CosplayBanHoa
{
    public partial class QLNhanVien : Form
    {
        string manv;
        string tennv;
        string cnlamviec;
        string id;
        float luong;
        Int32 loainv;
        DataTable tbQLNV;

        public QLNhanVien()
        {
            InitializeComponent();
            LoadData_QLNhanVien();
        }

        private void SetFont_QLNhanVien()
        {
            tb_MaNV_NS.Font = new Font("Time New Roman", 12);
            tb_TenNV_NS.Font = new Font("Time New Roman", 12);
            tb_IdNV_NS.Font = new Font("Time New Roman", 12);
            tb_CNlamviec_NS.Font = new Font("Time New Roman", 12);
            tb_LuongNV_NS.Font = new Font("Time New Roman", 12);
            tb_LoaiNV_NS.Font = new Font("Time New Roman", 12);
        }

        private void Resetvalues_QLNhanVien() //Reset gia tri chon mode them nhan vien
        {
            tb_MaNV_NS.Text = "";
            tb_TenNV_NS.Text = "";
            tb_IdNV_NS.Text = "";
            tb_CNlamviec_NS.Text = "";
            tb_LuongNV_NS.Text = "";
            tb_LoaiNV_NS.Text = "";
        }

        private void LoadData_QLNhanVien() // Nap data vao DataGridView
        {
            DataTable tbQLNV;
            string sql = "SELECT NV.MANV, NV.ID, NV.TENNV, NV.CHINHANHLV, NV.LOAINV, " +
                "L.LUONG " +
                "FROM NHANVIEN NV, LUONG L " +
                "WHERE NV.MANV = L.MANV " +
                "GROUP BY NV.MANV, L.MANV, L.NGAY, NV.ID, NV.TENNV, NV.CHINHANHLV, NV.LOAINV, L.LUONG " +
                "HAVING ABS(DATEDIFF(day, GETDATE(), L.NGAY)) = (SELECT MIN(ABS(DATEDIFF(day, GETDATE(), L.NGAY))) FROM LUONG L1 WHERE L1.MANV = L.MANV GROUP BY L1.MANV, L1.NGAY)";


            // Functions.Connect();
            tbQLNV = Functions.GetDataToTable(sql);
            dGV_QLNV.DataSource = tbQLNV;

            // set Font cho tên cột
            dGV_QLNV.Font = new Font("Time New Roman", 13);
            dGV_QLNV.Columns[0].HeaderText = "Mã nhân viên";
            dGV_QLNV.Columns[1].HeaderText = "ID";
            dGV_QLNV.Columns[2].HeaderText = "Tên nhân viên";
            dGV_QLNV.Columns[3].HeaderText = "Mã chi nhánh";
            dGV_QLNV.Columns[4].HeaderText = "Loại NV";

            // set Font cho dữ liệu hiển thị trong cột
            dGV_QLNV.DefaultCellStyle.Font = new Font("Time New Roman", 12);

            // set kích thước cột
            dGV_QLNV.Columns[0].Width = 200;
            dGV_QLNV.Columns[1].Width = 200;
            dGV_QLNV.Columns[2].Width = 200;
            dGV_QLNV.Columns[3].Width = 200;
            dGV_QLNV.Columns[4].Width = 200;


            //Không cho người dùng thêm dữ liệu trực tiếp
            dGV_QLNV.AllowUserToAddRows = false;
            dGV_QLNV.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        // Hàm chạy SP_NhanSu_ThemNV
        private void Run_SP_NhanSu_ThemNV()
        {
            SqlCommand cmd = new SqlCommand("SP_NhanSu_ThemNV", Functions.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@MANV", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@ID", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@TENNV", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@CHINHANHLV", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@LOAINV", SqlDbType.Int);
            cmd.Parameters.Add("@LUONG", SqlDbType.Decimal, 50);


            // set giá trị
            cmd.Parameters["@MANV"].Value = manv;
            cmd.Parameters["@ID"].Value = id;
            cmd.Parameters["@TENNV"].Value = tennv;
            cmd.Parameters["@CHINHANHLV"].Value = cnlamviec;
            cmd.Parameters["@LOAINV"].Value = loainv;
            cmd.Parameters["@LUONG"].Value = luong;

            cmd.ExecuteNonQuery();
        }

        // Hàm chạy SP_NhanSu_CapNhatNV
        private void Run_SP_NhanSu_CapNhatNV()
        {
            SqlCommand cmd = new SqlCommand("SP_NhanSu_CapNhatNV", Functions.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@MANV", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@ID", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@TENNV", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@CHINHANHLV", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@LOAINV", SqlDbType.Int);
            cmd.Parameters.Add("@LUONG", SqlDbType.Decimal, 50);

            // set giá trị
            cmd.Parameters["@MANV"].Value = manv;
            cmd.Parameters["@ID"].Value = id;
            cmd.Parameters["@TENNV"].Value = tennv;
            cmd.Parameters["@CHINHANHLV"].Value = cnlamviec;
            cmd.Parameters["@LOAINV"].Value = loainv;
            cmd.Parameters["@LUONG"].Value = luong;

            cmd.ExecuteNonQuery();
        }

        // Ham chạy SP_NhanSu_XoaNV
        private void Run_SP_NhanSu_XoaNV()
        {
            SqlCommand cmd = new SqlCommand("SP_NhanSu_XoaNV", Functions.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@MANV", SqlDbType.VarChar, 15);

            // set giá trị
            cmd.Parameters["@MANV"].Value = manv;
            cmd.ExecuteNonQuery();
        }

        private void Btn_ThemNV_NS_Click(object sender, EventArgs e) // Xu ly click khi nhan vao nut Them
        {
            //Kiem tra co nhap day du du lieu chua
            if (tb_CNlamviec_NS.Text.Trim().Length == 0 | tb_IdNV_NS.Text.Trim().Length == 0 | tb_LoaiNV_NS.Text.Trim().Length == 0 |
                tb_LuongNV_NS.Text.Trim().Length == 0 | tb_MaNV_NS.Text.Trim().Length == 0 | tb_TenNV_NS.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            manv = tb_MaNV_NS.Text.Trim().ToString();
            tennv = tb_TenNV_NS.Text.Trim().ToString();
            cnlamviec = tb_CNlamviec_NS.Text.Trim().ToString();
            id = tb_IdNV_NS.Text.Trim().ToString();
            loainv = Int32.Parse(tb_LoaiNV_NS.Text.Trim().ToString());
            luong = float.Parse(tb_LuongNV_NS.Text.Trim().ToString());

            //TH MANV da ton tai
            string sql = "SELECT MANV FROM NHANVIEN " +
                "WHERE MANV = '" + tb_MaNV_NS.Text.Trim().ToString() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_MaNV_NS.Focus();
                return;
            }

            //TH ID khong ton tai trong he thong
            sql = "SELECT ID FROM TAIKHOAN " +
                "WHERE ID = '" + tb_IdNV_NS.Text.Trim().ToString() + "'";
            if (!Functions.CheckKey(sql))
            {
                MessageBox.Show("ID tài khoản không tồn tại trong hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_IdNV_NS.Focus();
                return;
            }

            //TH MACN khong ton tai trong he thong
            sql = "SELECT MACN FROM CHINHANH " +
                "WHERE MACN = '" + tb_CNlamviec_NS.Text.Trim().ToString() + "'";
            if (!Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã chi nhánh không tồn tại trong hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_CNlamviec_NS.Focus();
                return;
            }

            //TH Loai NV khong thuoc khoảng từ 0 đến 2
            int giaTriLoaiNV = Int32.Parse(tb_LoaiNV_NS.Text.Trim().ToString());
            if (giaTriLoaiNV < 0 | giaTriLoaiNV > 2)
            {
                MessageBox.Show("Loại nhân viên không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_LoaiNV_NS.Focus();
                return;
            }

            // Sau khi xong phần kiểm tra, tiến hành thêm thông tin mới nhập vào hệ thống
            Run_SP_NhanSu_ThemNV();

            // Thong bao da them thanh cong
            MessageBox.Show("Nhân viên đã được thêm vào hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset value cac text box
            Resetvalues_QLNhanVien();
        }

        private void Btn_SuaNV_NS_Click(object sender, EventArgs e) // Xử lý khi nhấn vào nút Sửa
        {
            //Kiem tra co nhap day du du lieu chua
            if (tb_CNlamviec_NS.Text.Trim().Length == 0 | tb_IdNV_NS.Text.Trim().Length == 0 | tb_LoaiNV_NS.Text.Trim().Length == 0 |
                tb_LuongNV_NS.Text.Trim().Length == 0 | tb_MaNV_NS.Text.Trim().Length == 0 | tb_TenNV_NS.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            manv = tb_MaNV_NS.Text.Trim().ToString();
            tennv = tb_TenNV_NS.Text.Trim().ToString();
            cnlamviec = tb_CNlamviec_NS.Text.Trim().ToString();
            id = tb_IdNV_NS.Text.Trim().ToString();
            loainv = Int32.Parse(tb_LoaiNV_NS.Text.Trim().ToString());
            luong = float.Parse(tb_LuongNV_NS.Text.Trim().ToString());

            //TH ID khong ton tai trong he thong
            string sql = "SELECT ID FROM TAIKHOAN " +
                "WHERE ID = '" + tb_IdNV_NS.Text.Trim().ToString() + "'";
            if (!Functions.CheckKey(sql))
            {
                MessageBox.Show("ID tài khoản không tồn tại trong hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_IdNV_NS.Focus();
                return;
            }

            //TH MACN khong ton tai trong he thong
            sql = "SELECT MACN FROM CHINHANH " +
                "WHERE MACN = '" + tb_CNlamviec_NS.Text.Trim().ToString() + "'";
            if (!Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã chi nhánh không tồn tại trong hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_CNlamviec_NS.Focus();
                return;
            }

            //TH Loai NV khong thuoc khoảng từ 0 đến 2
            int giaTriLoaiNV = Int32.Parse(tb_LoaiNV_NS.Text.Trim().ToString());
            if (giaTriLoaiNV < 0 | giaTriLoaiNV > 2)
            {
                MessageBox.Show("Loại nhân viên không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_LoaiNV_NS.Focus();
                return;
            }

            // Sau khi xong phần kiểm tra, tiến hành cập nhật thông tin mới nhập vào hệ thống
            Run_SP_NhanSu_CapNhatNV();

            // Thong bao da them thanh cong
            MessageBox.Show("Thông tin đã được cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset value cac text box
            Resetvalues_QLNhanVien();


            // Refresh lại dataGridView
            LoadData_QLNhanVien();
        }

        private void Panel_QLNV_NS_MouseClick(object sender, MouseEventArgs e) // Xử lý khi nhấn vào panel
        {
            Resetvalues_QLNhanVien();
            btn_ThemNV_NS.Enabled = true;
            btn_XoaNV_NS.Enabled = false;
            btn_SuaNV_NS.Enabled = false;
            tb_MaNV_NS.Enabled = true;
            LoadData_QLNhanVien();
        }

        private void Btn_XoaNV_NS_Click(object sender, EventArgs e)
        {
            manv = tb_MaNV_NS.Text.Trim().ToString();

            Run_SP_NhanSu_XoaNV();

            // Thong bao da xóa thanh cong
            MessageBox.Show("Thông tin nhân viên đã được xóa khỏi hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset value cac text box
            Resetvalues_QLNhanVien();

            // Refresh lại dataGridView
            LoadData_QLNhanVien();
        }

        private void Btn_Thoat_NS_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_TimNVtheoCN_NS_Click(object sender, EventArgs e)
        {
            //Kiem tra xem chi nhanh lam viec da duoc nhap chua
            if (tb_CNlamviec_NS.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //TH MACN khong ton tai trong he thong
            string sql = "SELECT MACN FROM CHINHANH " +
                "WHERE MACN = '" + tb_CNlamviec_NS.Text.Trim().ToString() + "'";
            if (!Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã chi nhánh không tồn tại trong hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_CNlamviec_NS.Focus();
                return;
            }

            MessageBox.Show("Tìm kiếm hoàn tất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DataTable tbTimNVtheoCN;

            string maCNdeTimNV = tb_CNlamviec_NS.Text.Trim();
            sql = "SP_NhanSu_TimNVtheoCN '" + maCNdeTimNV + "'";
            //  Functions.Connect();
            tbTimNVtheoCN = Functions.GetDataToTable(sql);
            dGV_QLNV.DataSource = tbTimNVtheoCN;
        }


        private void QLNhanVien_Load(object sender, EventArgs e)
        {
            SetFont_QLNhanVien();
            Resetvalues_QLNhanVien();
            LoadData_QLNhanVien();
        }

        private void dGV_QLNV_Click(object sender, EventArgs e)
        {
            tb_MaNV_NS.Text = dGV_QLNV.CurrentRow.Cells["MANV"].Value.ToString();
            tb_IdNV_NS.Text = dGV_QLNV.CurrentRow.Cells["ID"].Value.ToString();
            tb_TenNV_NS.Text = dGV_QLNV.CurrentRow.Cells["TENNV"].Value.ToString();
            tb_CNlamviec_NS.Text = dGV_QLNV.CurrentRow.Cells["CHINHANHLV"].Value.ToString();
            tb_LoaiNV_NS.Text = dGV_QLNV.CurrentRow.Cells["LOAINV"].Value.ToString();
            tb_LuongNV_NS.Text = dGV_QLNV.CurrentRow.Cells["LUONG"].Value.ToString();

            // Xử lý enable cho các button và textbox
            tb_MaNV_NS.Enabled = false;
            btn_SuaNV_NS.Enabled = true;
            btn_XoaNV_NS.Enabled = true;
            btn_ThemNV_NS.Enabled = false;
        }
    }
}
