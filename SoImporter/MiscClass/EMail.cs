using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace SoImporter.MiscClass
{
    public class EMail
    {

        public EMail()
        {

        }

        public static bool Send(string mail_to, string subject, string body)
        {
            try
            {
                //EMail email = new EMail(subject, body);

                MailMessage mail = new MailMessage("express.dbd@gmail.com", mail_to);
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Host = "smtp.gmail.com";
                client.UseDefaultCredentials = false;
                NetworkCredential nc = new NetworkCredential("express.dbd@gmail.com", "Express2173533");
                client.Credentials = nc;
                mail.Subject = subject;
                mail.Body = body;
                client.Send(mail);

                return true;
            }
            catch (Exception ex)
            {
                if(MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    return EMail.Send(mail_to, subject, body);
                }

                return false;
            }
        }
    }
}
