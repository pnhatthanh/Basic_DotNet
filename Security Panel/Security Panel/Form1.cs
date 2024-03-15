using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Security_Panel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (password.Text.Length == 4)
            {
                button4.Enabled = true;
            }
            else
            {
                button4.Enabled = false;   
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader rd = new StreamReader(@"..\\..\\access_log.txt");
            string line;
            while ((line = rd.ReadLine()) != null)
            {
                access_log.Items.Add(line);
            }
            rd.Close();
        }
        private void ClickButton(object sender, EventArgs e) {
            Button button = (Button)sender;
            
            if (button.Text == "C")
            {
                password.Clear();
            }else if(button.Text == "E") {

                string text;
                if (password.Text == "1234")
                {
                    text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt") + "     Thanh cong";
                    access_log.Items.Add(text);
                }
                else
                {
                    text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt") + "     That bai";
                    access_log.Items.Add(text);
                }
                StreamWriter writer = new StreamWriter(@"..\\..\\access_log.txt", true);
                writer.WriteLine(text);
                writer.Close();
                
            }
            else
            {
                if (password.Text.Length < 4)
                {
                    password.Text += button.Text;
                }
            }
        }

    }
}
