using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Core.Models.Auth
{
    public class RefreshToken
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string ClientAppId { get; set; }
        public DateTime CreatedDateUtc { get; set; }
        public DateTime ExpirationDateUtc { get; set; }
        public string ProtectedTicket { get; set; }
    }
}
