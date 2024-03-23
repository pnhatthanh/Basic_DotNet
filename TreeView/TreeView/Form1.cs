using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace TreeView
{
    public partial class Form1 : Form
    {
        private string url;
        public Form1()
        {
            InitializeComponent();
        }

        private void open_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "TreeView|*.xml;";
            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                this.url = fileDialog.FileName;
                textBox1.Text = fileDialog.FileName;
                load_file_XML();
            }
        }
        private void load_file_XML()
        {
            try
            {
                string path = textBox1.Text;
                XmlDocument document = new XmlDocument();
                document.Load(path);
                TreeNode root = treeView1.Nodes.Add(document.DocumentElement.Name);
                XmlNodeList childNodes = document.DocumentElement.ChildNodes;
                if(childNodes==null)
                {
                    return;
                }
                else
                {
                    foreach (XmlNode childNode in childNodes)
                    {
                        add_nodes(childNode, root);
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void add_nodes(XmlNode xmlNode, TreeNode treeNode)
        {
            TreeNode node = treeNode.Nodes.Add(xmlNode.Name);
            if (xmlNode.HasChildNodes)
            {
                foreach (XmlNode childNode in xmlNode.ChildNodes)
                {
                    add_nodes(childNode, node);
                }
            }
            else
            {
                node.Text = xmlNode.InnerText;
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
            txt_edit.Text = e.Node.Text;

        }
        private void delete_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode != null)
            {
                treeView1.Nodes.Remove(treeView1.SelectedNode);
            }
            else
            {
                MessageBox.Show("Vui long chon node!");
            }
        }
        private void add_node_Click(object sender, EventArgs e)
        {
            if(treeView1.SelectedNode != null)
            {
                TreeNode node = new TreeNode(txt_add.Text);
                treeView1.SelectedNode.Nodes.Add(node);
            }
            else
            {
                MessageBox.Show("Vui long chon node!");
            }
        }
        private void edit_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.Text=txt_edit.Text;
            }
            else
            {
                MessageBox.Show("Vui long chon node!");
            }
        }

        private void find_Click(object sender, EventArgs e)
        {
            find_nodes(treeView1.Nodes[0]);
        }
        private void find_nodes(TreeNode nodes)
        {
            foreach (TreeNode node in nodes.Nodes)
            {
                if (string.Equals(txt_find.Text, node.Text))
                {
                    node.EnsureVisible();
                    node.BackColor = Color.Yellow;
                }
                else
                {
                    node.BackColor = Color.White;
                }
                if(nodes.Nodes.Count > 0)
                {
                    find_nodes(node);
                }
            }
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            txt_find.Text = null;
            find.PerformClick();
        }

        private void save_Click(object sender, EventArgs e)
        {
            using(XmlTextWriter xtw = new XmlTextWriter(url, null))
            {
                xtw.Formatting = Formatting.Indented;
                xtw.WriteStartDocument();
                writeNode(treeView1.Nodes, xtw);
                xtw.WriteEndDocument();
            }
        }
        private void writeNode(TreeNodeCollection nodes, XmlTextWriter xtw)
        {
            foreach (TreeNode node in nodes)
            {
                if(node.Nodes.Count > 0)
                {
                    xtw.WriteStartElement(node.Text);
                    if (node.Nodes.Count > 0)
                    {
                        writeNode(node.Nodes, xtw);
                    }
                    xtw.WriteEndElement();
                }
                else
                {
                    xtw.WriteValue(node.Text);
                }
            }
        }
    }
}
