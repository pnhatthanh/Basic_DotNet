using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadData();
        }
        private void loadData()
        {
            dataGridView1.DataSource = DbHelper.Instance.loadAppointment(1);
            dataGridView1.Columns["AppointmentId"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            form.FormClosed += Form2_FormClosed;
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadData();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int appointmentID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                dataGridView2.DataSource = DbHelper.Instance.loadReminders(appointmentID);
                dataGridView2.Columns["ReminderId"].Visible = false;
            }
            
        }
    }
}
