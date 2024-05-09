using QLSV.DAL;
using QLSV.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace QLSV
{
    public class QLSV
    {

        private QLSV_DAL QLSV_DAL = new QLSV_DAL();
        public List<SV> getAllSV()
        {
            return QLSV_DAL.getAllSV();
        }
        public List<LopSH> getAllLopSH()
        {
            return QLSV_DAL.getAllLopSH();
        }
        public List<CbbItem> getCBB()
        {
            List<CbbItem> res = new List<CbbItem>();
            foreach (LopSH i in getAllLopSH())
            {
                res.Add(new CbbItem
                {
                    name = i.name,
                    value = i.id
                });
            }
            res.Add(new CbbItem
            {
                name = "All",
                value = 0,
            });
            return res;
        }
        public List<ListSV> getSVBySearch(int id, string txt)
        {
            List <ListSV> listSV=new List<ListSV>();
            List<SV> sv=new List<SV>();
            if (id == 0)
            {
                sv = getAllSV().Where(s => s.FullName.Contains(txt)).ToList();
            }
            else
            {
                 sv = getAllSV().Where(s => s.ID_LopSH == id && s.FullName.Contains(txt)).ToList();
            }
            foreach (SV s in sv)
            {
                listSV.Add(new ListSV
                {
                    MSSV = s.MSSV,
                    FullName = s.FullName,
                    Gender = s.Gender,
                    NS = s.NS,
                    DTB = s.DTB,
                    NameLopSH = getAllLopSH().First(l => l.id == s.ID_LopSH).name
                });
            }
            return listSV;
        }
        public void deleteSVByID(string mssv)
        {
           QLSV_DAL.deleteSV(mssv);
        }
        public void AddUpdate(SV s)
        {
            SV sv = getAllSV().FirstOrDefault(k => k.MSSV.Equals(s.MSSV));
            if (sv == null)
            {
                QLSV_DAL.addSV(s);
            }
            else
            {
                QLSV_DAL.updateSV(s);
            }
        }
        public SV getSVByID(string mssv)
        {
            return getAllSV().FirstOrDefault(sv => sv.MSSV.Equals(mssv));
        }
        public List<ListSV> sortSV(List<ListSV> sv, string criteria)
        {
            switch (criteria)
            {
                case "NameSV":
                    return sv.OrderBy(s => s.FullName).ToList();
                case "MSSV":
                    return sv.OrderBy(s => s.MSSV).ToList();
                case "DTB":
                    return sv.OrderBy(s => s.DTB).ToList();
                case "NS":
                    return sv.OrderBy(s => s.NS).ToList();
                case "Gender":
                    return sv.OrderBy(s => s.Gender).ToList();

                default: return sv;
            }
        }
        public CbbItem getCbbItemByIdLsh(int id)
        {
            LopSH lsh=getAllLopSH().FirstOrDefault(l=>l.id==id);
            return new CbbItem
            {
                name=lsh.name,
                value=lsh.id
            };
        }
    }
}
