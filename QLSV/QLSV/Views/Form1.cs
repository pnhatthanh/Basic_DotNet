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
using QLSV.DAL;
using QLSV.DTO;

namespace QLSV.Views
{
    public partial class Form1 : Form
    {   
        private QLSV ql=new QLSV();
        public Form1()
        {
            InitializeComponent();
            setLSH();
    
        }
        public void setLSH()
        {
            cbbLsh.Items.AddRange(ql.getCBB().ToArray());
        }
        public void RefreshDGV()
        {
            if(cbbLsh.SelectedItem == null) {
                MessageBox.Show("Chua chon lop sinh hoat");
                return;
            }
            int id = ((CbbItem)cbbLsh.SelectedItem).value;
            string name_sv = searcch_box.Text;
            data_view.DataSource = ql.getSVBySearch(id,name_sv);
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
                    SV sv = ql.getSVByID(id_sv);
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
                    ql.deleteSVByID(mssv);
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
                string criteria = cbbItem.SelectedItem.ToString();
                int id = ((CbbItem)cbbLsh.SelectedItem).value;
                string name_sv = searcch_box.Text;
                data_view.DataSource = ql.sortSV(ql.getSVBySearch(id, name_sv),criteria);
            }
        }
    }
}
