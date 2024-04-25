using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            cbbLsh.Items.AddRange(li.ToArray());
        }
        public void RefreshDGV()
        {
            if(cbbLsh.SelectedItem == null) {
                MessageBox.Show("Chua chon lop sinh hoat");
                return;
            }
            int id = ((LopSH)cbbLsh.SelectedItem).id;
            string name_sv = searcch_box.Text;
            string query = "";
            if (id == 0)
            {
                query = "select * from SV where NameSV like '%" + name_sv + "%'";
            }
            else
            {
                query = "select * from SV where" +
                    " ID_Lop=" + id+"and NameSV like '%"+name_sv+"%'";
            }
            data_view.DataSource = DbAdapter.Instance.GetRecord(query);
        }
        private void search_button_Click(object sender, EventArgs e)
        {
            RefreshDGV();
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
                    string id_sv = row.Cells[0].Value.ToString();
                    string query = "select *from SV where MSSV=@MSSV";
                    SV sv = DbAdapter.Instance.getSVByID(query,id_sv);
                    Form2 f2 = new Form2(sv);
                    f2.Show();
                    f2.FormClosed += Form2_FormClosed;
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn sinh viên");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (data_view.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in data_view.SelectedRows)
                {
                    string mssv = row.Cells[0].Value.ToString();
                    string query = "delete from SV Where MSSV= '" + mssv+"'";
                    DbAdapter.Instance.ExecuteDb(query);
                }
            }
            RefreshDGV();
        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            if (cbbItem.SelectedItem == null)
            {
                MessageBox.Show("Chọn diệu kiện sắp xếp");
                return;
            }
            else
            {
                int id = ((LopSH)cbbLsh.SelectedItem).id;
                string name_sv = searcch_box.Text;
                string criteria = cbbItem.SelectedItem.ToString();
                string query = "";
                if (id == 0)
                {
                     query = "select * from SV where NameSV like '%" + name_sv + "%'" +
                    "Order By " + criteria + " ASC";
                }
                else
                {
                    query = "select * from SV where" +
                    " ID_Lop=" + id + "and NameSV like '%" + name_sv + "%'" +
                    "Order By " + criteria + " ASC";
                }
                
                data_view.DataSource = DbAdapter.Instance.GetRecord(query);
            }
        }
    }
}
