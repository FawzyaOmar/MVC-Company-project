﻿using System.Net;
using System.Net.Mail;

namespace Demo.PL.Helper
{
    public static class EmailSettings
    {
        public static void SendEmail(Email email) {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("elmontahasedrah@gmail.com","n u z h z r h g r y u t u o r y");
            client.Send("elmontahasedrah@gmail.com",email.To,email.Title,email.Body);
        }




    }
}
