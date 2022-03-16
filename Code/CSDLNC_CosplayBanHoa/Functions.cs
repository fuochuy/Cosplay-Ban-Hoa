using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CSDLNC_CosplayBanHoa
{
    class Functions
    {
        // tên server của SQL server
       // private static string exactly_server_name = @"DESKTOP-0QKBNDR";     
      //  private static string exactly_server_name = @"LTBM-PC";
        private static string exactly_server_name = @"(LocalDB)\MSSQLLocalDB";

        //Khai báo đối tượng kết nối  
        public static SqlConnection Con;
        public static void Connect(string ConnectString)
        {
            Con = new SqlConnection();
            Con.ConnectionString = ConnectString;
          //  Con.ConnectionString = "Data Source=DESKTOP-0QKBNDR;Initial Catalog=HYT;Integrated Security=True";
            //Mở kết nối
            Con.Open();

            //Kiểm tra kết nối
            if (Con.State == ConnectionState.Open)
            {
                //MessageBox.Show("Kết nối DB thành công");
            }
            else MessageBox.Show("Không thể kết nối với DB");
        }

        public static void Disconnect()
        {
            if (Con.State == ConnectionState.Open)
            {
                //Đóng kết nối
                Con.Close();

                //Giải phóng tài nguyên
                Con.Dispose();
                Con = null;

                //Kiểm tra kết nối
                //MessageBox.Show("Đóng Kết nối DB thành công");
            }
        }

        // lấy ConnectString với mỗi loại user
        public static string get_ConnectString(int type)
        {
            string s = "";
            switch (type)
            {
                // vô danh
                case -2:
                    {
                        s = @"Data Source=" + exactly_server_name + ";Initial Catalog=HYT;Persist Security Info=True;User ID=HYT_VODANH;Password=12345";
                        break;
                    }
                // quản trị
                case 0:
                    {
                        s = @"Data Source=" + exactly_server_name + ";Initial Catalog=HYT;Persist Security Info=True;User ID=HYT_QT;Password=12345";
                        break;
                    }
                // khách hàng
                case 1:
                    {
                        s = @"Data Source=" + exactly_server_name + ";Initial Catalog=HYT;Persist Security Info=True;User ID=HYT_KHACHHANG;Password=12345";
                        break;
                    }
                // nhân viên
                case 2:
                    {
                        s = @"Data Source=" + exactly_server_name + ";Initial Catalog=HYT;Persist Security Info=True;User ID=HYT_NHANVIEN;Password=12345";
                        break;
                    }
                // nhân sự
                case 3:
                    {
                        s = @"Data Source=" + exactly_server_name + ";Initial Catalog=HYT;Persist Security Info=True;User ID=HYT_NHANSU;Password=12345";
                        break;
                    }
                // quản lý
                case 4:
                    {
                        s = @"Data Source=" + exactly_server_name + ";Initial Catalog=HYT;Persist Security Info=True;User ID=HYT_QL;Password=12345";
                        break;
                    }
            }
            return s;
        }

        public static DataTable GetDataToTable(string sql) //Lấy dữ liệu đổ vào bảng
        {
            SqlDataAdapter dap = new SqlDataAdapter();
            dap.SelectCommand = new SqlCommand();

            //Kết nối cơ sở dữ liệu
            dap.SelectCommand.Connection = Functions.Con;
            dap.SelectCommand.CommandText = sql;

            DataTable table = new DataTable();
            dap.Fill(table);
            return table;
        }

        public static bool CheckKey(string sql) // kiểm tra xem có trùng khóa hay không
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, Con);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }

        public static void RunSQL(string sql) // chạy câu lệnh sql
        {
            SqlCommand cmd = new SqlCommand();

            //Gán kết nối
            cmd.Connection = Con;

            //Gán lệnh SQL
            cmd.CommandText = sql;

            //Thực hiện câu lệnh SQL
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //Giải phóng bộ nhớ
            cmd.Dispose();
            cmd = null;
        }
        public static void FillCombo(string sql, ComboBox cbo, string ma, string ten) // đổ dữ liệu vào comboBox
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, Con);
            DataTable table = new DataTable();
            dap.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma;
            cbo.DisplayMember = ten;
        }

        public static string GetFieldValues(string sql) // lấy dữ liệu từ câu lệnh sql
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, Con);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            return ma;
        }
    }
}
