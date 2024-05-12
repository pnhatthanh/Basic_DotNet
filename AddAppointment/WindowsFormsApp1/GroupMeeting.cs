using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class GroupMeeting
    {
        public int appointmentId { get; set; }
        public string appointmentName { get; set; }
        public string location { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }
}
