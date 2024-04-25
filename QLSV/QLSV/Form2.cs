using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class Form2 : Form
    {
        private SV _sv=null;
        public Form2()
        {
            InitializeComponent();
            setLSH();
        }
        public Form2(SV sv)
        {
            InitializeComponent();
            this._sv = sv;
            setLSH();
            dataform2();
        }
        public void setLSH()
        {
            string query = "Select * from LSH";
            List<LopSH> li = new List<LopSH>();
            foreach (DataRow dr in DbAdapter.Instance.GetRecord(query).Rows)
            {
                li.Add(new LopSH
                {
                    name = dr["NameLop"].ToString(),
                    id = Convert.ToInt32(dr["ID_Lop"].ToString())
                });
            }
            li.Add(new LopSH
            {
                id = 0,
                name = "All"
            });
            cbbbLsh.Items.AddRange(li.ToArray());
        }
        private void dataform2()
        {
            mssv.Text = _sv.MSSV;
            mssv.Enabled = false;
            name.Text = _sv.FullName;
            cbbbLsh.SelectedItem=DbAdapter.Instance.GetLopSHByID(_sv.ID_LopSH);
            cbbbLsh.Text= DbAdapter.Instance.GetLopSHByID(_sv.ID_LopSH).name;
            NS.Text = _sv.NS.ToString();
            dtb.Text = _sv.DTB.ToString();
            if (_sv.Gender)
            {
                Male.Checked = true;
            }
            else
            {
                Femal.Checked = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (_sv == null)
            {
                SV _svnew = new SV();
                _svnew.MSSV = mssv.Text;
                _svnew.FullName = name.Text;
                _svnew.NS = NS.Value;
                if (Femal.Checked)
                {
                    _svnew.Gender = false;
                }
                else
                {
                    _svnew.Gender = true;
                }
                _svnew.DTB = double.Parse(dtb.Text);
                _svnew.ID_LopSH = ((LopSH)cbbbLsh.SelectedItem).id;
                try
                {
                    string query = "INSERT INTO SV (MSSV, NameSV, DTB, Gender, ID_Lop, NS) " +
                    "VALUES (@MSSV, @NameSV, @DTB, @Gender, @ID_Lop, @NS)";
                    DbAdapter.Instance.saveSV(query, _svnew);
                }catch(Exception ex) {
                    MessageBox.Show("Error: " + ex.Message);
                    return;
                }
                
            }
            else
            {
                _sv.FullName = name.Text;
                _sv.NS = NS.Value;
                if (Femal.Checked)
                {
                    _sv.Gender = false;
                }
                else
                {
                    _sv.Gender = true;
                }
                _sv.DTB = double.Parse(dtb.Text);
                _sv.ID_LopSH = ((LopSH)cbbbLsh.SelectedItem).id;
                string query = "UPDATE SV SET NameSV = @NameSV, DTB = @DTB, Gender = @Gender, ID_Lop = @ID_Lop, NS = @NS WHERE MSSV = @MSSV";
                DbAdapter.Instance.saveSV(query, _sv);
            }
            this.Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
