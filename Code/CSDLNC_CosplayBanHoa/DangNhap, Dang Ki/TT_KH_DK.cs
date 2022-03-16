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

namespace CSDLNC_CosplayBanHoa
{
    public partial class TT_KH_DK : Form
    {
        Thread t;
        string makh;
        string ID;
        string TENDN, MATKHAU, LOAITK;

        public TT_KH_DK(string tendn, string matkhau, string loaitk)
        {
            InitializeComponent();
            TENDN = tendn;
            MATKHAU = matkhau;
            LOAITK = loaitk;
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

            //set giá trị
            cmd.Parameters["@ID"].Value = ID;
            cmd.Parameters["@TENDN"].Value = TENDN;
            cmd.Parameters["@MATKHAU"].Value = MATKHAU;
            cmd.Parameters["@LOAITK"].Value = LOAITK;
            cmd.Parameters["@SDT"].Value = txtBox_sdt.Text;
            cmd.Parameters["@EMAIL"].Value = txtBox_email.Text;
            cmd.Parameters["@DIACHI"].Value = txtBox_diachi.Text;
            cmd.Parameters["@MAKH"].Value = makh;
            cmd.Parameters["@TENKH"].Value = txtBox_tenkh.Text;

            cmd.ExecuteNonQuery();

            return Int32.Parse(returnParameter.Value.ToString());

        }

        public void open_FormDangNhap(object obj)
        {
            Application.Run(new DangNhap());
        }
        private void btn_xacnhan_TTKH_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM KHACHHANG";
                int rows_number = Int32.Parse(Functions.GetFieldValues(sql));
                rows_number++;
                makh = "KH" + rows_number.ToString();

                sql = "SELECT COUNT(*) FROM TAIKHOAN";
                rows_number = Int32.Parse(Functions.GetFieldValues(sql));
                rows_number++;
                ID = "ID" + rows_number.ToString();

                int status = Run_SP_TaoTK_KH();
                if (status == 1)
                {
                    MessageBox.Show("Thêm tài khoản thành công !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // sau khi dk xong thì quay lại cho người dùng đăng nhập
                    this.Close();
                    t = new Thread(open_FormDangNhap);
                    t.SetApartmentState(ApartmentState.STA);
                    t.Start();

                    return;
                }                
            }
            catch (Exception loi)
            {
                MessageBox.Show("Thêm tài khoản thất bại mã lỗi: " + loi.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
