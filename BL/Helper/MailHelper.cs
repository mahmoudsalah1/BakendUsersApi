using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BackendUsers.BL.Helper
{
    public static class MailHelper
    {
        public static string SendMail(string Title , string Message)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("as8338873@gmail.com", "A@123321A@");
                smtp.Send("as8338873@gmail.com", "mahmoudsalah088@gmail.com", Title, Message);

                return "mail send successfully";
            }
            catch (Exception ex)
            {
                return "faild to send mail" + ex;
            }
           

        }
    }
}
