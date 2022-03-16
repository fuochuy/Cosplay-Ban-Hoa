using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CSDLNC_CosplayBanHoa
{
    public partial class ThongTinTT_NV : Form
    {
        string MANV;
        string TENSP, GIAMOI, SLTON, MASP;
        string GIAGIAM;
        DataTable tbl_KH;
        string madh, makh;
        string ID;

        public ThongTinTT_NV(string masp,
            string tensp,
            string giamoi,
            string slton,
            string manv
            )
        {
            InitializeComponent();
            TENSP = tensp;
            MASP = masp;
            GIAMOI = giamoi;
            SLTON = slton;
            MANV = manv;
        }

        private void reset_value()
        {
            txtBox_ktsdt.Text = "";
            txtBox_tenkh.Text = "";
            txtBox_sdt.Text = "";
            txtBox_email.Text = "";
            txtBox_diachi.Text = "";
        }

        private void ThongTinTT_NV_Load(object sender, EventArgs e)
        {
            txtbox_tensp.Text = TENSP;
            txtbox_dongia.Text = GIAMOI;
            txtbox_slton.Text = SLTON;

            string sql = "SELECT GIAGIAM " +
                "FROM GIAMGIA " +
                "WHERE MASP = '" + MASP + "'";
            GIAGIAM = Functions.GetFieldValues(sql);
            txtBox_giagiam.Text = GIAGIAM;

            Auto_Tong_Tien();
        }

        private void Auto_Tong_Tien()
        {
            float tongcong = (float.Parse(GIAMOI) * Int32.Parse(txtBox_slmua.Text.Trim().ToString())) - float.Parse(GIAGIAM);
            if (tongcong > 0)
                txtBox_tongcong.Text = tongcong.ToString("0.0000");
            else
                txtBox_tongcong.Text = "";
        }

        private void btn_giamsl_DH_KH_Click(object sender, EventArgs e)
        {
            int slmua = Int32.Parse(txtBox_slmua.Text.Trim().ToString());
            slmua -= 1;
            if (slmua < 1) slmua = 1;
            txtBox_slmua.Text = slmua.ToString();
            Auto_Tong_Tien();
        }

        private void btn_tangsl_DH_KH_Click(object sender, EventArgs e)
        {
            int slmua = Int32.Parse(txtBox_slmua.Text.Trim().ToString());
            slmua += 1;
            if (slmua >= Int32.Parse(SLTON)) slmua = Int32.Parse(SLTON);
            txtBox_slmua.Text = slmua.ToString();
            Auto_Tong_Tien();
        }

        private void btn_timtk_Click(object sender, EventArgs e)
        {
            if (cBox_KH_cotk.Checked && txtBox_ktsdt.Text.Trim().Length > 0)
            {
                string sql = "SELECT KH.TENKH, TK.SDT, TK.EMAIL, TK.DIACHI, KH.MAKH " +
                    "FROM KHACHHANG KH, TAIKHOAN TK " +
                    "WHERE TK.SDT = '" + txtBox_ktsdt.Text.Trim() + "' " +
                    "AND TK.ID = KH.ID";
                tbl_KH = Functions.GetDataToTable(sql);

                if (tbl_KH.Rows.Count == 0)
                {
                    MessageBox.Show("Số điện thoại không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                txtBox_tenkh.Text = tbl_KH.Rows[0].Field<String>(0).ToString();
                txtBox_sdt.Text = tbl_KH.Rows[0].Field<String>(1).ToString();
                txtBox_diachi.Text = tbl_KH.Rows[0].Field<String>(3).ToString();
                txtBox_email.Text = tbl_KH.Rows[0].Field<String>(2).ToString();
                makh = tbl_KH.Rows[0].Field<String>(4).ToString();
            }
        }


        private void dTP_ngaygiao_Enter(object sender, EventArgs e)
        {
            dTP_ngaygiao.CustomFormat = "yyyy-MM-dd";
        }

        private void cBox_KH_cotk_CheckedChanged(object sender, EventArgs e)
        {
            reset_value();
            if (cBox_KH_cotk.Checked)
            {
                txtBox_ktsdt.Enabled = true;
                txtBox_tenkh.Enabled = false;
                txtBox_sdt.Enabled = false;
                txtBox_email.Enabled = false;
                txtBox_diachi.Enabled = false;
            }
            else
            {
                txtBox_ktsdt.Enabled = false;
                txtBox_tenkh.Enabled = true;
                txtBox_sdt.Enabled = true;
                txtBox_email.Enabled = true;
                txtBox_diachi.Enabled = true;
            }
        }

        private void cBox_nguoinhan_CheckedChanged(object sender, EventArgs e)
        {
            if (cBox_nguoinhan.Checked == true)
            {
                txtBox_tennguoinhan.Text = txtBox_tenkh.Text;
                txtBox_sdtnguoinhan.Text = txtBox_sdt.Text;
                txtBox_diachinguoinhan.Text = txtBox_diachi.Text;
                dTP_ngaymua.Text = DateTime.Today.ToString();
            }
        }

        private void txtBox_diachinguoinhan_TextChanged(object sender, EventArgs e)
        {
            txtBox_phigiaohang.Text = "300000.0000";
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
            cmd.Parameters["@MANV"].Value = MANV;
            cmd.Parameters["@TENNGUOINHAN"].Value = txtBox_tennguoinhan.Text;
            cmd.Parameters["@DIACHI_NGUOINHAN"].Value = txtBox_diachinguoinhan.Text;
            cmd.Parameters["@SDT_NGUOINHAN"].Value = txtBox_sdtnguoinhan.Text;
            cmd.Parameters["@PHIVANCHUYEN"].Value = float.Parse(txtBox_phigiaohang.Text);
            cmd.Parameters["@HINHTHUCTHANHTOAN"].Value = cbBox_HTTT.SelectedIndex;
            cmd.Parameters["@NGAYMUONGIAO"].Value = dTP_ngaymua.Text;
            cmd.Parameters["@NGAYLAP"].Value = dTP_ngaygiao.Text;
            cmd.Parameters["@TINHTRANG"].Value = 0;
            cmd.Parameters["@TONGTIEN"].Value = float.Parse(txtBox_tongcong.Text) + (float.Parse(txtBox_phigiaohang.Text));

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
            cmd.Parameters["@MASP"].Value = MASP;
            cmd.Parameters["@SOLUONG"].Value = txtBox_slmua.Text;
            cmd.Parameters["@THANHTIEN"].Value = float.Parse(txtBox_tongcong.Text);

            cmd.ExecuteNonQuery();

            return Int32.Parse(returnParameter.Value.ToString());
        }

        private int Run_SP_TaoTK_KH()
        {
            SqlCommand cmd = new SqlCommand("Sp_TaoTK_KH", Functions.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@ID", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@TENDN", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@MATKHAU", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@LOAITK", SqlDbType.Int);
            cmd.Parameters.Add("@SDT", SqlDbType.Char, 15);
            cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 255);
            cmd.Parameters.Add("@DIACHI", SqlDbType.VarChar, 255);
            cmd.Parameters.Add("@MAKH", SqlDbType.VarChar, 15);
            cmd.Parameters.Add("@TENKH", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@STK", SqlDbType.VarChar, 30);

            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị
            cmd.Parameters["@ID"].Value = ID ;
            cmd.Parameters["@TENDN"].Value = txtBox_email.Text;
            cmd.Parameters["@MATKHAU"].Value = txtBox_email.Text;
            cmd.Parameters["@LOAITK"].Value = 1;
            cmd.Parameters["@SDT"].Value = txtBox_sdt.Text;
            cmd.Parameters["@EMAIL"].Value = txtBox_email.Text;
            cmd.Parameters["@DIACHI"].Value = txtBox_diachi.Text;
            cmd.Parameters["@MAKH"].Value = makh;
            cmd.Parameters["@TENKH"].Value = txtBox_tenkh.Text;

            cmd.ExecuteNonQuery();

            return Int32.Parse(returnParameter.Value.ToString());

        }

        private void btn_themdh_Click(object sender, EventArgs e)
        {
            string sql = "SELECT COUNT(*) FROM DONHANG";
            int rows_number = Int32.Parse(Functions.GetFieldValues(sql));
            rows_number++;
            madh = "DH" + rows_number.ToString();       


            if (!cBox_KH_cotk.Checked)
            {
                try
                {
                    sql = "SELECT COUNT(*) FROM KHACHHANG";
                    rows_number = Int32.Parse(Functions.GetFieldValues(sql));
                    rows_number++;
                    makh = "KH" + rows_number.ToString();

                    sql = "SELECT COUNT(*) FROM TAIKHOAN";
                    rows_number = Int32.Parse(Functions.GetFieldValues(sql));
                    rows_number++;
                    ID = "ID" + rows_number.ToString();

                    int status = Run_SP_TaoTK_KH();
                }
                catch (Exception loi)
                {
                    MessageBox.Show("Thêm tài khoản KH thất bại mã lỗi: " + loi.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            try
            {
                int status1 = Run_SP_Sp_KH_ThemDH();
                int status2 = Run_SP_Sp_KH_ThemCTDH();

                if (status1 == 1 && status2 == 1)
                {
                    MessageBox.Show("Thêm đơn hàng thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception loi)
            {
                MessageBox.Show("Thêm đơn hàng thất bại mã lỗi: " + loi.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }
    }
}
