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
    public partial class LichSuXuat : Form
    {
        DataTable tbl_QT_LSX;
        public LichSuXuat()
        {
            InitializeComponent();
        }
        private void LoadData_TatCaLSX() // tải dữ liệu vào DataGridView
        {
            string sql = "SP_QT_TatCaLSX";
            tbl_QT_LSX = Functions.GetDataToTable(sql);
            dGV_QT_LSX.DataSource = tbl_QT_LSX;

            // set Font cho tên cột
            dGV_QT_LSX.Font = new Font("Time New Roman", 13);
            dGV_QT_LSX.Columns[0].HeaderText = "Mã sản phẩm";
            dGV_QT_LSX.Columns[1].HeaderText = "Ngày xuất";
            dGV_QT_LSX.Columns[2].HeaderText = "Số lượng";

            // set Font cho dữ liệu hiển thị trong cột
            dGV_QT_LSX.DefaultCellStyle.Font = new Font("Time New Roman", 12);

            // set kích thước cột
            dGV_QT_LSX.Columns[0].Width = 320;
            dGV_QT_LSX.Columns[1].Width = 320;
            dGV_QT_LSX.Columns[2].Width = 320;

            //Không cho người dùng thêm dữ liệu trực tiếp
            dGV_QT_LSX.AllowUserToAddRows = false;

            dGV_QT_LSX.EditMode = DataGridViewEditMode.EditProgrammatically;
        }


        private void LoadData_TimLSXByMaSP() // tải dữ liệu vào DataGridView
        {
            string sql = "SP_QT_TimLSXTheoMaSP" + "'" + textBox_QT_LSX_MaSP.Text.Trim().ToString() + "'";
            tbl_QT_LSX = Functions.GetDataToTable(sql);
            dGV_QT_LSX.DataSource = tbl_QT_LSX;

            //// set Font cho tên cột
            //dGV_QT_LSX.Font = new Font("Time New Roman", 13);
            //dGV_QT_LSX.Columns[0].HeaderText = "Mã sản phẩm";
            //dGV_QT_LSX.Columns[1].HeaderText = "Ngày xuất";
            //dGV_QT_LSX.Columns[2].HeaderText = "Số lượng";

            //// set Font cho dữ liệu hiển thị trong cột
            //dGV_QT_LSX.DefaultCellStyle.Font = new Font("Time New Roman", 12);

            //// set kích thước cột
            //dGV_QT_LSX.Columns[0].Width = 267;
            //dGV_QT_LSX.Columns[1].Width = 267;
            //dGV_QT_LSX.Columns[2].Width = 267;


            ////Không cho người dùng thêm dữ liệu trực tiếp
            //dGV_QT_LSX.AllowUserToAddRows = false;
            //dGV_QT_LSX.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void LoadData_TimLSXByNgayXuat() // tải dữ liệu vào DataGridView
        {
            string sql = "SP_QT_TimLSXTheoNgayLap" + "'" + dateTimePicker_QT_NgayXuat.Text.Trim().ToString() + "'";
            tbl_QT_LSX = Functions.GetDataToTable(sql);
            dGV_QT_LSX.DataSource = tbl_QT_LSX;

            //// set Font cho tên cột
            //dGV_QT_LSX.Font = new Font("Time New Roman", 13);
            //dGV_QT_LSX.Columns[0].HeaderText = "Mã sản phẩm";
            //dGV_QT_LSX.Columns[1].HeaderText = "Ngày xuất";
            //dGV_QT_LSX.Columns[2].HeaderText = "Số lượng";

            //// set Font cho dữ liệu hiển thị trong cột
            //dGV_QT_LSX.DefaultCellStyle.Font = new Font("Time New Roman", 12);

            //// set kích thước cột
            //dGV_QT_LSX.Columns[0].Width = 267;
            //dGV_QT_LSX.Columns[1].Width = 267;
            //dGV_QT_LSX.Columns[2].Width = 267;


            ////Không cho người dùng thêm dữ liệu trực tiếp
            //dGV_QT_LSX.AllowUserToAddRows = false;
            //dGV_QT_LSX.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LichSuXuat_Load(object sender, EventArgs e)
        {
            LoadData_TatCaLSX();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadData_TimLSXByNgayXuat();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData_TimLSXByMaSP();
        }

        private void dGV_QT_LSX_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbl_QT_LSX.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            // set giá trị cho các mục 
            textBox_QT_LSX_MaSP.Text = dGV_QT_LSX.CurrentRow.Cells["MASP"].Value.ToString();
            dateTimePicker_QT_NgayXuat.Text = dGV_QT_LSX.CurrentRow.Cells["NGAYLAP"].Value.ToString();
            textBox_QT_LSN_SOLUONG.Text = dGV_QT_LSX.CurrentRow.Cells["SOLUONG"].Value.ToString();
        }

    }
}
