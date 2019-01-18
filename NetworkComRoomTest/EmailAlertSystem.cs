using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NetworkComRoomTest
{
    class EmailAlertSystem
    {
        public static void EMail()
        {




            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress("brian.purdy@eventseast.com", "Brian"));
            msg.From = new MailAddress("brian.purdy@eventseast.com", "Network_Tester");
            msg.Subject = "Network HeartBeat Error";
            msg.Body = "The system has failed 5 HeartBeat Checks in a row, this may require some assistance from you.";
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("brian.purdy@eventseast.com", "RedWraith18E");
            client.Port = 587; // You can use Port 25 if 587 is blocked (mine is!)
            client.Host = "smtp.office365.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            try
            {
                LogHelper.Log(LogTarget.ErrorFile, "HeartBeat failure ==>  Sending Email notification." + DateTime.Now);
                LogHelper.Log(LogTarget.File, "Sending Email ==>  HeartBeat Failure notification." + DateTime.Now);

                client.Send(msg);                

                LogHelper.Log(LogTarget.File, "Email Notification ==>  HeartBeat Failure notification successfully sent." + DateTime.Now);
            }
            catch (Exception e)
            {
                LogHelper.Log(LogTarget.ErrorFile, "Email Sending Failure ==>  HeartBeat Failure notification email Failed to send (check errorlog).\n\n " + e.Message + "\n" + DateTime.Now);
            }

        }
    }
}
