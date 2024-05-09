using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSV.DTO;

namespace QLSV.DAL
{
    public class QLSV_DAL
    {
        public List<SV> getAllSV()
        {
            List<SV> result = new List<SV>();
            string query = "select * from SV";
            foreach (DataRow i in DbHelper.Instance.GetRecord(query).Rows)
            {
                result.Add(getSVByDataRow(i));
            }
            return result;
        }
        public SV getSVByDataRow(DataRow row)
        {
            return new SV
            {
                MSSV = row["MSSV"].ToString(),
                FullName = row["NameSV"].ToString(),
                DTB = Convert.ToDouble(row["DTB"].ToString()),
                Gender = Convert.ToBoolean(row["Gender"].ToString()),
                NS = Convert.ToDateTime(row["NS"].ToString()),
                ID_LopSH =Convert.ToInt32( row["ID_Lop"].ToString())
            };
        }
        public List<LopSH> getAllLopSH()
        {
            string query = "select * from LSH";
            List<LopSH> result = new List<LopSH>();
            foreach (DataRow i in DbHelper.Instance.GetRecord(query).Rows)
            {
                result.Add(getLopSHByDataRow(i));
            }
            return result;
        }
        public LopSH getLopSHByDataRow(DataRow row)
        {
            return new LopSH
            {
                id = Convert.ToInt32(row["ID_Lop"].ToString()),
                name = row["NameLop"].ToString()
            };
        }
        public void addSV(SV s)
        {
            string query = "INSERT INTO SV (MSSV, NameSV, DTB, Gender, ID_Lop, NS) " +
                    "VALUES (@MSSV, @NameSV, @DTB, @Gender, @ID_Lop, @NS)";
            DbHelper.Instance.saveSV(query, s);
        }
        public void updateSV(SV s)
        {
            string query = "UPDATE SV SET NameSV = @NameSV, DTB = @DTB, Gender = @Gender, ID_Lop = @ID_Lop, NS = @NS WHERE MSSV = @MSSV";
            DbHelper.Instance.saveSV(query, s);
        }
        public void deleteSV(string mssv)
        {
            string query = "DELETE FROM SV  WHERE MSSV=@mssv";
            DbHelper.Instance.deleteSV(query, mssv);
        }
    }
}
