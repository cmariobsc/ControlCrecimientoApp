using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Web.Core.Models
{
    public static class JsonStatus
    {
        public static string Success() { return "OK"; }
        public static string Incomplete() { return "INCOMPLETE"; }
        public static string Error() { return "ERROR"; }
    }
}
