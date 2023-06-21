using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayPerTic.Notificaciones
{
    public class CollectorNotification
    {
        public string url { get; set; }
        public int response { get; set; }
        public string status { get; set; }
        public DateTime original_request { get; set; }
        public DateTime last_retry { get; set; }
        public int retry_count { get; set; }
    }
}
