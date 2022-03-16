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
        DataTable tbl_QuanLi_MHBC;
        DataTable tbl_QuanLi_MHBC2;
        DataTable tbl_QuanLi_BanCham;
        DataTable tbl_QuanLi_BanCham2;
        DataTable tbl_QuanLi_DoanhThu;
        DataTable tbl_QuanLi_DoanhThu2;
        DataTable tblDThu;
        int thang, nam;
        string currYear_DT;
        string currMonth_DT;
        Form_Loading form_loading = new Form_Loading();

        public ThongKe_QL()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            // lấy MASP, TENSP, SLTON vào bảng tbl_QuanLi_MHBC
            thang = Int32.Parse(cbB_Thang.Text.Trim().ToString());
            nam = Int32.Parse(cbB_Nam.Text.Trim().ToString());

            string sql = "SP_QL_DSBC " + thang + ", " + nam;
            tbl_QuanLi_MHBC = Functions.GetDataToTable(sql);

            // lấy so luong da ban   
            sql = "SP_QL_DSBC_NUM " + thang + ", " + nam;
            tbl_QuanLi_MHBC2 = Functions.GetDataToTable(sql);

            // thêm so luong da ban vào bảng 
            int i = 0;
            tbl_QuanLi_MHBC.Columns.Add("SLDB", typeof(System.Int32));
            foreach (DataRow row in tbl_QuanLi_MHBC.Rows)
            {
                row["SLDB"] = tbl_QuanLi_MHBC2.Rows[i].Field<Int32>(0);
                i++;
            }

            // lấy lợi nhuận
            sql = "SP_QL_DOANHTHU_BANCHAY " + thang + ", " + nam;
            tbl_QuanLi_MHBC2 = Functions.GetDataToTable(sql);

            // thêm lợi nhuận vào bảng
            i = 0;
            tbl_QuanLi_MHBC.Columns.Add("DOANHTHU", typeof(System.Decimal));
            foreach (DataRow row in tbl_QuanLi_MHBC.Rows)
            {
                row["DOANHTHU"] = tbl_QuanLi_MHBC2.Rows[i].Field<Decimal>(0);            
                i++;
            }
            dgv_MHBC.DataSource = tbl_QuanLi_MHBC;

            // set Font cho tên cột
            dgv_MHBC.Font = new Font("Time New Roman", 13);
            dgv_MHBC.Columns[0].HeaderText = "Mã sản phẩm";
            dgv_MHBC.Columns[1].HeaderText = "Tên sản phẩm";
            dgv_MHBC.Columns[2].HeaderText = "Số lượng tồn";
            dgv_MHBC.Columns[3].HeaderText = "Số lượng đã bán";
            dgv_MHBC.Columns[4].HeaderText = "Lợi nhuận";

            // set Font cho dữ liệu hiển thị trong cột
            dgv_MHBC.DefaultCellStyle.Font = new Font("Time New Roman", 12);

            // set kích thước cột
            dgv_MHBC.Columns[0].Width = 200;
            dgv_MHBC.Columns[1].Width = 200;
            dgv_MHBC.Columns[2].Width = 200;
            dgv_MHBC.Columns[3].Width = 200;
            dgv_MHBC.Columns[4].Width = 200;

            //Không cho người dùng thêm dữ liệu trực tiếp
            dgv_MHBC.AllowUserToAddRows = false;
            dgv_MHBC.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        
        private void btn_Tim_BanChay_Click(object sender, EventArgs e)
        {
            //Thread t = new Thread(() =>
            //{
            //    form_loading.StartPosition = FormStartPosition.CenterParent;
            //    form_loading.ShowDialog();
            //});

            //// show form loading         
            //t.Start();

            LoadData();

            //form_loading.Close_Form();
        }

        private void dgv_MHBC_Click(object sender, EventArgs e)
        {
            if (tbl_QuanLi_MHBC.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục            
            txtBox_MaSP_MHBC.Text = dgv_MHBC.CurrentRow.Cells["MASP"].Value.ToString();
            txtBox_TenSP_MHBC.Text = dgv_MHBC.CurrentRow.Cells["TENSP"].Value.ToString();
            txtBox_SLT_MHBC.Text = dgv_MHBC.CurrentRow.Cells["SOLUONGTON"].Value.ToString();
            txtBox_SLDB_MHBC.Text = dgv_MHBC.CurrentRow.Cells["SLDB"].Value.ToString();
            txtBox_doanhthu_MHBC.Text = dgv_MHBC.CurrentRow.Cells["DOANHTHU"].Value.ToString();
        }

        private void tabPage_mathangbanchay_Enter(object sender, EventArgs e)
        {
            // khi vào tab thì load MHBC của tháng hiện tại lên
            thang = Int32.Parse(DateTime.Now.ToString("MM"));
            nam = Int32.Parse(DateTime.Now.ToString("yyyy"));

            cbB_Thang.Text = thang.ToString();
            cbB_Nam.Text = nam.ToString();
            LoadData();
        }

        private void LoadDataBanCham()
        {
            // lấy MASP, TENSP, SLTON vào bảng tbl_QuanLi_BanCham
            thang = Int32.Parse(cbx_Thang.Text.Trim().ToString());
            nam = Int32.Parse(cbx_Nam.Text.Trim().ToString());

            string sql = "SP_QL_DSBanCham " + thang + ", " + nam;
            tbl_QuanLi_BanCham = Functions.GetDataToTable(sql);

            // lấy so luong da ban   
            sql = "SP_QL_DSBanCham_NUM " + thang + ", " + nam;
            tbl_QuanLi_BanCham2 = Functions.GetDataToTable(sql);

            // thêm so luong da ban vào bảng 
            int i = 0;
            tbl_QuanLi_BanCham.Columns.Add("SLDB", typeof(System.Int32));
            foreach (DataRow row in tbl_QuanLi_BanCham.Rows)
            {
                row["SLDB"] = tbl_QuanLi_BanCham2.Rows[i].Field<Int32>(0);
                i++;
            }

            // lấy lợi nhuận
            sql = "SP_QL_DOANHTHU_BANCHAM " + thang + ", " + nam;
            tbl_QuanLi_BanCham2 = Functions.GetDataToTable(sql);

            // thêm lợi nhuận vào bảng
            i = 0;
            tbl_QuanLi_BanCham.Columns.Add("DOANHTHU", typeof(System.Decimal));
            foreach (DataRow row in tbl_QuanLi_BanCham.Rows)
            {
                row["DOANHTHU"] = tbl_QuanLi_BanCham2.Rows[i].Field<Decimal>(0);
                i++;
            }
            dgv_BanCham.DataSource = tbl_QuanLi_BanCham;

            // set Font cho tên cột
            dgv_BanCham.Font = new Font("Time New Roman", 13);
            dgv_BanCham.Columns[0].HeaderText = "Mã sản phẩm";
            dgv_BanCham.Columns[1].HeaderText = "Tên sản phẩm";
            dgv_BanCham.Columns[2].HeaderText = "Số lượng tồn";
            dgv_BanCham.Columns[3].HeaderText = "Số lượng đã bán";
            dgv_BanCham.Columns[4].HeaderText = "Lợi nhuận";

            // set Font cho dữ liệu hiển thị trong cột
            dgv_BanCham.DefaultCellStyle.Font = new Font("Time New Roman", 12);

            // set kích thước cột
            dgv_BanCham.Columns[0].Width = 200;
            dgv_BanCham.Columns[1].Width = 200;
            dgv_BanCham.Columns[2].Width = 200;
            dgv_BanCham.Columns[3].Width = 200;
            dgv_BanCham.Columns[4].Width = 200;

            //Không cho người dùng thêm dữ liệu trực tiếp
            dgv_BanCham.AllowUserToAddRows = false;
            dgv_BanCham.EditMode = DataGridViewEditMode.EditProgrammatically;

        }

        private void dgv_BanCham_Click(object sender, EventArgs e)
        {
            if (tbl_QuanLi_BanCham.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục            
            txtBox_MaSP_BanCham.Text = dgv_BanCham.CurrentRow.Cells["MASP"].Value.ToString();
            txtBox_TenSP_BanCham.Text = dgv_BanCham.CurrentRow.Cells["TENSP"].Value.ToString();
            txtBox_SLT_BanCham.Text = dgv_BanCham.CurrentRow.Cells["SOLUONGTON"].Value.ToString();
            txtBox_SLDB_BanCham.Text = dgv_BanCham.CurrentRow.Cells["SLDB"].Value.ToString();
            txtBox_LN_BanCham.Text = dgv_BanCham.CurrentRow.Cells["DOANHTHU"].Value.ToString();
        }

        private void btn_Tim_BanCham_Click(object sender, EventArgs e)
        {
            //Thread t = new Thread(() =>
            //{
            //    form_loading.StartPosition = FormStartPosition.CenterParent;
            //    form_loading.ShowDialog();
            //});

            //// show form loading         
            //t.Start();

            LoadDataBanCham();

            //form_loading.Close_Form();         
        }

        private void tabPage_mathangbancham_Enter(object sender, EventArgs e)
        {
            // khi vào tab thì load MHBC của tháng hiện tại lên
            thang = Int32.Parse(DateTime.Now.ToString("MM"));
            nam = Int32.Parse(DateTime.Now.ToString("yyyy"));

            cbx_Thang.Text = thang.ToString();
            cbx_Nam.Text = nam.ToString();
            LoadDataBanCham();
        }

        private void dgv_DThu_Click(object sender, EventArgs e)
        {
            if (tblDThu.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // set giá trị cho các mục    
            cbo_Thang_DT.Text = dgv_DThu.CurrentRow.Cells["THANG"].Value.ToString();       
            txtBox_DT_SLDH.Text = dgv_DThu.CurrentRow.Cells["SLDH"].Value.ToString();
            txtBox_DT_SLDB.Text = dgv_DThu.CurrentRow.Cells["SLDB"].Value.ToString();
            txtBox_DT_DoanhThu.Text = dgv_DThu.CurrentRow.Cells["DOANHTHU"].Value.ToString();
            txtBox_DT_LoiNhuan.Text = dgv_DThu.CurrentRow.Cells["LOINHUAN"].Value.ToString();

        }

        private void LoadData_DThu() // tải dữ liệu cho dataGridView
        {
            getData_DThu_WithYear();

            // set Font cho tên cột
            dgv_DThu.Font = new Font("Time New Roman", 13);
            dgv_DThu.Columns[0].HeaderText = "Tháng";
            dgv_DThu.Columns[1].HeaderText = "SL Đơn hàng";
            dgv_DThu.Columns[2].HeaderText = "SL Hàng Đã Bán";
            dgv_DThu.Columns[3].HeaderText = "Doanh Thu";
            dgv_DThu.Columns[4].HeaderText = "Lợi Nhuận";

            // set Font cho dữ liệu hiển thị trong cột
            dgv_DThu.DefaultCellStyle.Font = new Font("Time New Roman", 12);

            // set kích thước cột
            dgv_DThu.Columns[0].Width = 180;
            dgv_DThu.Columns[1].Width = 180;
            dgv_DThu.Columns[2].Width = 180;
            dgv_DThu.Columns[3].Width = 200;
            dgv_DThu.Columns[4].Width = 200;

            //Không cho người dùng thêm dữ liệu trực tiếp
            dgv_DThu.AllowUserToAddRows = false;
            dgv_DThu.EditMode = DataGridViewEditMode.EditProgrammatically;
          
        }

        private void getData_DThu_WithYear() // lấy dữ liệu đổ vào bảng
        {
            currYear_DT = cbo_Nam_DT.Text.Trim().ToString();

            tblDThu = new DataTable();

            // add các cột   
            tblDThu.Columns.Add("THANG", typeof(string));
            tblDThu.Columns.Add("SLDH", typeof(string));
            tblDThu.Columns.Add("SLDB", typeof(string));
            tblDThu.Columns.Add("DOANHTHU", typeof(string));
            tblDThu.Columns.Add("LOINHUAN", typeof(string));

            for (int i = 1; i <= 12; i++)
            {
                String sql = "";
                String doanhthu = "0";
                String sl_hangdaban = "0";

                // lấy số lượng hoá đơn theo tháng
                //sql = "SELECT COUNT(DH.MADH) " +
                //    "FROM DONHANG DH, CT_DONHANG CTDH " +
                //    "WHERE DH.MADH = CTDH.MADH " +
                //    "AND YEAR(DH.NGAYLAP) = '" + currYear_DT + "' " +
                //    "AND MONTH(DH.NGAYLAP) = '" + i + "'";
                sql = "SP_QL_TONGDHDB " + i + "," + currYear_DT;

                String sl_hoadon = Functions.GetFieldValues(sql);
                if (sl_hoadon.Length == 0)
                    sl_hoadon = "0";

                // lấy doanh thu, số lượng hàng đã bán
                //sql = "SELECT SUM(CAST(DH.TONGTIEN AS BIGINT)) , SUM(CAST(CTDH.SOLUONG AS BIGINT)) " +
                //    "FROM DONHANG DH, CT_DONHANG CTDH " +
                //    "WHERE DH.MADH = CTDH.MADH " +
                //    "AND YEAR(DH.NGAYLAP) = '" + currYear_DT + "' " +
                //    "AND MONTH(DH.NGAYLAP) = '" + i + "'";
                sql = "SP_QL_TONG_SLSP_DB " + i + "," + currYear_DT;
                DataTable tbl = Functions.GetDataToTable(sql);
                if (!sl_hoadon.Equals("0"))
                {
                    doanhthu = tbl.Rows[0].Field<Int64>(0).ToString().Trim();
                    sl_hangdaban = tbl.Rows[0].Field<Int64>(1).ToString().Trim();
                }

                // lấy tổng chi phí bỏ ra 
                //sql = "SELECT SUM(CAST((SP.GIAGOC*CTDH.SOLUONG) AS BIGINT)) " +
                //    "FROM CT_DONHANG CTDH, SANPHAM SP, DONHANG DH " +
                //    "WHERE CTDH.MASP = SP.MASP " +
                //    "AND CTDH.MADH = DH.MADH " +
                //    "AND YEAR(DH.NGAYLAP) = '" + currYear_DT + "' " +
                //    "AND MONTH(DH.NGAYLAP) = '" + i + "'";
                sql = "SP_QL_TONG_CHIPHI " + i + "," + currYear_DT;
                String tongchiphi = Functions.GetFieldValues(sql);
                if (tongchiphi.Length == 0)
                    tongchiphi = "0";

                tblDThu.Rows.Add(new object[] { i.ToString(), sl_hoadon, sl_hangdaban, doanhthu, (Int64.Parse(doanhthu) - Int64.Parse(tongchiphi)).ToString() });
            }
            dgv_DThu.DataSource = tblDThu;
        }

        private void btn_Tim_DT_Click(object sender, EventArgs e)
        {
            //Thread t = new Thread(() =>
            //{
            //    form_loading.StartPosition = FormStartPosition.CenterParent;
            //    form_loading.ShowDialog();
            //});

            //// show form loading         
            //t.Start();

            LoadData_DThu();

           // form_loading.Close_Form();
        }

        private void tabPage_doanhthu_Enter(object sender, EventArgs e)
        {
            //Thread t = new Thread(() =>
            //{
            //    form_loading.StartPosition = FormStartPosition.CenterParent;
            //    form_loading.ShowDialog();
            //});

            //// show form loading         
            //t.Start();

            // set năm hiện tại           
            cbo_Nam_DT.Text = Int32.Parse(DateTime.Now.ToString("yyyy")).ToString();
            LoadData_DThu();

            //form_loading.Close_Form();           
        }
    }
}
