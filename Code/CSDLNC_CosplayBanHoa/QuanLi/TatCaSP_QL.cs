using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace CSDLNC_CosplayBanHoa
{
    public partial class ThongKe_QL : Form
    {
        DataTable tbl_tatcaSP;
        DataTable tbl_tatcaSP2;
        private void Load_Data_TCSP()
        {
            string sql = "Sp_TatCaSanPham";
            tbl_tatcaSP = Functions.GetDataToTable(sql);
            dgv_tatcaSP_SLH.DataSource = tbl_tatcaSP;           
            // set Font cho tên cột
            dgv_tatcaSP_SLH.Font = new Font("Time New Roman", 13);
            dgv_tatcaSP_SLH.Columns[0].HeaderText = "Mã sản phẩm";
            dgv_tatcaSP_SLH.Columns[1].HeaderText = "Tên sản phẩm";
            dgv_tatcaSP_SLH.Columns[2].HeaderText = "Thành phần chính";
            dgv_tatcaSP_SLH.Columns[3].HeaderText = "Số lượng tồn";
            dgv_tatcaSP_SLH.Columns[4].HeaderText = "Giá gốc";
            dgv_tatcaSP_SLH.Columns[5].HeaderText = "Khuyến mãi";
            dgv_tatcaSP_SLH.Columns[6].HeaderText = "Giá nhập";
            dgv_tatcaSP_SLH.Columns[7].HeaderText = "Giá giảm";
            dgv_tatcaSP_SLH.Columns[8].HeaderText = "Hình ảnh";

            // set Font cho dữ liệu hiển thị trong cột
            dgv_tatcaSP_SLH.DefaultCellStyle.Font = new Font("Time New Roman", 12);

            // set kích thước cột
            dgv_tatcaSP_SLH.Columns[0].Width = 200;
            dgv_tatcaSP_SLH.Columns[1].Width = 200;
            dgv_tatcaSP_SLH.Columns[2].Width = 200;
            dgv_tatcaSP_SLH.Columns[3].Width = 200;
            dgv_tatcaSP_SLH.Columns[4].Width = 200;
            dgv_tatcaSP_SLH.Columns[5].Width = 200;
            dgv_tatcaSP_SLH.Columns[6].Width = 200;
            dgv_tatcaSP_SLH.Columns[7].Width = 200;
            dgv_tatcaSP_SLH.Columns[8].Width = 200;


            //Không cho người dùng thêm dữ liệu trực tiếp
            dgv_tatcaSP_SLH.AllowUserToAddRows = false;
            dgv_tatcaSP_SLH.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btn_xemtatcaSp_SLH_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() =>
            {
                form_loading.StartPosition = FormStartPosition.CenterParent;
                form_loading.ShowDialog();
            });

            // show form loading         
            t.Start();

            Load_Data_TCSP();

            form_loading.Close_Form();
        }

        private void dgv_tatcaSP_SLH_Click(object sender, EventArgs e)
        {
            //Nếu không có dữ liệu
            if (tbl_tatcaSP.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục 
            txtBox_masp_SLH.Text = dgv_tatcaSP_SLH.CurrentRow.Cells["MASP"].Value.ToString();
            txtBox_tensp_SLH.Text = dgv_tatcaSP_SLH.CurrentRow.Cells["TENSP"].Value.ToString();
            txtBox_slton_SLH.Text = dgv_tatcaSP_SLH.CurrentRow.Cells["SOLUONGTON"].Value.ToString();
            txtBox_gianhap_SLH.Text = dgv_tatcaSP_SLH.CurrentRow.Cells["GIANHAP"].Value.ToString();
            txtBox_giaban_SLH.Text = dgv_tatcaSP_SLH.CurrentRow.Cells["GIAGOC"].Value.ToString();
            txtBox_khuyenmai_SLH.Text = dgv_tatcaSP_SLH.CurrentRow.Cells["KHUYENMAI"].Value.ToString();
            txtBox_giamgia_SLH.Text = dgv_tatcaSP_SLH.CurrentRow.Cells["GIAGIAM"].Value.ToString();

            // load anh 
            try
            {
                picBox_anh_SLH.Load(dgv_tatcaSP_SLH.CurrentRow.Cells["HINHANH"].Value.ToString());
            }
            catch (Exception loi)
            {
                MessageBox.Show("Load ảnh thất bại, mã lỗi: " + loi.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
      
        private void btn_timkiem_SLH_Click(object sender, EventArgs e)
        {
            if (txtBox_timkiem_SLH.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập từ khóa vào ô tìm kiếm !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string tukhoa = txtBox_timkiem_SLH.Text.Trim();
            string sql = "Sp_KH_TimKiemSP '" + tukhoa + "'";
            tbl_tatcaSP2 = Functions.GetDataToTable(sql);
            dgv_tatcaSP_SLH.DataSource = tbl_tatcaSP2;
        }

        private void btn_huytimkiem_SLH_Click(object sender, EventArgs e)
        {
            txtBox_timkiem_SLH.Text = "";
            dgv_tatcaSP_SLH.DataSource = tbl_tatcaSP;
        }
    }
}