using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EmployeeBusinessLogicLayer;
using EmployeeException;
namespace EMS.Presentation
{
    /// <summary>
    /// Interaction logic for Fpassword.xaml
    /// </summary>
    public partial class Fpassword : Window
    {
        public Fpassword()
        {
            InitializeComponent();
        }

        private void chPwd_Click(object sender, RoutedEventArgs e)
        {
            int res;
            int EmpId;
            string EmpEmail;
            try
            {
                if (int.TryParse(txtEmployeeId.Text, out res))
                {
                    EmpId = res;
                }
                EmpEmail = txtEmail.Text;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
