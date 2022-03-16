using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDLNC_CosplayBanHoa
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new DangNhap());
            //Application.Run(new FormMain_KH());
            //Application.Run(new FormMain_NS());
            //Application.Run(new FormMain_QL());
            //Application.Run(new FormMain_QT());

           

        }
    }
}
