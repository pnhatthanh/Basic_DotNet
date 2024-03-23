namespace TreeView
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.open = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.txt_find = new System.Windows.Forms.TextBox();
            this.add_node = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.find = new System.Windows.Forms.Button();
            this.txt_add = new System.Windows.Forms.TextBox();
            this.txt_edit = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(47, 117);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(455, 255);
            this.treeView1.TabIndex = 0;
            this.treeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseClick);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(63, 47);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(314, 39);
            this.textBox1.TabIndex = 1;
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(398, 47);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(104, 39);
            this.open.TabIndex = 2;
            this.open.Text = "Open";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // save
            // 
            this.save.BackColor = System.Drawing.Color.Yellow;
            this.save.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.save.Location = new System.Drawing.Point(373, 383);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(94, 45);
            this.save.TabIndex = 3;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.Red;
            this.delete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.delete.Location = new System.Drawing.Point(76, 383);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(93, 45);
            this.delete.TabIndex = 4;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // txt_find
            // 
            this.txt_find.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_find.Location = new System.Drawing.Point(520, 147);
            this.txt_find.Multiline = true;
            this.txt_find.Name = "txt_find";
            this.txt_find.Size = new System.Drawing.Size(142, 33);
            this.txt_find.TabIndex = 6;
            // 
            // add_node
            // 
            this.add_node.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.add_node.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.add_node.Location = new System.Drawing.Point(695, 217);
            this.add_node.Name = "add_node";
            this.add_node.Size = new System.Drawing.Size(93, 39);
            this.add_node.TabIndex = 8;
            this.add_node.Text = "Add";
            this.add_node.UseVisualStyleBackColor = false;
            this.add_node.Click += new System.EventHandler(this.add_node_Click);
            // 
            // edit
            // 
            this.edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.edit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.edit.Location = new System.Drawing.Point(695, 286);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(93, 39);
            this.edit.TabIndex = 9;
            this.edit.Text = "Edit";
            this.edit.UseVisualStyleBackColor = false;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // find
            // 
            this.find.BackColor = System.Drawing.Color.Silver;
            this.find.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.find.Location = new System.Drawing.Point(691, 141);
            this.find.Name = "find";
            this.find.Size = new System.Drawing.Size(93, 39);
            this.find.TabIndex = 10;
            this.find.Text = "Find";
            this.find.UseVisualStyleBackColor = false;
            this.find.Click += new System.EventHandler(this.find_Click);
            // 
            // txt_add
            // 
            this.txt_add.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_add.Location = new System.Drawing.Point(520, 223);
            this.txt_add.Multiline = true;
            this.txt_add.Name = "txt_add";
            this.txt_add.Size = new System.Drawing.Size(142, 33);
            this.txt_add.TabIndex = 11;
            // 
            // txt_edit
            // 
            this.txt_edit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_edit.Location = new System.Drawing.Point(520, 292);
            this.txt_edit.Multiline = true;
            this.txt_edit.Name = "txt_edit";
            this.txt_edit.Size = new System.Drawing.Size(142, 33);
            this.txt_edit.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 452);
            this.Controls.Add(this.txt_edit);
            this.Controls.Add(this.txt_add);
            this.Controls.Add(this.find);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.add_node);
            this.Controls.Add(this.txt_find);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.save);
            this.Controls.Add(this.open);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.TextBox txt_find;
        private System.Windows.Forms.Button add_node;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button find;
        private System.Windows.Forms.TextBox txt_add;
        private System.Windows.Forms.TextBox txt_edit;
    }
}

