using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeException;
using System.Data;
using System.Security.Cryptography;




namespace EmployeeDataAcessLayer
{
    public class EmpDal
    {

        public static bool AddEmployee(EmployeeMaster addEmp) {

            bool addedEmployee=false;
            try
            {
                using (TeamSixEntity ent = new TeamSixEntity())
                {

                    EmployeeMaster empIo = new EmployeeMaster();
                    empIo.Designation = addEmp.Designation;
                    empIo.EmployeeID = addEmp.EmployeeID;
                    empIo.FirstName = addEmp.FirstName;
                    empIo.MiddleName = addEmp.MiddleName;
                    empIo.LastName = addEmp.LastName;
                    empIo.Location = addEmp.Location;
                    empIo.ReimbursementAccNo = addEmp.ReimbursementAccNo;
                    empIo.UserName = addEmp.UserName;
                    empIo.PasswordHASH = addEmp.PasswordHASH;
                    ent.EmployeeMasters.Add(empIo);
                    ent.SaveChanges();
                    addedEmployee = true;



                }

            }
            catch (EmpException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return addedEmployee;


        }

        public static bool CheckEmployeeLogin(string userName, string Password)
        {
            bool ckLoginStat = false;

            using (TeamSixEntity ent = new TeamSixEntity()) {

                var q = from res in ent.EmployeeMasters
                        where res.UserName == userName && res.PasswordHASH == comPuteHash(Password)

                        select res;
                if (q != null)
                {
                    ckLoginStat = true;
                }
                
            
            
            }

            return ckLoginStat;
        
        
        }


        public static byte[] comPuteHash(string hashStr) {

            SHA512Managed sh5 = new SHA512Managed();
            UnicodeEncoding ue = new UnicodeEncoding();
            byte[] message = ue.GetBytes(hashStr);
            byte[] result = sh5.ComputeHash(message);
            return result;
        
        
        
        }

        public static bool chngPassword(string emplEmail,int empID)
        {
            bool isSucess = false;

            using (TeamSixEntity ent =new TeamSixEntity())
            {
                var q = from emp in ent.EmployeeMasters
                        where emp.EmployeeID == empID
                        select emp;
                if (q!=null)
                {
                    isSucess = true;
                }

            }
            if (isSucess)
            {

            }
            return isSucess;

        }

        //public static bool sentEmail(string empEmail)
        //{
        //    //string to = "jane@contoso.com";
        //    //string from = "ben@contoso.com";
        //    //string subject = "Using the new SMTP client.";
        //    //string body = @"Using this new feature, you can send an e-mail message from an application very easily.";
        //    //MailMessage message = new MailMessage(from, to, subject, body);
        //    //SmtpClient client = new SmtpClient(server);
        //    //Console.WriteLine("Changing time out from {0} to 100.", client.Timeout);
        //    //client.Timeout = 100;
        //    //// Credentials are necessary if the server requires the client 
        //    //// to authenticate before it will send e-mail on the client's behalf.
        //    //client.Credentials = CredentialCache.DefaultNetworkCredentials;

        //    //try
        //    //{
        //    //    client.Send(message);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    Console.WriteLine("Exception caught in CreateTimeoutTestMessage(): {0}",
        //    //          ex.ToString());
        //    //}

        //}

    }
}
