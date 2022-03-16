using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CSDLNC_CosplayBanHoa
{
    public partial class ThanhToan_KH : Form
    {
        int tab = 1;
        string madh;
        string makh;
        string tennguoinhan;
        string diachi_nguoinhan;
        string sdt_nguoinhan;
        string phivanchuyen;
        string hinhthucthanhtoan;
        string ngaymuongiao;
        string ngaylap;
        string tinhtrang;
        string tongcong;
        string masp, slmua, thanhtien;

        public ThanhToan_KH(
            string MAKH,
            string TENNGUOINHAN,
            string DIACHI_NGUOINHAN,
            string SDT_NGUOINHAN,
            string PHIVANCHUYEN,
            string NGAYMUONGIAO,
            string TONGCONG,
            string MASP,
            string SLMUA,
            string THANHTIEN
            )
        {
            InitializeComponent();
            makh = MAKH;
            tennguoinhan = TENNGUOINHAN;
            diachi_nguoinhan = DIACHI_NGUOINHAN;
            sdt_nguoinhan = SDT_NGUOINHAN;
            phivanchuyen = PHIVANCHUYEN;
            tongcong = TONGCONG;
            ngaymuongiao = NGAYMUONGIAO;
            masp = MASP;
            slmua = SLMUA;
            thanhtien = THANHTIEN;

            DateTime today = DateTime.Today;
            ngaylap = today.ToString();
            tinhtrang = "0";
        }

        private int Run_SP_Sp_KH_ThemDH()
        {
            SqlCommand cmd = new SqlCommand("Sp_ThemDH", Functions.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@MADH", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@MAKH", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@MANV", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@TENNGUOINHAN", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@DIACHI_NGUOINHAN", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@SDT_NGUOINHAN", SqlDbType.NVarChar, 255);
            cmd.Parameters.Add("@PHIVANCHUYEN", SqlDbType.Decimal, 19);
            cmd.Parameters.Add("@HINHTHUCTHANHTOAN", SqlDbType.Int);
            cmd.Parameters.Add("@NGAYMUONGIAO", SqlDbType.Date);
            cmd.Parameters.Add("@NGAYLAP", SqlDbType.Date);
            cmd.Parameters.Add("@TINHTRANG", SqlDbType.Int);
            cmd.Parameters.Add("@TONGTIEN", SqlDbType.Decimal, 19);

            cmd.Parameters["@PHIVANCHUYEN"].Precision = 19;
            cmd.Parameters["@PHIVANCHUYEN"].Scale = 4;
            cmd.Parameters["@TONGTIEN"].Precision = 19;
            cmd.Parameters["@TONGTIEN"].Scale = 4;

            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;


            // set giá trị
            cmd.Parameters["@MADH"].Value = madh;
            cmd.Parameters["@MAKH"].Value = makh;
            cmd.Parameters["@TENNGUOINHAN"].Value = tennguoinhan;
            cmd.Parameters["@DIACHI_NGUOINHAN"].Value = diachi_nguoinhan;
            cmd.Parameters["@SDT_NGUOINHAN"].Value = sdt_nguoinhan;
            cmd.Parameters["@PHIVANCHUYEN"].Value = float.Parse(phivanchuyen);
            cmd.Parameters["@HINHTHUCTHANHTOAN"].Value = hinhthucthanhtoan;
            cmd.Parameters["@NGAYMUONGIAO"].Value = ngaymuongiao;
            cmd.Parameters["@NGAYLAP"].Value = ngaylap;
            cmd.Parameters["@TINHTRANG"].Value = tinhtrang;
            cmd.Parameters["@TONGTIEN"].Value = float.Parse(tongcong) + (float.Parse(phivanchuyen));

            cmd.ExecuteNonQuery();

            return Int32.Parse(returnParameter.Value.ToString());
        }

        private int Run_SP_Sp_KH_ThemCTDH()
        {
            SqlCommand cmd = new SqlCommand("Sp_ThemCTDH", Functions.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@MADH", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@MASP", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@SOLUONG", SqlDbType.Int);
            cmd.Parameters.Add("@THANHTIEN", SqlDbType.Decimal);

            cmd.Parameters["@THANHTIEN"].Precision = 19;
            cmd.Parameters["@THANHTIEN"].Scale = 4;

            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị
            cmd.Parameters["@MADH"].Value = madh;
            cmd.Parameters["@MASP"].Value = masp;
            cmd.Parameters["@SOLUONG"].Value = slmua;
            cmd.Parameters["@THANHTIEN"].Value = thanhtien;

            cmd.ExecuteNonQuery();

            return Int32.Parse(returnParameter.Value.ToString());
        }


        private void btn_thanhtoan_TT_KH_Click(object sender, EventArgs e)
        {
            if (tab == 1)
            {
                if (cBox_choice1.Checked == false &&
                    cBox_choice2.Checked == false &&
                    cBox_choice3.Checked == false)
                {
                    MessageBox.Show("Vui lòng chon hình thức thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (tab == 2)
            {
                if (txtBox_sdt_TTNN_KH.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                hinhthucthanhtoan = "2";
            }

            string sql = "SELECT COUNT(*) FROM DONHANG";
            int rows_number = Int32.Parse(Functions.GetFieldValues(sql));
            rows_number++;
            madh = "DH" + rows_number.ToString();

            try
            {

                int status1 = Run_SP_Sp_KH_ThemDH();

                int status2 = Run_SP_Sp_KH_ThemCTDH();

                if (status1 == 1 && status2 == 1)
                {
                    MessageBox.Show("Thanh toán thành công, đơn hàng của bạn đang được xử lí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm đơn hàng thất bại, mã lỗi: " + ex.Message);
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage_tienmat_TT_KH)
            {
                txtBox_sdt_TTNN_KH.Text = "";
                tab = 1;
            }
            else
            {
                cBox_choice1.Checked = false;
                cBox_choice2.Checked = false;
                cBox_choice3.Checked = false;
                tab = 2;
            }
        }

        private void cBox_choice1_CheckedChanged(object sender, EventArgs e)
        {
            if (cBox_choice1.Checked == true)
            {
                cBox_choice2.Checked = false;
                cBox_choice3.Checked = false;
                hinhthucthanhtoan = "0";
            }
        }

        private void cBox_choice2_CheckedChanged(object sender, EventArgs e)
        {
            if (cBox_choice2.Checked == true)
            {
                cBox_choice1.Checked = false;
                cBox_choice3.Checked = false;
                hinhthucthanhtoan = "1";
            }
        }

        private void cBox_choice3_CheckedChanged(object sender, EventArgs e)
        {
            if (cBox_choice3.Checked == true)
            {
                cBox_choice2.Checked = false;
                cBox_choice1.Checked = false;
                hinhthucthanhtoan = "3";
            }
        }
    }
}
