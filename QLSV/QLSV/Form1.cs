using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public delegate void dataBinding(SV s);
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            setLSH();
    
        }
        private void setLSH()
        {
            List<string> lsh=new List<string>();
            foreach(SV i in CSDL.Instance.getAllSV())
            {
                lsh.Add(i.LopSH);
            }
            cbbLsh.Items.AddRange(lsh.Distinct().ToArray());
            cbbLsh.Items.Add("All");
        }
        private List<SV> getSVBySearch()
        {
            List<SV> data = new List<SV>();
            string lsh = cbbLsh.SelectedItem.ToString();
            string name = searcch_box.Text;
            foreach (SV sv in CSDL.Instance.getAllSV())
            {
                if (lsh == "All")
                {
                    if (sv.FullName.Contains(name))
                    {
                        data.Add(sv);
                    }
                }
                else
                {
                    if (sv.FullName.Contains(name) && sv.LopSH == lsh)
                    {
                        data.Add(sv);
                    }
                }
            }
            return data;
        }
        public void RefreshDGV()
        {
            data_view.DataSource = getSVBySearch();
        }

        private void search_button_Click(object sender, EventArgs e)
        {

            data_view.DataSource = getSVBySearch();
        }

        private void sortItem()
        {
            List<string> list = new List<string>();
            foreach(DataGridViewColumn col in data_view.Columns)
            {
                string columnName = col.Name;
                list.Add(columnName);
            }
            cbbItem.Items.AddRange(list.Distinct().ToArray());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2=new Form2();
            form2.Show();
            form2.FormClosed += Form2_FormClosed;
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshDGV();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (data_view.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in data_view.SelectedRows)
                {
                    SV sv = CSDL.Instance.findSV(row.Cells[0].Value.ToString());
                    Form2 f2=new Form2(sv);
                    f2.Show();
                    f2.FormClosed += Form2_FormClosed;
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if(data_view.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow row in data_view.SelectedRows)
                {
                    string mssv = row.Cells[0].Value.ToString();
                    CSDL.Instance.removeSV(mssv);
                }
            }
            RefreshDGV();
        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            string sort = cbbItem.SelectedItem.ToString();
            List<SV> dataList = new List<SV>(data_view.DataSource as List<SV>);
            switch (sort)
            {
                case "MSSV":
                    dataList = dataList.OrderBy(sv => sv.MSSV).ToList();
                    break;
                case "FullName":
                    dataList = dataList.OrderBy(sv => sv.FullName).ToList();
                    break;
                case "LopSH":
                    dataList = dataList.OrderBy(sv => sv.LopSH).ToList();
                    break;
                case "NS":
                    dataList = dataList.OrderBy(sv => sv.NS).ToList();
                    break;
                case "Gender":
                    dataList = dataList.OrderBy(sv => sv.Gender).ToList();
                    break;
                case "DTB":
                    dataList = dataList.OrderBy(sv => sv.DTB).ToList();
                    break;
            }
            data_view.DataSource = dataList;
        }
    }
}
