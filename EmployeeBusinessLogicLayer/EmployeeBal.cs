using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDataAcessLayer;
using EmployeeException;
using System.Text.RegularExpressions;


namespace EmployeeBusinessLogicLayer
{
    public class EmployeeBal
    {
        public static bool ValidateEmpData(EmployeeMaster emSt) {
            StringBuilder sb = new StringBuilder();
            bool isValidated = true;

            try
            {
                

                if (string.IsNullOrWhiteSpace(emSt.FirstName))
                {

                    isValidated = false;
                    sb.Append("First name cannot Be Null/n");
                }
                else if (!Regex.IsMatch(emSt.FirstName,@"^[A-Z][a-z]+$"))
                {
                    isValidated = false;
                    sb.Append("Employee First Name Must Be Start with Capital letter and can only contains Strings\n");
                }

                if (string.IsNullOrWhiteSpace(emSt.LastName))
                {

                    isValidated = false;
                    sb.Append("Last name cannot Be Null/n");
                }
                else if (!Regex.IsMatch(emSt.LastName,@"^[A-Z][a-z]+$"))
                {
                    isValidated = false;
                    sb.Append("Last Name Starts with Capital Letter And Only Contains String");
                }

                if (string.IsNullOrWhiteSpace(emSt.MiddleName))
                {

                    isValidated = false;
                    sb.Append("Middle name cannot Be Null/n");
                }
                if (string.IsNullOrWhiteSpace(emSt.UserName))
                {

                    isValidated = false;
                    sb.Append("username cannot Be Null/n");
                }
               
                if (string.IsNullOrWhiteSpace(emSt.Location))
                {

                    isValidated = false;
                    sb.Append("location cannot Be Null/n");
                }
                if (string.IsNullOrWhiteSpace(emSt.EmployeeID.ToString()))
                {

                    isValidated = false;
                    sb.Append("Employee Id cannot Be Null/n");
                }
                else if (emSt.EmployeeID.ToString().Length != 6) {

                    isValidated = false;
                    sb.Append("Employee Id must be six digit long/n");
                
                }
               
              

            }
            catch (EmpException ex)
            {

                throw ex;
            }
            catch (Exception ex) {

                throw ex;
            }
            if (!isValidated)
            {
                throw new EmpException(sb.ToString());

            }
            return isValidated;
        
        
        }

        public static bool RegNewEmployee(EmployeeMaster regEmp) {

            bool isEmployeeAdded = false;

            try
            {
                if (ValidateEmpData(regEmp)) 
                {
                    isEmployeeAdded = EmpDal.AddEmployee(regEmp);
                    
                }
            }

            catch (EmpException ex)
            {

                throw ex;
            }
            catch (Exception ex) {

                throw ex;
            
            }
            return isEmployeeAdded;
        
        }

        public static bool LoginSucessFull(string userName, string passWord) {

            bool LoginSucessFull = false;

            try
            {
                LoginSucessFull = EmpDal.CheckEmployeeLogin(userName, passWord);

            }

            catch (EmpException ex) {

                throw ex;
            }

            catch (Exception ex)
            {

                throw ex;
            }
            if (!LoginSucessFull)
            {
                throw new EmpException("provide valid username and password");
            }

            return LoginSucessFull;
        }

        public static byte[] createHash(string passWord) {
            byte[] res;
            try
            {
                if (string.IsNullOrWhiteSpace(passWord))
                {
                    throw new EmpException("you should mention a password");
                }
                else
                {
                    res = EmpDal.comPuteHash(passWord);

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return res;
        }

        ///
        /// <summary>
        /// author:Team Six
        /// Description change Password Module
        /// </summary>
        public bool changePassword(string eid, string eemail) {
            bool isSucessFul=false;
            try
            {
              
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return isSucessFul;

        }
    }
}
