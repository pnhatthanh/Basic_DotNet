using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    internal class CSDL
    {
        private DataTable dt;
        private static CSDL _Instance;
        public DataTable dataTable
        {
            get { return dt; }
            private set { }
        }
        public static CSDL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CSDL();
                }
                return _Instance;
            }
            private set { }
        }
        private CSDL()
        {
            dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn { ColumnName = "MSSV", DataType = typeof(string) },
                new DataColumn { ColumnName = "FullName", DataType = typeof(string) },
                new DataColumn { ColumnName = "LopSH", DataType = typeof(string) },
                new DataColumn{ColumnName="NS",DataType=typeof(DateTime) },
                new DataColumn { ColumnName = "Gender", DataType = typeof(bool) },
                new DataColumn { ColumnName = "DTB", DataType = typeof(double) }
            });
            dt.Rows.Add("101", "NVA", "20T1", DateTime.Now.ToString("dd/MM/yyyy"), true, 1.1);
            dt.Rows.Add("102", "NVB", "20T2", DateTime.Now.ToString("dd/MM/yyyy"), true, 1.1);
            dt.Rows.Add("103", "NVC", "20T1", DateTime.Now.ToString("dd/MM/yyyy"), true, 1.1);
            dt.Rows.Add("104", "NVD", "20T3", DateTime.Now.ToString("dd/MM/yyyy"), true, 1.1);
        }
        public void addSV(SV s)
        {
            dt.Rows.Add(s.MSSV, s.FullName, s.LopSH, s.NS, s.Gender, s.DTB);
        }
        public void removeSV(string mssv)
        {
            foreach(DataRow dr in dt.Rows)
            {
                if (dr["MSSV"].ToString()==mssv)
                {
                    dt.Rows.Remove(dr);
                    break;
                }
            }
        }
        public void editSV(SV s)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["MSSV"].ToString() == s.MSSV)
                {
                    dr["FullName"] = s.FullName;
                    dr["LopSH"] = s.LopSH;
                    dr["Gender"]=s.Gender;
                    dr["NS"] = s.NS;
                    dr["DTB"] = s.DTB;
                }
            }
        }
        public List<SV> getAllSV()
        {
            List<SV> list = new List<SV>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new SV
                {
                    MSSV = dr["MSSV"].ToString(),
                    FullName = dr["FullName"].ToString(),
                    LopSH = dr["LopSH"].ToString(),
                    NS = Convert.ToDateTime(dr["NS"].ToString()),
                    Gender = Convert.ToBoolean(dr["Gender"].ToString()),
                    DTB = Convert.ToDouble(dr["DTB"].ToString())
                });
            }
            return list;
        }
        public SV findSV(string mssv)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["MSSV"].ToString() == mssv)
                {
                    return new SV
                    {
                        MSSV = dr["MSSV"].ToString(),
                        FullName = dr["FullName"].ToString(),
                        LopSH = dr["LopSH"].ToString(),
                        NS = Convert.ToDateTime(dr["NS"].ToString()),
                        Gender = Convert.ToBoolean(dr["Gender"].ToString()),
                        DTB = Convert.ToDouble(dr["DTB"].ToString())
                    };
                }
            }
            return null;
        }
    }
}
