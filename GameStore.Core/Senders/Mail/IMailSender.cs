using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Senders.Mail
{
    public interface IMailSender
    {
        void Send(string to, string subject, string body);
    }
}
