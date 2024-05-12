using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class DbHelper
    {
        private SqlConnection connect;
        private static DbHelper _instance;
        public static DbHelper Instance
        {
            get {
                if (_instance == null)
                {
                    _instance = new DbHelper();
                }
                return _instance; 
            }
            private set {}
        }
        private DbHelper()
        {
            string stringConnect = "Server=Admin;Database=appointment;Integrated Security=True;";
            connect = new SqlConnection(stringConnect);
        }
        public List<Appointment> getAllAppointment(int userId)
        {
            List<Appointment> list = new List<Appointment>();
            connect.Open();
            string query = "Select * from appointment where UserID=@userId";
            SqlCommand cmd = new SqlCommand(query, connect);
            cmd.Parameters.Add(new SqlParameter("@userId",userId));
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Appointment appointment = new Appointment
                {
                    appointmentId = Convert.ToInt32(reader[0].ToString()),
                    appointmentName = reader[1].ToString(),
                    location= reader[2].ToString(),
                    startTime = Convert.ToDateTime(reader[3].ToString()),
                    endTime = Convert.ToDateTime(reader[4].ToString()),
                    userId = Convert.ToInt32(reader[5].ToString()),
                };
                list.Add(appointment);
            }
            connect.Close();
            return list;
        }
        public List<GroupMeeting> getAllGroupMeeting()
        {
            List<GroupMeeting> list = new List<GroupMeeting>();
            connect.Open();
            string query = "Select * from group_meeting";
            SqlCommand cmd = new SqlCommand(query, connect);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                GroupMeeting appointment = new GroupMeeting
                {
                    appointmentId = Convert.ToInt32(reader[0].ToString()),
                    appointmentName = reader[1].ToString(),
                    location = reader[2].ToString(),
                    startTime = Convert.ToDateTime(reader[3].ToString()),
                    endTime = Convert.ToDateTime(reader[4].ToString()),
                };
                list.Add(appointment);
            }
            connect.Close();
            return list;
        }
        public void addUserInGroup(int userId,int groupId)
        {
            string query = "Insert into UserGroupMeetings values" +
                "(@groupId,@userId)";
            SqlCommand cmd=new SqlCommand(query, connect);
            cmd.Parameters.Add(new SqlParameter("@userId", userId));
            cmd.Parameters.Add(new SqlParameter("@groupId", groupId));
            try
            {
                connect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }
        public void saveAppointment(Appointment appointment,List<string> reminders)
        {
            connect.Open();
            SqlTransaction transaction = connect.BeginTransaction();
            try
            {
                string query = "INSERT INTO appointment (AppointmentName, Location, StartTime, EndTime, UserId) VALUES " +
                    "(@AppointmentName, @Location, @StartTime, @EndTime, @UserId); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, connect, transaction);
                cmd.Parameters.AddWithValue("@AppointmentName", appointment.appointmentName);
                cmd.Parameters.AddWithValue("@Location", appointment.location);
                cmd.Parameters.AddWithValue("@StartTime", appointment.startTime);
                cmd.Parameters.AddWithValue("@EndTime", appointment.endTime);
                cmd.Parameters.AddWithValue("@UserId", appointment.userId);
                int appointmentID = Convert.ToInt32(cmd.ExecuteScalar());
                foreach (var item in reminders)
                {
                    string reminderQuery = "INSERT INTO reminder VALUES (@AppointmentId, @ReminderText)";
                    SqlCommand reminderCmd = new SqlCommand(reminderQuery, connect, transaction);
                    reminderCmd.Parameters.AddWithValue("@AppointmentId", appointmentID);
                    reminderCmd.Parameters.AddWithValue("@ReminderText", item);
                    reminderCmd.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }
        public DataTable loadAppointment(int userId)
        {
            string query = "SELECT AppointmentId,AppointmentName, appointment.Location, appointment.StartTime, appointment.EndTime " +
                  "FROM appointment " +
                  "WHERE UserId = " + userId + " " +

                  "UNION " +

                  "SELECT group_meeting.AppointmentId,AppointmentName, group_meeting.Location, group_meeting.StartTime, group_meeting.EndTime FROM group_meeting " +
                  "INNER JOIN UserGroupMeetings ON group_meeting.AppointmentId = UserGroupMeetings.AppointmentId " +
                  "WHERE UserGroupMeetings.UserID = " + userId;

            DataTable dt = new DataTable();
            connect.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, connect);
            da.Fill(dt);
            connect.Close();
            return dt;
        }

        public DataTable loadReminders(int appointmentID)
        {
            string query = "Select * from reminder where AppointmentId="+appointmentID;
            DataTable dt = new DataTable();
            connect.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, connect);
            da.Fill(dt);
            connect.Close();
            return dt;
        }
    }
}
