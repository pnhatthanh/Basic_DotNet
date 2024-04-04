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
        private void dataform2()
        {
            mssv.Text = _sv.MSSV;
            mssv.Enabled = false;
            name.Text = _sv.FullName;
            cbbLsh.Text = _sv.LopSH;
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
        private void setLSH()
        {
            List<string> lsh = new List<string>();
            foreach (SV i in CSDL.Instance.getAllSV())
            {
                lsh.Add(i.LopSH);
            }
            cbbLsh.Items.AddRange(lsh.Distinct().ToArray());
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
                _svnew.LopSH = cbbLsh.SelectedItem.ToString();
                CSDL.Instance.addSV(_svnew);
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
                _sv.LopSH = cbbLsh.SelectedItem.ToString();
                CSDL.Instance.editSV(_sv);
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
