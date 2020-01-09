
//using Experimental.System.Messaging;
using Experimental.System.Messaging;
using System;
    using System.Linq;
    using System.Net.Mail;
    using System.Xml.Linq;

    namespace RecieveMail
    {
        public class Program
        {
           public static void Main(string[] args)
            {
                //// Create the instance of MessageQueue
                MessageQueue MyQueue;

                //// Here We Takeing the reference of MyQueue Wich is created in MessageingQueue in your System
                MyQueue = new MessageQueue(@".\Private$\EmailQueue");

                //// Here We create the instance of Message and recived the Message from MessageingQueue
                Message message = MyQueue.Receive();

                message.Formatter = new BinaryMessageFormatter();



                //// Here token variable stroes the JWT Token
                string token = message.Label;
             
            Console.WriteLine(token);
                //   Console.WriteLine(mailOfsender);
                //   Console.WriteLine(message.Body.ToString());

                try
                {
                    string FromMail = "satishdodake1993@gmail.com";
                    //// it defines a mail which is send using SMTPClient
                    MailMessage mail = new MailMessage();

                    //// define Gmail server of SMTP
                    using (SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com"))
                    {
                        string url = "http://localhost:3000/reset/"+token;
                        mail.From = new MailAddress(FromMail);

                        //// Add the mail to whom We want to send mail
                        mail.To.Add("satishdodake1993@gmail.com");
                        mail.Subject = "Test Mail";

                        //// Mail body which contain url and JWT token
                        mail.Body = "<h1> Plese click on below link to rest your password </h1>"
                            + "<p>" + "<a href=" + url + "</a>" + token + "</p>";

                        //// SMTP port number
                        SmtpServer.Port = 587;

                        //// Defines the username and password
                        SmtpServer.Credentials = new System.Net.NetworkCredential("satishdodake1993@gmail.com", "vishwratna@75");
                        //// EnableSsl  specifies whether SSL(Secure Socket Layer) is used to access the specified SMTP mail server
                        SmtpServer.EnableSsl = true;

                        //// send() is used to send mail
                        SmtpServer.Send(mail);
                        Console.WriteLine("mail sent successfully");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.ReadKey();
            }
        }
    }