using System.ComponentModel;

namespace WindowsFormsApp1
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Button1 = new System.Windows.Forms.Button();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.button2 = new System.Windows.Forms.Button();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripSplitButton();
            this.skullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lungsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teethToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limpsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(224, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(312, 408);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(568, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(312, 408);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Button1.Location = new System.Drawing.Point(18, 26);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(124, 34);
            this.Button1.TabIndex = 2;
            this.Button1.Text = "Compare";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(23, 23);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button2.Location = new System.Drawing.Point(18, 78);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "Evaluate";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(23, 23);
            this.toolStripDropDownButton2.Text = "toolStripDropDownButton2";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.toolStripComboBox1, this.toolStripSeparator1 });
            this.toolStrip1.Location = new System.Drawing.Point(18, 130);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(106, 27);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolStripComboBox1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.skullToolStripMenuItem, this.lungsToolStripMenuItem, this.teethToolStripMenuItem, this.limpsToolStripMenuItem });
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(88, 24);
            this.toolStripComboBox1.Text = "Body Part";
            // 
            // skullToolStripMenuItem
            // 
            this.skullToolStripMenuItem.Name = "skullToolStripMenuItem";
            this.skullToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.skullToolStripMenuItem.Text = "skull";
            this.skullToolStripMenuItem.Click += new System.EventHandler(this.skullToolStripMenuItem_Click);
            // 
            // lungsToolStripMenuItem
            // 
            this.lungsToolStripMenuItem.Name = "lungsToolStripMenuItem";
            this.lungsToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.lungsToolStripMenuItem.Text = "lungs";
            this.lungsToolStripMenuItem.Click += new System.EventHandler(this.lungsToolStripMenuItem_Click);
            // 
            // teethToolStripMenuItem
            // 
            this.teethToolStripMenuItem.Name = "teethToolStripMenuItem";
            this.teethToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.teethToolStripMenuItem.Text = "teeth";
            this.teethToolStripMenuItem.Click += new System.EventHandler(this.teethToolStripMenuItem_Click);
            // 
            // limpsToolStripMenuItem
            // 
            this.limpsToolStripMenuItem.Name = "limpsToolStripMenuItem";
            this.limpsToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.limpsToolStripMenuItem.Text = "limps";
            this.limpsToolStripMenuItem.Click += new System.EventHandler(this.limpsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button3.Location = new System.Drawing.Point(18, 179);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 32);
            this.button3.TabIndex = 5;
            this.button3.Text = "crop";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(892, 531);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form2";
            this.Text = "Compare";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button3;

        private System.Windows.Forms.ToolStripMenuItem skullToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lungsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teethToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem limpsToolStripMenuItem;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

        private System.Windows.Forms.ToolStripSplitButton toolStripComboBox1;

        private System.Windows.Forms.ToolStrip toolStrip1;

        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;

        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Button Button1;

        private System.Windows.Forms.OpenFileDialog openFileDialog1;

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;

        #endregion
    }
}