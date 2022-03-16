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
    public partial class LichSuNhap_QT : Form
    {
        DataTable tbl_QT_LSN;
        public LichSuNhap_QT()
        {
            InitializeComponent();
        }
        private void LoadData_TatCaLSN() // tải dữ liệu vào DataGridView
        {
            string sql = "SP_QT_TatCaLSN";
            tbl_QT_LSN = Functions.GetDataToTable(sql);
            dGV_QT_LSN.DataSource = tbl_QT_LSN;

            // set Font cho tên cột
            dGV_QT_LSN.Font = new Font("Time New Roman", 13);
            dGV_QT_LSN.Columns[0].HeaderText = "Mã sản phẩm";
            dGV_QT_LSN.Columns[1].HeaderText = "Ngày nhập";
            dGV_QT_LSN.Columns[2].HeaderText = "Người nhập";
            dGV_QT_LSN.Columns[3].HeaderText = "Số lượng";
            dGV_QT_LSN.Columns[4].HeaderText = "Giá nhập";

            // set Font cho dữ liệu hiển thị trong cột
            dGV_QT_LSN.DefaultCellStyle.Font = new Font("Time New Roman", 12);

            // set kích thước cột
            dGV_QT_LSN.Columns[0].Width = 200;
            dGV_QT_LSN.Columns[1].Width = 200;
            dGV_QT_LSN.Columns[2].Width = 200;
            dGV_QT_LSN.Columns[3].Width = 200;
            dGV_QT_LSN.Columns[4].Width = 200;

            //Không cho người dùng thêm dữ liệu trực tiếp
            dGV_QT_LSN.AllowUserToAddRows = false;
            dGV_QT_LSN.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LichSuNhap_QT_Load(object sender, EventArgs e)
        {
            LoadData_TatCaLSN();
        }


        private void dGV_QT_LSN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbl_QT_LSN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            // set giá trị cho các mục 
            textBox_QT_MASP.Text = dGV_QT_LSN.CurrentRow.Cells["MASP"].Value.ToString();
            dateTimePicker_QT_NGAYNHAP.Text = dGV_QT_LSN.CurrentRow.Cells["NGAYNHAP"].Value.ToString();
            textBox_QT_NGUOINHAP.Text = dGV_QT_LSN.CurrentRow.Cells["TENNV"].Value.ToString();
            textBox_QT_SOLUONG.Text = dGV_QT_LSN.CurrentRow.Cells["SOLUONG"].Value.ToString();
            txtbox_LSN_GiaNhap.Text = dGV_QT_LSN.CurrentRow.Cells["GIANHAP"].Value.ToString();

        }

        private void LoadData_LSNByMaSP() // tải dữ liệu vào DataGridView
        {

            string sql = "SP_QT_TimLSNTheoMaSP" + "'" + textBox_QT_MASP.Text.Trim().ToString() + "'";
            tbl_QT_LSN = Functions.GetDataToTable(sql);
            dGV_QT_LSN.DataSource = tbl_QT_LSN;

            // set Font cho tên cột
            dGV_QT_LSN.Font = new Font("Time New Roman", 13);
            dGV_QT_LSN.Columns[0].HeaderText = "Mã sản phẩm";
            dGV_QT_LSN.Columns[1].HeaderText = "Ngày nhập";
            dGV_QT_LSN.Columns[2].HeaderText = "Người nhập";
            dGV_QT_LSN.Columns[3].HeaderText = "Số lượng";
            dGV_QT_LSN.Columns[4].HeaderText = "Giá nhập";

            // set Font cho dữ liệu hiển thị trong cột
            dGV_QT_LSN.DefaultCellStyle.Font = new Font("Time New Roman", 12);

            // set kích thước cột
            dGV_QT_LSN.Columns[0].Width = 200;
            dGV_QT_LSN.Columns[1].Width = 200;
            dGV_QT_LSN.Columns[2].Width = 200;
            dGV_QT_LSN.Columns[3].Width = 200;
            dGV_QT_LSN.Columns[4].Width = 200;

            //Không cho người dùng thêm dữ liệu trực tiếp
            //Không cho người dùng thêm dữ liệu trực tiếp
            dGV_QT_LSN.AllowUserToAddRows = false;
            dGV_QT_LSN.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void LoadData_LSNByNgayNhap() // tải dữ liệu vào DataGridView
        {

            string sql = "SP_QT_TimLSNTheoNgayNhap" + "'" + dateTimePicker_QT_NGAYNHAP.Text.Trim().ToString() + "'";
            tbl_QT_LSN = Functions.GetDataToTable(sql);
            dGV_QT_LSN.DataSource = tbl_QT_LSN;

            // set Font cho tên cột
            dGV_QT_LSN.Font = new Font("Time New Roman", 13);
            dGV_QT_LSN.Columns[0].HeaderText = "Mã sản phẩm";
            dGV_QT_LSN.Columns[1].HeaderText = "Ngày nhập";
            dGV_QT_LSN.Columns[2].HeaderText = "Người nhập";
            dGV_QT_LSN.Columns[3].HeaderText = "Số lượng";
            dGV_QT_LSN.Columns[4].HeaderText = "Giá nhập";
            // set Font cho dữ liệu hiển thị trong cột
            dGV_QT_LSN.DefaultCellStyle.Font = new Font("Time New Roman", 12);

            // set kích thước cột
            dGV_QT_LSN.Columns[0].Width = 200;
            dGV_QT_LSN.Columns[1].Width = 200;
            dGV_QT_LSN.Columns[2].Width = 200;
            dGV_QT_LSN.Columns[3].Width = 200;
            dGV_QT_LSN.Columns[4].Width = 200;

            //Không cho người dùng thêm dữ liệu trực tiếp
            //Không cho người dùng thêm dữ liệu trực tiếp
            dGV_QT_LSN.AllowUserToAddRows = false;
            dGV_QT_LSN.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadData_LSNByMaSP();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadData_LSNByNgayNhap();
        }

       
    }
}
