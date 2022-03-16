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
    public partial class CT_DonHang : Form
    {
        string MADH;
        DataTable tbl_CTDH;
        public CT_DonHang(string madh)
        {
            InitializeComponent();
            MADH = madh;
        }

        private void Load_Data()
        {
            string sql = "Sp_KH_LayThongTinCTDH '" + MADH + "'";
            tbl_CTDH = Functions.GetDataToTable(sql);
            dGV_CTDH_KH.DataSource = tbl_CTDH;

            // set Font cho tên cột
            dGV_CTDH_KH.Font = new Font("Time New Roman", 13);
            dGV_CTDH_KH.Columns[0].HeaderText = "Mã đơn hàng";
            dGV_CTDH_KH.Columns[1].HeaderText = "Mã sản phẩm";
            dGV_CTDH_KH.Columns[2].HeaderText = "Tên sản phẩm";
            dGV_CTDH_KH.Columns[3].HeaderText = "Giá gốc";
            dGV_CTDH_KH.Columns[4].HeaderText = "Khuyến mãi";
            dGV_CTDH_KH.Columns[5].HeaderText = "Giá giảm";
            dGV_CTDH_KH.Columns[6].HeaderText = "Số lượng";
            dGV_CTDH_KH.Columns[7].HeaderText = "Thành tiền";
            dGV_CTDH_KH.Columns[8].HeaderText = "Hình ảnh";

            // set Font cho dữ liệu hiển thị trong cột
            dGV_CTDH_KH.DefaultCellStyle.Font = new Font("Time New Roman", 12);

            // set kích thước cột
            dGV_CTDH_KH.Columns[0].Width = 200;
            dGV_CTDH_KH.Columns[1].Width = 0;
            dGV_CTDH_KH.Columns[2].Width = 200;
            dGV_CTDH_KH.Columns[3].Width = 200;
            dGV_CTDH_KH.Columns[4].Width = 200;
            dGV_CTDH_KH.Columns[5].Width = 200;
            dGV_CTDH_KH.Columns[6].Width = 200;
            dGV_CTDH_KH.Columns[7].Width = 200;
            dGV_CTDH_KH.Columns[8].Width = 200;

            //Không cho người dùng thêm dữ liệu trực tiếp
            dGV_CTDH_KH.AllowUserToAddRows = false;
            dGV_CTDH_KH.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void CT_DonHang_Load(object sender, EventArgs e)
        {
            Load_Data();
        }

        private void dGV_CTDH_KH_Click(object sender, EventArgs e)
        {
            if (tbl_CTDH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
            // set giá trị cho các mục     
            txtBox_madh_CTDH_KH.Text = dGV_CTDH_KH.CurrentRow.Cells["MADH"].Value.ToString();
            txtBox_tensp_CTDH_KH.Text = dGV_CTDH_KH.CurrentRow.Cells["TENSP"].Value.ToString();
            txtBox_dongia_CTDH_KH.Text = dGV_CTDH_KH.CurrentRow.Cells["GIAGOC"].Value.ToString();
            txtBox_soluong_CTDH_KH.Text = dGV_CTDH_KH.CurrentRow.Cells["SOLUONG"].Value.ToString();
            txtBox_giamgia_CTDH_KH.Text = dGV_CTDH_KH.CurrentRow.Cells["GIAGIAM"].Value.ToString();
            txtBox_khuyenmai_CTDH_KH.Text = dGV_CTDH_KH.CurrentRow.Cells["KHUYENMAI"].Value.ToString();
            txtBox_phuphi_CTDH_KH.Text = "-";
            txtBox_thanhtien_CTDH_KH.Text = dGV_CTDH_KH.CurrentRow.Cells["THANHTIEN"].Value.ToString();

            // load anh 
            try
            {
                picBox_anh_CTDH.Load(dGV_CTDH_KH.CurrentRow.Cells["HINHANH"].Value.ToString());
            }
            catch (Exception loi)
            {
                MessageBox.Show("Load ảnh thất bại, mã lỗi: " + loi.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }


    }
}
