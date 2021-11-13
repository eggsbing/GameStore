using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Interfaces
{
    public interface ICurrentUserService
    {
        int UserId { get; }
        string UserIp { get; }
        string Mobile { get; }
        string Email { get; }
        string UrlReferer { get; set; }
        string CurrentUrl { get; set; }
    }
}
