using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Web
{
    public class Utility
    {
        public const string MemberRoleId = "3";
        public const string MemberRoleName = "Member";

        public const string AdminRoleId = "1";
        public const string AdminRoleName = "Admin";
        
        public const string ConfigEmail = "ConfigEmail";
        public const string ProductConfiguration = "ProductConfiguration";
        public const string MaxDiscount = "MaxDiscount";
        public static void SendEmailAsync(string email, string subject, string body)
        {

            string fromAddress = ConfigurationManager.AppSettings["FromAddress"];
            string fromPwd = ConfigurationManager.AppSettings["FromPassword"];
            string fromDisplayName = ConfigurationManager.AppSettings["FromDisplayNameA"];
            //string cc = ConfigurationManager.AppSettings["CC"];
            //string bcc = ConfigurationManager.AppSettings["BCC"];

            //Getting the file from config, to send
            MailMessage oEmail = new MailMessage
            {
                From = new MailAddress(fromAddress, fromDisplayName),
                Subject = subject,
                IsBodyHtml = true,
                Body = body,
                Priority = MailPriority.High
            };
            oEmail.To.Add(email);
            string smtpServer = ConfigurationManager.AppSettings["SMTPServer"];
            string smtpPort = ConfigurationManager.AppSettings["SMTPPort"];
            string enableSsl = ConfigurationManager.AppSettings["EnableSSL"];
            SmtpClient client = new SmtpClient(smtpServer, Convert.ToInt32(smtpPort))
            {
                EnableSsl = enableSsl == "1",
                Credentials = new NetworkCredential(fromAddress, fromPwd)
            };

            client.Send(oEmail);

        }
        public bool SendSms(string smsText, string mobileNo)
        {
            
            string username = ConfigurationManager.AppSettings["MobileUsername"];
            string password = ConfigurationManager.AppSettings["MobilePassword"];
            string senderId = ConfigurationManager.AppSettings["SenderID"];

            WebRequest smsRequest =
                WebRequest.Create("http://www.jawalbsms.ws/api.php/sendsms?user=" + username + "&pass=" +
                                  password +
                                  "&to=" + mobileNo + "&message=" + smsText +
                                  "&sender=" + senderId);
            WebResponse smsRequestResponse = smsRequest.GetResponse();
            Stream smsDataStream = smsRequestResponse.GetResponseStream();
            StreamReader smsReader = new StreamReader(smsDataStream);
            string smsResponse = smsReader.ReadToEnd();

            if (smsResponse.ToLower().Contains("success"))
            {
                return true;
            }
            return false;
        }

        public string GetConfigEmail(System.Web.HttpSessionStateBase Session, IProductConfigurationService configurationService)
        {
            if (Session[Utility.ProductConfiguration] == null)
            {
                ProductConfiguration config= configurationService.GetDefaultConfiguration();
                Session[Utility.ProductConfiguration] = config;

                var email = config.Emails;
                if (string.IsNullOrEmpty(email))
                    Session[Utility.ConfigEmail] = "NONE";
                else
                    Session[Utility.ConfigEmail] = email;
                return email;

            }
            else
            {
                ProductConfiguration config = (ProductConfiguration) Session[Utility.ProductConfiguration];
                var email = config.Emails;
                if (string.IsNullOrEmpty(email))
                    Session[Utility.ConfigEmail] = "NONE";
                else
                    Session[Utility.ConfigEmail] = email;
                return email;
            }
        }

        public string GetConfigMaxDiscount(System.Web.HttpSessionStateBase Session, IProductConfigurationService configurationService,bool isAdmin)
        {
            if (isAdmin)
            {

                return "25";

            }
            else if (Session[Utility.ProductConfiguration] == null)
            {
                Session[Utility.ProductConfiguration] = configurationService.GetDefaultConfiguration();
            }
            var config = (ProductConfiguration)Session[Utility.ProductConfiguration];
            return config.MaxAllowedDiscount.ToString();
        }

        public string GetDefaultVendor(System.Web.HttpSessionStateBase Session, IProductConfigurationService configurationService)
        {
            if (Session[Utility.ProductConfiguration] == null)
            {
                ProductConfiguration config = configurationService.GetDefaultConfiguration();
                Session[Utility.ProductConfiguration] = config;
            }
            var toReturn = (ProductConfiguration) Session[Utility.ProductConfiguration];
            return toReturn.DefaultVendorId.ToString();
        }
    }
}