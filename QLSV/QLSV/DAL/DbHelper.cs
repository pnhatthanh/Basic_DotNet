using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSV.DTO;

namespace QLSV
{
    public class DbHelper
    {
        private SqlConnection _con;
        private static DbHelper _instance;
        public static DbHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    string s = "Data Source=Admin;Initial Catalog=QLSV;Integrated Security=True;";
                    _instance = new DbHelper(s);
                }
                return _instance;
            }
            private set { }
        }
        private DbHelper(string s)
        {
            _con = new SqlConnection(s);
        }
        public DataTable GetRecord(string query)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, _con);
            _con.Open();
            da.Fill(dt);
            _con.Close();
            return dt;
        }
        public void ExecuteDb(string query)
        {
            SqlCommand cmd = new SqlCommand(query, _con);
            _con.Open();
            cmd.ExecuteNonQuery();
            _con.Close();
        }
        public void deleteSV(string query, string mssv)
        {
            SqlCommand cmd = new SqlCommand(query, _con);
            cmd.Parameters.AddWithValue("@mssv", mssv);
            _con.Open();
            cmd.ExecuteNonQuery();
            _con.Close();
        }
        public void saveSV(string query,SV sv)
        {
            SqlCommand cmd = new SqlCommand(query, _con);
            _con.Open();
            cmd.Parameters.Add(new SqlParameter("@MSSV",sv.MSSV));
            cmd.Parameters.Add(new SqlParameter("@NameSV", sv.FullName));
            cmd.Parameters.Add(new SqlParameter("@DTB", sv.DTB));
            cmd.Parameters.Add(new SqlParameter("@Gender", sv.Gender));
            cmd.Parameters.Add(new SqlParameter("@ID_Lop", sv.ID_LopSH));
            cmd.Parameters.Add(new SqlParameter("@NS", sv.NS));
            try
            {
                cmd.ExecuteNonQuery();
            }catch (Exception ex)
            {
                _con.Close();
                throw ex;
            }
            _con.Close();
        }
        public SV getSVByID(string query,string mssv)
        {
            SV sv = null;
            SqlCommand cmd = new SqlCommand(query, _con);
            _con.Open();
            cmd.Parameters.Add(new SqlParameter("@MSSV", mssv));
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                sv = new SV
                {
                    MSSV = reader["MSSV"].ToString(),
                    FullName = reader["NameSV"].ToString(),
                    DTB = Convert.ToDouble(reader["DTB"].ToString()),
                    ID_LopSH = Convert.ToInt32(reader["ID_Lop"].ToString()),
                    NS = Convert.ToDateTime(reader["NS"].ToString())
                };
            }
            _con.Close();
            return sv;
        }
        public LopSH GetLopSHByID(int id) {
            string query = "Select * from LSH Where ID_Lop=@ID_Lop";
            LopSH lop = null;
            SqlCommand cmd = new SqlCommand(query, _con);
            _con.Open();
            cmd.Parameters.Add(new SqlParameter("@ID_Lop", id));
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lop = new LopSH
                {
                    id =Convert.ToInt32(reader["ID_Lop"].ToString()),
                    name = reader["NameLop"].ToString(),
                };
            }
            _con.Close();
            return lop;
        }
    }
}
