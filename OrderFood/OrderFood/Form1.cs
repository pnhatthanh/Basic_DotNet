using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderFood
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            setTableName();
            
        }

        private void setTableName()
        {
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.Items.Add("4");
            comboBox1.Items.Add("5");
        }

        private void ClickItem(object sender, EventArgs e)
        {
            Button b=sender as Button;
            List<Order> orders=dataGridView1.DataSource as List<Order>;
            if(orders != null )
            {
                for( int i=0;i<orders.Count;i++ )
                {
                    if (orders[i].FoodName==b.Text )
                    {
                        orders[i].Quantity += 1;
                        CSDL.Instance.SaveOrder(orders[i]);
                        RefershDataView();
                        return;
                    }
                }
                CSDL.Instance.AddOrder(new Order
                {
                    TableName = comboBox1.Text,
                    FoodName = b.Text,
                    Quantity=1
                });
                RefershDataView();
            }
        }
        private void RefershDataView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = CSDL.Instance.getOrdersByTableName(comboBox1.Text);
            dataGridView1.Columns["TableName"].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Món ăn";
            dataGridView1.Columns[2].HeaderText = "Số lượng";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefershDataView();
        }

        private void del_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                foreach( DataGridViewRow d in dataGridView1.SelectedRows)
                {
                    CSDL.Instance.DeleteOrder(new Order
                    {
                        TableName = d.Cells["TableName"].Value.ToString(),
                        FoodName = d.Cells["FoodName"].Value.ToString(),
                    });
                }
                RefershDataView();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Order thành công");
        }
    }
}
