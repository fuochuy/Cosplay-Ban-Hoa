using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace CSDLNC_CosplayBanHoa
{
    public partial class DangKi : Form
    {
        Thread t;
        string tendn;
        string matkhau;
        string LOAITK;

        public DangKi()
        {
            InitializeComponent();
        }

        public void open_FormTTKH(object obj)
        {
            Application.Run(new TT_KH_DK(tendn, matkhau, LOAITK));
        }

        private int Run_SP_KTTenDangNhap()
        {
            SqlCommand cmd = new SqlCommand("SP_KTTenDangNhap", Functions.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@TENDN", SqlDbType.VarChar, 50);

            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị
            cmd.Parameters["@TENDN"].Value = tendn;

            cmd.ExecuteNonQuery();

            return Int32.Parse(returnParameter.Value.ToString());
        }
       
        private void btn_dangki_Click(object sender, EventArgs e)
        {
            //TH chưa nhập đủ dữ liệu
            if (txtBox_tendn_DK.Text.Trim().Length == 0 |
                txtBox_matkhau_DK.Text.Trim().Length == 0 |
                txtBox_xacnhanmatkhau_DK.Text.Trim().Length == 0 |
                (cB_KH.Checked == false && cB_TX.Checked == false )
                )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);             
                return;
            }

                
            tendn = txtBox_tendn_DK.Text.Trim();
            matkhau = txtBox_matkhau_DK.Text.Trim();
         
            // Kiểm tra tên đăng nhập           
            if (Run_SP_KTTenDangNhap() == 1)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBox_tendn_DK.Focus();
                return;
            }

            // kiểm tra mật khẩu
            if (!txtBox_matkhau_DK.Text.Trim().Equals(txtBox_xacnhanmatkhau_DK.Text.Trim()))
            {
                MessageBox.Show("Xác nhận mật khẩu không đúng !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);            
                return;
            }
        
            // mở form nhập thông tin cá nhân
            this.Close();
            t = new Thread(open_FormTTKH);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        public void open_FormDangNhap(object obj)
        {
            Application.Run(new DangNhap());
        }

        private void btn_quaylai_Click(object sender, EventArgs e)
        {
            this.Close();
            t = new Thread(open_FormDangNhap);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void cB_KH_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_KH.Checked == true)
            {
                cB_TX.Checked = false;
                LOAITK = "1";
            }
        }

        private void cB_TX_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_TX.Checked == true)
            {
                cB_KH.Checked = false;
                LOAITK = "3";
            }
        }

        private void btn_show_mk_Click(object sender, EventArgs e)
        {
            if (btn_show_mk.Text.Equals("Show"))
            {
                txtBox_matkhau_DK.PasswordChar = '\0';
                btn_show_mk.Text = "Hide";
            }
            else
            {
                txtBox_matkhau_DK.PasswordChar = '*';
                btn_show_mk.Text = "Show";
            }
        }

        private void btn_show_xnmk_Click(object sender, EventArgs e)
        {       
            if (btn_show_xnmk.Text.Equals("Show"))
            {
                txtBox_xacnhanmatkhau_DK.PasswordChar = '\0';
                btn_show_xnmk.Text = "Hide";
            }
            else
            {
                txtBox_xacnhanmatkhau_DK.PasswordChar = '*';
                btn_show_xnmk.Text = "Show";
            }
        }
    }
}
