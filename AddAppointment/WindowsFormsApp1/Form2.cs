using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private List<string> reminders = new List<string>();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(startTime.Value>=endTime.Value)
            {
                MessageBox.Show("Invalid time");
                return;
            }
            if(string.IsNullOrEmpty(name.Text)|| string.IsNullOrEmpty(location.Text) )
            {
                MessageBox.Show("Invalid information");
                return;
            }
            List<Appointment> appointments = DbHelper.Instance.getAllAppointment(1);
            foreach (var item in appointments)
            {
                if (startTime.Value<item.endTime&&endTime.Value>item.startTime||
                    item.startTime<endTime.Value&&item.endTime>startTime.Value)
                {
                    MessageBox.Show("Time overlap. Choose an available time or replace the previous " +
                        "appointment", "Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            List<GroupMeeting> groupMeetings = DbHelper.Instance.getAllGroupMeeting();
            foreach (var item in groupMeetings) 
            {
                if (item.appointmentName == name.Text && item.startTime == startTime.Value && endTime.Value == item.endTime)
                {
                    DialogResult result = MessageBox.Show("Do you want to join group?","Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DbHelper.Instance.addUserInGroup(1, item.appointmentId);
                        this.Close();
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            Appointment appointment = new Appointment
            {
                appointmentName = name.Text,
                location = location.Text,
                startTime = startTime.Value,
                endTime = endTime.Value,
                userId = 1
            };
            DbHelper.Instance.saveAppointment(appointment,reminders);
            this.Close();
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                string selectedRemind = checkBox.Text;
                if (checkBox.Checked)
                {
                    reminders.Add(selectedRemind);
                }
                else
                {
                    reminders.Remove(selectedRemind);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
