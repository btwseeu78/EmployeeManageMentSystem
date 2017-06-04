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
using EmployeeDataAcessLayer;
using EmployeeBusinessLogicLayer;
using EmployeeException;


namespace EMS.Presentation
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Author : Team Six
        /// Description : This method Is Used To inser new Employee After The Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool IsAddedEmployee = false;
                int result;
                EmployeeMaster newEmp = new EmployeeMaster();
                newEmp.Designation = "Employee";
                if (int.TryParse(txtEmpId.Text, out result))
                {

                    newEmp.EmployeeID = result;

                }
                newEmp.FirstName = txtEmpName.Text;
                newEmp.LastName = txtLastName.Text;
                
                newEmp.MiddleName = txtMiddleName.Text;
                newEmp.Location = txtLocation.Text;
                newEmp.ReimbursementAccNo = txtReimburse.Text;
                newEmp.UserName = txtUserName.Text;
                newEmp.PasswordHASH = EmployeeBal.createHash(txtPassword.Text);
                IsAddedEmployee = EmployeeBal.RegNewEmployee(newEmp);
                if (!IsAddedEmployee)
                {
                    MessageBox.Show("Employee not added");
                }
                else
                {
                    MessageBox.Show("Employee Added Sucess Fully");
                    AdminHome newHome = new AdminHome();
                    this.Close();
                    newHome.ShowDialog();
                    this.Show();

                   
                }
            }
            catch (EmpException ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message.ToString());
            }


        }
    }
}
