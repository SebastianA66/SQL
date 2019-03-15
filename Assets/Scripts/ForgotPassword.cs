using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region Sending Emails
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
#endregion

namespace sql
{
    public class ForgotPassword : MonoBehaviour
    {

        public string code;
        public InputField email;
        public string username;
        public static System.Random random = new System.Random();
        public void SendEmail()
        {
            code = RandomString(12);

            MailMessage mail = new MailMessage();
            MailAddress ourEmail = new MailAddress("", "SQueaLbusiness plz work");
            // Receiver
            mail.To.Add(email.text);
            // Sender
            mail.From = ourEmail;
            // Topic
            mail.Subject = "SQueaL Code Request plz work";
            //  Main
            mail.Body = "Hello There" + username + "\nReset your account using this code: " + code;

            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Port = 25;
            smtpServer.Credentials = new System.Net.NetworkCredential("", "sqlpassword") as ICredentialsByHost;
            smtpServer.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors) { return true; };
            smtpServer.Send(mail);
            Debug.Log("Succes");
        }

        public static string RandomString(int length)
        {
            const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }



        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
