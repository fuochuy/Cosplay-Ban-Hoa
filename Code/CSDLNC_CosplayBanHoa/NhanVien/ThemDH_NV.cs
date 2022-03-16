using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CSDLNC_CosplayBanHoa
{
    public partial class ThemDH_NV : Form
    {
        DataTable tbl_SP;
        DataTable tbl_SP2;
        string MANV;
        Form_Loading form_loading = new Form_Loading();

        public ThemDH_NV(string id)
        {
            InitializeComponent();
            string sql = "SELECT MANV FROM NHANVIEN WHERE ID = '" + id + "'";
            MANV = Functions.GetFieldValues(sql);
        }

        private void Load_Data()
        {
            string sql = "SELECT MASP, TENSP, GIAGOC, KHUYENMAI, MOTA, CHITIETSP, HINHANH, SOLUONGTON " +
               "FROM SANPHAM";
            tbl_SP = Functions.GetDataToTable(sql);
            dGV_SP_ThemDH.DataSource = tbl_SP;

            // set Font cho tên cột
            dGV_SP_ThemDH.Font = new Font("Time New Roman", 13);
            dGV_SP_ThemDH.Columns[0].HeaderText = "Mã sản phẩm";
            dGV_SP_ThemDH.Columns[1].HeaderText = "Tên sản phẩm";
            dGV_SP_ThemDH.Columns[2].HeaderText = "Giá gốc";
            dGV_SP_ThemDH.Columns[3].HeaderText = "Khuyến mãi";
            dGV_SP_ThemDH.Columns[4].HeaderText = "Mô tả";
            dGV_SP_ThemDH.Columns[5].HeaderText = "Chi tiết sản phẩm";
            dGV_SP_ThemDH.Columns[6].HeaderText = "Hình ảnh";
            dGV_SP_ThemDH.Columns[7].HeaderText = "Số lượng tồn";

            // set Font cho dữ liệu hiển thị trong cột
            dGV_SP_ThemDH.DefaultCellStyle.Font = new Font("Time New Roman", 12);

            // set kích thước cột
            dGV_SP_ThemDH.Columns[0].Width = 0;
            dGV_SP_ThemDH.Columns[1].Width = 200;
            dGV_SP_ThemDH.Columns[2].Width = 200;
            dGV_SP_ThemDH.Columns[3].Width = 200;
            dGV_SP_ThemDH.Columns[4].Width = 200;
            dGV_SP_ThemDH.Columns[5].Width = 200;
            dGV_SP_ThemDH.Columns[6].Width = 0;
            dGV_SP_ThemDH.Columns[7].Width = 200;


            //Không cho người dùng thêm dữ liệu trực tiếp
            dGV_SP_ThemDH.AllowUserToAddRows = false;
            dGV_SP_ThemDH.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btn_tieptuc_ThemDH_NV_Click(object sender, EventArgs e)
        {
            if (txtBox_tensp_ThemDH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm nào !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ThongTinTT_NV thongTinTT_NV = new ThongTinTT_NV(
                dGV_SP_ThemDH.CurrentRow.Cells["MASP"].Value.ToString(),
                dGV_SP_ThemDH.CurrentRow.Cells["TENSP"].Value.ToString(),
                txtBox_giamoi_ThemDH.Text.Trim().ToString(),
                dGV_SP_ThemDH.CurrentRow.Cells["SOLUONGTON"].Value.ToString(),
                MANV);
            thongTinTT_NV.StartPosition = FormStartPosition.CenterScreen;
            thongTinTT_NV.Show();
        }

        private void dGV_SP_ThemDH_Click(object sender, EventArgs e)
        {
            //Nếu không có dữ liệu
            if (tbl_SP.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục 
            double phantram = (double)(100 - Int32.Parse(dGV_SP_ThemDH.CurrentRow.Cells["KHUYENMAI"].Value.ToString())) / 100;
            double giagoc = double.Parse(dGV_SP_ThemDH.CurrentRow.Cells["GIAGOC"].Value.ToString());
            double giamoi = (double)(phantram * giagoc);
            giamoi = Math.Round(giamoi, 4);

            txtBox_tensp_ThemDH.Text = dGV_SP_ThemDH.CurrentRow.Cells["TENSP"].Value.ToString();
            txtBox_giacu_ThemDH.Text = dGV_SP_ThemDH.CurrentRow.Cells["GIAGOC"].Value.ToString();
            txtBox_giamoi_ThemDH.Text = giamoi.ToString("0.0000");
            txtBox_mota_ThemDH.Text = dGV_SP_ThemDH.CurrentRow.Cells["MOTA"].Value.ToString();
            txtBox_chitietsp_ThemDH.Text = dGV_SP_ThemDH.CurrentRow.Cells["CHITIETSP"].Value.ToString();

            // load anh 
            try
            {
                picBox_anh_DT.Load(dGV_SP_ThemDH.CurrentRow.Cells["HINHANH"].Value.ToString());
            }
            catch (Exception loi)
            {
                MessageBox.Show("Load ảnh thất bại, mã lỗi: " + loi.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void ThemDH_NV_Load(object sender, EventArgs e)
        {
            Thread t = new Thread(() =>
            {
                form_loading.StartPosition = FormStartPosition.CenterParent;
                form_loading.ShowDialog();
            });

            // show form loading         
            t.Start();

            Load_Data();

            form_loading.Close_Form();
        }

        private void btn_timkiem_ThemDH_Click(object sender, EventArgs e)
        {
            if (txtBox_timkiem_ThemDH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập từ khóa vào ô tìm kiếm !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string tukhoa = txtBox_timkiem_ThemDH.Text.Trim();
            string sql = "Sp_KH_TimKiemSP '" + tukhoa + "'";
            tbl_SP2 = Functions.GetDataToTable(sql);
            dGV_SP_ThemDH.DataSource = tbl_SP2;
        }

        private void btn_huytimkiem_ThemDH_Click(object sender, EventArgs e)
        {
            txtBox_timkiem_ThemDH.Text = "";
            dGV_SP_ThemDH.DataSource = tbl_SP;
        }
    }
}
