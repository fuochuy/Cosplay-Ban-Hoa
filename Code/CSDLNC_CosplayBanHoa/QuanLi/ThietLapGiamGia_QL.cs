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
    public partial class ThietLapGiamGia_QL : Form
    {
        DataTable tbl_QL_TLGG;
        public ThietLapGiamGia_QL()
        {
            InitializeComponent();
        }
        private void LoadData_SanPham() // tải dữ liệu vào DataGridView
        {
            string sql = "SP_QL_TatCaSP";
            tbl_QL_TLGG = Functions.GetDataToTable(sql);
            dGV_QL_TLGG.DataSource = tbl_QL_TLGG;

            // set Font cho tên cột
            dGV_QL_TLGG.Font = new Font("Time New Roman", 13);
            dGV_QL_TLGG.Columns[0].HeaderText = "Mã sản phẩm";
            dGV_QL_TLGG.Columns[1].HeaderText = "Tên sản phẩm";
            dGV_QL_TLGG.Columns[2].HeaderText = "Giá Gốc";
            dGV_QL_TLGG.Columns[3].HeaderText = "Khuyến mãi";
            dGV_QL_TLGG.Columns[4].HeaderText = "Giá giảm";
            dGV_QL_TLGG.Columns[5].HeaderText = "Hình ảnh";

            // set Font cho dữ liệu hiển thị trong cột
            dGV_QL_TLGG.DefaultCellStyle.Font = new Font("Time New Roman", 12);

            // set kích thước cột
            dGV_QL_TLGG.Columns[0].Width = 160;
            dGV_QL_TLGG.Columns[1].Width = 160;
            dGV_QL_TLGG.Columns[2].Width = 160;
            dGV_QL_TLGG.Columns[3].Width = 160;
            dGV_QL_TLGG.Columns[4].Width = 160;
            dGV_QL_TLGG.Columns[5].Width = 160;


            //Không cho người dùng thêm dữ liệu trực tiếp
            dGV_QL_TLGG.AllowUserToAddRows = false;

            dGV_QL_TLGG.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void  TimSanPham() // tải dữ liệu vào DataGridView
        {
            string sql = "SP_QL_TimSPByName " + "'" + textBox_QL_TimSP.Text.Trim().ToString() + "'";
            tbl_QL_TLGG = Functions.GetDataToTable(sql);
            dGV_QL_TLGG.DataSource = tbl_QL_TLGG;

            // set Font cho tên cột
            dGV_QL_TLGG.Font = new Font("Time New Roman", 13);
            dGV_QL_TLGG.Columns[0].HeaderText = "Mã sản phẩm";
            dGV_QL_TLGG.Columns[1].HeaderText = "Tên sản phẩm";
            dGV_QL_TLGG.Columns[2].HeaderText = "Giá Gốc";
            dGV_QL_TLGG.Columns[3].HeaderText = "Khuyến mãi";
            dGV_QL_TLGG.Columns[4].HeaderText = "Giá giảm";
            dGV_QL_TLGG.Columns[5].HeaderText = "Hình ảnh";

            // set Font cho dữ liệu hiển thị trong cột
            dGV_QL_TLGG.DefaultCellStyle.Font = new Font("Time New Roman", 12);

            // set kích thước cột
            dGV_QL_TLGG.Columns[0].Width = 160;
            dGV_QL_TLGG.Columns[1].Width = 160;
            dGV_QL_TLGG.Columns[2].Width = 160;
            dGV_QL_TLGG.Columns[3].Width = 160;
            dGV_QL_TLGG.Columns[4].Width = 160;
            dGV_QL_TLGG.Columns[5].Width = 160;


            //Không cho người dùng thêm dữ liệu trực tiếp
            dGV_QL_TLGG.AllowUserToAddRows = false;

            dGV_QL_TLGG.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ThietLapGiamGia_QL_Load(object sender, EventArgs e)
        {
            LoadData_SanPham();
        }

        private void dGV_QL_TLGG_Click(object sender, EventArgs e)
        {
            if (dGV_QL_TLGG.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            // set giá trị cho các mục 
            textBox_QL_MASP.Text = dGV_QL_TLGG.CurrentRow.Cells["MASP"].Value.ToString();
            textBox_QL_TENSP.Text = dGV_QL_TLGG.CurrentRow.Cells["TENSP"].Value.ToString();
            textBox_QL_KM.Text = dGV_QL_TLGG.CurrentRow.Cells["KHUYENMAI"].Value.ToString();
            textBox_QL_GiaGoc.Text = dGV_QL_TLGG.CurrentRow.Cells["GIAGOC"].Value.ToString();
            textBox_QL_GIAGIAM.Text = dGV_QL_TLGG.CurrentRow.Cells["GIAGIAM"].Value.ToString();
          
            try
            {
                picBox_anh_DT.Load(dGV_QL_TLGG.CurrentRow.Cells["HINHANH"].Value.ToString());
            }
            catch (Exception loi)
            {
                MessageBox.Show("Load ảnh thất bại, mã lỗi: " + loi.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimSanPham();
        }

      

        private void btn_QL_UpdateGia_click(object sender, EventArgs e)
        {
            string sql = "SP_QL_UpdateGiaGiam "+"'"+ textBox_QL_MASP.Text.Trim().ToString()+"',"+textBox_QL_GIAGIAM.Text.Trim().ToString();
            Functions.RunSQL(sql);
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData_SanPham();
        }
    }
}
