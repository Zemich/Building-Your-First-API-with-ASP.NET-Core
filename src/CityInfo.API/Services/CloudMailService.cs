using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public class CloudMailService : IMailService
    {
        private string _mailTo = "admin@contoso.com";
        private string _mailFrom = "noreply@contoso.com";

        public void Send(string pSubject, string pMessage)
        {
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with CloudMailService");
            Debug.WriteLine($"Subject: {pSubject}");
            Debug.WriteLine($"Message {pMessage}");
        }
    }
}
