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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EmployeeBusinessLogicLayer;
using EmployeeDataAcessLayer;
using EmployeeException;

namespace EMS.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginMain : Window
    {
        public LoginMain()
        {
            InitializeComponent();

            
            
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

            ////HomePage hmg = new HomePage();
            ////this.Hide();
            ////hmg.ShowDialog();
            ////this.Show();
            //Registration reg = new Registration();
            //this.Hide();
            //reg.ShowDialog();
            //this.Show();
            string empUserName = txtUsername.Text;
            string empPassword = txtPassword.Password.ToString();
            bool isSucess = EmployeeBal.LoginSucessFull(empUserName, empPassword);
            MessageBox.Show(isSucess.ToString());
            
            
            
            

        }
        private void OnClick(object sender, RoutedEventArgs e)
        {
            Fpassword newChangePwd = new Fpassword();
            this.Hide();
            newChangePwd.ShowDialog();
            this.Show();
        }

       
    }
}

