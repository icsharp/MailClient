﻿using MailClient.Model;
using MailClient.View;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using System;


namespace MailClient.ViewModel
{
    internal class Login
    {

        public async void ToMail(User user, MainWindow loginpage)
        {
            ConfigModel Config = MainWindow.Config;
            using(SmtpClient sclient = new SmtpClient())
            {
                try
                {
                    sclient.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    await sclient.ConnectAsync(Config.SmtpServer, Config.SmtpPort);
                    sclient.Authenticate(user.Mail, user.Password);
                    sclient.Disconnect(true);
                    using (ImapClient client = new ImapClient())
                    {
                        try
                        {
                            client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                            await client.ConnectAsync(Config.ImapServer, Config.ImapPort);
                            client.Authenticate(user.Mail, user.Password);
                            client.Disconnect(true);
                            loginpage.Content = new Inbox(user, Config);
                            client.Disconnect(true);

                        }
                        catch (Exception)
                        {
                            loginpage.Info.Text = "Cannot Log-in Check Configuration";
                        }
                    } 
            }catch(Exception)
                {
                    loginpage.Info.Text = "Cannot Log-in Check Configuration";
                }
          

            }

        }
    }
}
