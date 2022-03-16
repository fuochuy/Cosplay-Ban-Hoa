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
    public partial class DangNhap : Form
    {      
        string id;
        int loaitk = -2;
        string tendn;
        string matkhau;

        Thread t;
        public DangNhap()
        {
            InitializeComponent();
        }

        private void resetvalue_DN()
        {
            txtBox_tendangnhap.Text = "";
            txtBox_matkhau.Text = "";
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            //Mở kết nối
            //Functions.Connect(user_type);
            Functions.Connect(Functions.get_ConnectString(loaitk));

            resetvalue_DN();
        }

        private void Run_SP_DangNhap()
        {
            SqlCommand cmd = new SqlCommand("Sp_DangNhap", Functions.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@TENDN", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@MATKHAU", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@ID", SqlDbType.VarChar, 15).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@LOAITK", SqlDbType.Int).Direction = ParameterDirection.Output;

            // set giá trị
            cmd.Parameters["@TENDN"].Value = tendn;
            cmd.Parameters["@MATKHAU"].Value = matkhau;

            cmd.ExecuteNonQuery();

            id = Convert.ToString(cmd.Parameters["@ID"].Value);
            loaitk = Convert.ToInt32(cmd.Parameters["@LOAITK"].Value);
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

        private int Run_SP_KTMatKhau()
        {
            SqlCommand cmd = new SqlCommand("SP_KTMatKhau", Functions.Con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // set kiểu dữ liệu
            cmd.Parameters.Add("@TENDN", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@MATKHAU", SqlDbType.VarChar, 50);

            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;

            // set giá trị
            cmd.Parameters["@TENDN"].Value = tendn;
            cmd.Parameters["@MATKHAU"].Value = matkhau;

            cmd.ExecuteNonQuery();

            return Int32.Parse(returnParameter.Value.ToString());
        }

        // xử lí mở form tương ứng từng loại acc      
        public void open_FormMain(object obj)
        {
            switch (loaitk)
            {
                case 0:
                    {
                        Application.Run(new FormMain_QT());
                        break;
                    }
                case 1:
                    {
                        Application.Run(new FormMain_KH(id));
                        break;
                    }
                case 2:
                    {
                        Application.Run(new FormMain_NV(id));
                        break;
                    }
                case 3:
                    {
                        Application.Run(new FormMain_NS());
                        break;
                    }
                case 4:
                    {
                        Application.Run(new FormMain_QL());
                        break;
                    }
                
            }
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            tendn = txtBox_tendangnhap.Text.Trim().ToString();
            matkhau = txtBox_matkhau.Text.Trim().ToString();

            // nếu chưa có dữ liệu 
            if (tendn.Length == 0 | matkhau.Length == 0)

            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Kiểm tra tên đăng nhập           
            if (Run_SP_KTTenDangNhap() == 0)
            {
                MessageBox.Show("Tên đăng nhập không tồn tại !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBox_tendangnhap.Focus();
                return;
            }

            // Kiểm tra mật khẩu ứng với tên đăng nhập
            if (Run_SP_KTMatKhau() == 0)
            {
                MessageBox.Show("Mật khẩu không chính xác !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);           
                txtBox_matkhau.Text = "";
                txtBox_matkhau.Focus();
                return;
            }

            // chạy SP đăng nhập, lấy MAACC, LOAIACC
            Run_SP_DangNhap();
            
            // nếu acc này bị khóa
            if (loaitk == -1)
            {
                MessageBox.Show("Tài khoản này đã bị khóa !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ngắt kết nối vô danh
            Functions.Disconnect();

            // kết nối với database tương ứng với loại acc

            Functions.Connect(Functions.get_ConnectString(loaitk));

            // mở giao diện tương ứng từng loại acc                 
            this.Close();
            t = new Thread(open_FormMain);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        public void open_FormDangKi(object obj)
        {
            Application.Run(new DangKi());
        }


        private void btn_dangki_Click(object sender, EventArgs e)
        {
            this.Close();
            t = new Thread(open_FormDangKi);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void txtBox_tendangnhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtBox_matkhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
