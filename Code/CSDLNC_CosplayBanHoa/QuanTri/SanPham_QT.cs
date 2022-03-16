using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDLNC_CosplayBanHoa
{
    public partial class SanPham_QT : Form
    {
        DataTable tbl_QT_SP;
        public SanPham_QT()
        {
            InitializeComponent();
        }
        

        private void LoadData_TatCaSP() // tải dữ liệu vào DataGridView
        {
           
            string sql = "SP_QT_TatCaSP";
            tbl_QT_SP = Functions.GetDataToTable(sql);
            dGV_QT_SP.DataSource = tbl_QT_SP;

            // set Font cho tên cột
            dGV_QT_SP.Font = new Font("Time New Roman", 13);
            dGV_QT_SP.Columns[0].HeaderText = "Mã sản phẩm";
            dGV_QT_SP.Columns[1].HeaderText = "Tên sản phẩm";
            dGV_QT_SP.Columns[2].HeaderText = "Thành phần chính";
            dGV_QT_SP.Columns[3].HeaderText = "Mô tả";
            dGV_QT_SP.Columns[4].HeaderText = "Số lượng tồn";
            dGV_QT_SP.Columns[5].HeaderText = "Giá gốc";
            dGV_QT_SP.Columns[6].HeaderText = "Chi tiết sản phẩm";
            dGV_QT_SP.Columns[7].HeaderText = "Khuyến mãi";
            dGV_QT_SP.Columns[8].HeaderText = "Hình ảnh";

            // set Font cho dữ liệu hiển thị trong cột
            dGV_QT_SP.DefaultCellStyle.Font = new Font("Time New Roman", 12);

            // set kích thước cột
            dGV_QT_SP.Columns[0].Width = 200;
            dGV_QT_SP.Columns[1].Width = 200;
            dGV_QT_SP.Columns[2].Width = 200;
            dGV_QT_SP.Columns[3].Width = 200;
            dGV_QT_SP.Columns[4].Width = 200;
            dGV_QT_SP.Columns[5].Width = 200;
            dGV_QT_SP.Columns[6].Width = 200;
            dGV_QT_SP.Columns[7].Width = 200;
            dGV_QT_SP.Columns[8].Width = 200;
       


            //Không cho người dùng thêm dữ liệu trực tiếp
            dGV_QT_SP.AllowUserToAddRows = false;

            dGV_QT_SP.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void SanPham_QT_Load(object sender, EventArgs e)
        {
            LoadData_TatCaSP();
        }

        private void dGV_QT_SP_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (tbl_QT_SP.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            // set giá trị cho các mục 
            textBox_QT_SP_MASP.Text = dGV_QT_SP.CurrentRow.Cells["MASP"].Value.ToString();
            txtBox_QT_SP_TenSP.Text = dGV_QT_SP.CurrentRow.Cells["TENSP"].Value.ToString();
            textBox_QT_SP_TPC.Text = dGV_QT_SP.CurrentRow.Cells["THANHPHANCHINH"].Value.ToString();
            textBox_QT_SP_MoTa.Text = dGV_QT_SP.CurrentRow.Cells["MOTA"].Value.ToString();
            txtBox_QT_SP_SL.Text = dGV_QT_SP.CurrentRow.Cells["SOLUONGTON"].Value.ToString();
            txtBox_QT_SP_GiaGoc.Text = dGV_QT_SP.CurrentRow.Cells["GIAGOC"].Value.ToString();
            textBox_QT_SP_CTSP.Text = dGV_QT_SP.CurrentRow.Cells["CHITIETSP"].Value.ToString();
            textBox_QT_SP_KM.Text = dGV_QT_SP.CurrentRow.Cells["KHUYENMAI"].Value.ToString();
            textBox_HinhAnh.Text = dGV_QT_SP.CurrentRow.Cells["HINHANH"].Value.ToString();
            // load anh 
            try
            {
                picBox_QT_SP_Anh.Load(textBox_HinhAnh.Text);
            }
            catch (Exception loi)
            {
                MessageBox.Show("Load ảnh thất bại, mã lỗi: " + loi.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void button_ThemSP_Click(object sender, EventArgs e)
        {
            textBox_QT_SP_MASP.Text =  "";
            txtBox_QT_SP_TenSP.Text = "";
            textBox_QT_SP_TPC.Text = "";
            textBox_QT_SP_MoTa.Text = "";
            txtBox_QT_SP_SL.Text = "";
            txtBox_QT_SP_GiaGoc.Text = "";
            textBox_QT_SP_CTSP.Text = "";
            textBox_QT_SP_KM.Text = "";
            textBox_HinhAnh.Text = "";
        }
        
        private void button_LuuSP_Click(object sender, EventArgs e)
        {
            // TH người dùng chưa nhập đầy đủ dữ liệu chưa
            if (textBox_QT_SP_MASP.Text.Trim().Length == 0 || txtBox_QT_SP_TenSP.Text.Trim().Length == 0
                || textBox_QT_SP_TPC.Text.Trim().Length == 0
                || textBox_QT_SP_MoTa.Text.Trim().Length == 0 || txtBox_QT_SP_SL.Text.Trim().Length == 0
                || txtBox_QT_SP_GiaGoc.Text.Trim().Length == 0 || textBox_QT_SP_CTSP.Text.Trim().Length == 0
                || textBox_QT_SP_KM.Text.Trim().Length == 0 || textBox_HinhAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập đầy đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // nếu đã thỏa hết các điều kiện ở trên
            try
            {
                string masp = textBox_QT_SP_MASP.Text.Trim().ToString();
                string tensp = txtBox_QT_SP_TenSP.Text.Trim().ToString();
                string tpc = textBox_QT_SP_TPC.Text.Trim().ToString(); 
                string mota = textBox_QT_SP_MoTa.Text.Trim().ToString(); 
                string soluong = txtBox_QT_SP_SL.Text.Trim().ToString(); 
                string giagoc = txtBox_QT_SP_GiaGoc.Text.Trim().ToString(); 
                string ctsp = textBox_QT_SP_CTSP.Text.Trim().ToString();
                string km= textBox_QT_SP_KM.Text.Trim().ToString(); 
                string hinhanh = textBox_HinhAnh.Text.Trim().ToString();

                string sql = "SP_QT_THEMSP " + "'" + masp + "',N'" + tensp + "',N'" + tpc + "','" + hinhanh
                    + "',N'" + mota + "'," + giagoc + ",N'" + ctsp + "'," + km + "," + soluong;
                Functions.RunSQL(sql);

                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox_QT_SP_MASP.Text = "";
                txtBox_QT_SP_TenSP.Text = "";
                textBox_QT_SP_TPC.Text = "";
                textBox_QT_SP_MoTa.Text = "";
                txtBox_QT_SP_SL.Text = "";
                txtBox_QT_SP_GiaGoc.Text = "";
                textBox_QT_SP_CTSP.Text = "";
                textBox_QT_SP_KM.Text = "";
                textBox_HinhAnh.Text = "";
                LoadData_TatCaSP();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thông tin thất bại, mã lỗi: " + ex.Message); // This will display all the error in your statement.
            }
        }

        private void button_QT_XoaSP_Click(object sender, EventArgs e)
        {
            if (textBox_QT_SP_MASP.Text.Trim().Length == 0 || txtBox_QT_SP_TenSP.Text.Trim().Length == 0
                || textBox_QT_SP_TPC.Text.Trim().Length == 0
                || textBox_QT_SP_MoTa.Text.Trim().Length == 0 || txtBox_QT_SP_SL.Text.Trim().Length == 0
                || txtBox_QT_SP_GiaGoc.Text.Trim().Length == 0 || textBox_QT_SP_CTSP.Text.Trim().Length == 0
                || textBox_QT_SP_KM.Text.Trim().Length == 0 || textBox_HinhAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // nếu đã thỏa hết các điều kiện ở trên
            try
            {

                string masp = textBox_QT_SP_MASP.Text.Trim().ToString();
                string sql = "SP_QT_XOASP '" + masp + "'";
                Functions.RunSQL(sql);

                MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData_TatCaSP();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa sản phẩm thất bại, mã lỗi: " + ex.Message); // This will display all the error in your statement.
            }
        }

        private void button_QT_CapNhatSP_Click(object sender, EventArgs e)
        {
            if (textBox_QT_SP_MASP.Text.Trim().Length == 0 || txtBox_QT_SP_TenSP.Text.Trim().Length == 0
                            || textBox_QT_SP_TPC.Text.Trim().Length == 0
                            || textBox_QT_SP_MoTa.Text.Trim().Length == 0 || txtBox_QT_SP_SL.Text.Trim().Length == 0
                            || txtBox_QT_SP_GiaGoc.Text.Trim().Length == 0 || textBox_QT_SP_CTSP.Text.Trim().Length == 0
                            || textBox_QT_SP_KM.Text.Trim().Length == 0 || textBox_HinhAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // nếu đã thỏa hết các điều kiện ở trên
            try
            {

                string masp = textBox_QT_SP_MASP.Text.Trim().ToString();
                string tensp = txtBox_QT_SP_TenSP.Text.Trim().ToString();
                string tpc = textBox_QT_SP_TPC.Text.Trim().ToString();
                string mota = textBox_QT_SP_MoTa.Text.Trim().ToString();
                string soluong = txtBox_QT_SP_SL.Text.Trim().ToString();
                string giagoc = txtBox_QT_SP_GiaGoc.Text.Trim().ToString();
                string ctsp = textBox_QT_SP_CTSP.Text.Trim().ToString();
                string km = textBox_QT_SP_KM.Text.Trim().ToString();
                string hinhanh = textBox_HinhAnh.Text.Trim().ToString();

                string sql = "SP_QT_CAPNHAT " + "'" + masp + "',N'" + tensp + "',N'" + tpc + "','" + hinhanh
                    + "',N'" + mota + "'," + giagoc + ",N'" + ctsp + "'," + km + "," + soluong;
                Functions.RunSQL(sql);

                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData_TatCaSP();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật sản phẩm thất bại, mã lỗi: " + ex.Message); // This will display all the error in your statement.
            }
        }
    }
}
