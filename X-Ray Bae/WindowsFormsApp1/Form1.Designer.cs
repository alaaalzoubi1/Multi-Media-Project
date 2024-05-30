using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageProccingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hueModifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateChannelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heatMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eraseEditingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lBFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hBFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.dateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BrushSize = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.BrushType = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox3 = new System.Windows.Forms.ToolStripComboBox();
            this.ColorizeSelectedArea = new System.Windows.Forms.Button();
            this.OpenImage = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.report = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.share_btn = new System.Windows.Forms.Button();
            this.record_btn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.color_pic = new System.Windows.Forms.Button();
            this.btn_line = new System.Windows.Forms.Button();
            this.btn_rect = new System.Windows.Forms.Button();
            this.btn_ellipse = new System.Windows.Forms.Button();
            this.btn_eraser = new System.Windows.Forms.Button();
            this.btn_pencil = new System.Windows.Forms.Button();
            this.btn_fill = new System.Windows.Forms.Button();
            this.btn_color = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.text_btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_tri = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.fileToolStripMenuItem, this.imageProccingToolStripMenuItem, this.actionToolStripMenuItem, this.compareToolStripMenuItem });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1395, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.openToolStripMenuItem, this.exitToolStripMenuItem, this.saveToolStripMenuItem });
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.openToolStripMenuItem.Text = "open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.exitToolStripMenuItem.Text = "exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.saveToolStripMenuItem.Text = "save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // imageProccingToolStripMenuItem
            // 
            this.imageProccingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.spareToolStripMenuItem, this.hueModifierToolStripMenuItem, this.rotateChannelsToolStripMenuItem, this.invertToolStripMenuItem, this.heatMapToolStripMenuItem, this.eraseEditingToolStripMenuItem, this.lBFToolStripMenuItem, this.hBFToolStripMenuItem });
            this.imageProccingToolStripMenuItem.Name = "imageProccingToolStripMenuItem";
            this.imageProccingToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
            this.imageProccingToolStripMenuItem.Text = "imageProcessing";
            // 
            // spareToolStripMenuItem
            // 
            this.spareToolStripMenuItem.Name = "spareToolStripMenuItem";
            this.spareToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.spareToolStripMenuItem.Text = "Sepia";
            this.spareToolStripMenuItem.Click += new System.EventHandler(this.spareToolStripMenuItem_Click);
            // 
            // hueModifierToolStripMenuItem
            // 
            this.hueModifierToolStripMenuItem.Name = "hueModifierToolStripMenuItem";
            this.hueModifierToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.hueModifierToolStripMenuItem.Text = "HueModifier";
            this.hueModifierToolStripMenuItem.Click += new System.EventHandler(this.hueModifierToolStripMenuItem_Click);
            // 
            // rotateChannelsToolStripMenuItem
            // 
            this.rotateChannelsToolStripMenuItem.Name = "rotateChannelsToolStripMenuItem";
            this.rotateChannelsToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.rotateChannelsToolStripMenuItem.Text = "RotateChannels";
            this.rotateChannelsToolStripMenuItem.Click += new System.EventHandler(this.rotateChannelsToolStripMenuItem_Click);
            // 
            // invertToolStripMenuItem
            // 
            this.invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            this.invertToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.invertToolStripMenuItem.Text = "invert";
            this.invertToolStripMenuItem.Click += new System.EventHandler(this.invertToolStripMenuItem_Click);
            // 
            // heatMapToolStripMenuItem
            // 
            this.heatMapToolStripMenuItem.Name = "heatMapToolStripMenuItem";
            this.heatMapToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.heatMapToolStripMenuItem.Text = "HeatMap";
            this.heatMapToolStripMenuItem.Click += new System.EventHandler(this.heatMapToolStripMenuItem_Click);
            // 
            // eraseEditingToolStripMenuItem
            // 
            this.eraseEditingToolStripMenuItem.Name = "eraseEditingToolStripMenuItem";
            this.eraseEditingToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.eraseEditingToolStripMenuItem.Text = "clear editing";
            this.eraseEditingToolStripMenuItem.Click += new System.EventHandler(this.eraseEditingToolStripMenuItem_Click);
            // 
            // lBFToolStripMenuItem
            // 
            this.lBFToolStripMenuItem.Name = "lBFToolStripMenuItem";
            this.lBFToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.lBFToolStripMenuItem.Text = "LBF";
            this.lBFToolStripMenuItem.Click += new System.EventHandler(this.lBFToolStripMenuItem_Click);
            // 
            // hBFToolStripMenuItem
            // 
            this.hBFToolStripMenuItem.Name = "hBFToolStripMenuItem";
            this.hBFToolStripMenuItem.Size = new System.Drawing.Size(181, 24);
            this.hBFToolStripMenuItem.Text = "HBF";
            this.hBFToolStripMenuItem.Click += new System.EventHandler(this.hBFToolStripMenuItem_Click);
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.selectToolStripMenuItem, this.paintToolStripMenuItem, this.toolStripMenuItem1 });
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.actionToolStripMenuItem.Text = "Action";
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.selectToolStripMenuItem.Text = "select";
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.selectToolStripMenuItem_Click);
            // 
            // paintToolStripMenuItem
            // 
            this.paintToolStripMenuItem.Name = "paintToolStripMenuItem";
            this.paintToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.paintToolStripMenuItem.Text = "paint";
            this.paintToolStripMenuItem.Click += new System.EventHandler(this.paintToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.sizeToolStripMenuItem, this.dateToolStripMenuItem });
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 24);
            this.toolStripMenuItem1.Text = "search";
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.toolStripTextBox1 });
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.sizeToolStripMenuItem.Text = "size";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 27);
            this.toolStripTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox1_KeyDown);
            // 
            // dateToolStripMenuItem
            // 
            this.dateToolStripMenuItem.Name = "dateToolStripMenuItem";
            this.dateToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.dateToolStripMenuItem.Text = "date";
            this.dateToolStripMenuItem.Click += new System.EventHandler(this.dateToolStripMenuItem_Click);
            // 
            // compareToolStripMenuItem
            // 
            this.compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            this.compareToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.compareToolStripMenuItem.Text = "Compare";
            this.compareToolStripMenuItem.Click += new System.EventHandler(this.compareToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.button1.Location = new System.Drawing.Point(337, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "color picker\r\n";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 178);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 690F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1395, 690);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(700, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(692, 684);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseClick);
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(691, 684);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragDrop);
            this.pictureBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragEnter);
            this.pictureBox1.DragOver += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragOver);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint_1);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown_1);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove_1);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.BrushSize, this.toolStripComboBox2, this.BrushType, this.toolStripComboBox3 });
            this.toolStrip1.Location = new System.Drawing.Point(627, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(406, 28);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BrushSize
            // 
            this.BrushSize.Name = "BrushSize";
            this.BrushSize.Size = new System.Drawing.Size(72, 25);
            this.BrushSize.Text = "BrushSize";
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStripComboBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripComboBox2.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" });
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.Size = new System.Drawing.Size(121, 28);
            this.toolStripComboBox2.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox2_SelectedIndexChanged);
            // 
            // BrushType
            // 
            this.BrushType.Name = "BrushType";
            this.BrushType.Size = new System.Drawing.Size(76, 25);
            this.BrushType.Text = "BrushType";
            // 
            // toolStripComboBox3
            // 
            this.toolStripComboBox3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStripComboBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripComboBox3.Items.AddRange(new object[] { "Round", "Square", "Triangle", "Star" });
            this.toolStripComboBox3.Name = "toolStripComboBox3";
            this.toolStripComboBox3.Size = new System.Drawing.Size(121, 28);
            this.toolStripComboBox3.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox3_SelectedIndexChanged);
            // 
            // ColorizeSelectedArea
            // 
            this.ColorizeSelectedArea.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ColorizeSelectedArea.Location = new System.Drawing.Point(159, 28);
            this.ColorizeSelectedArea.Name = "ColorizeSelectedArea";
            this.ColorizeSelectedArea.Size = new System.Drawing.Size(172, 28);
            this.ColorizeSelectedArea.TabIndex = 4;
            this.ColorizeSelectedArea.Text = "Colorize Selected Area";
            this.ColorizeSelectedArea.UseVisualStyleBackColor = false;
            this.ColorizeSelectedArea.Click += new System.EventHandler(this.ColorizeSelectedArea_Click);
            // 
            // OpenImage
            // 
            this.OpenImage.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.OpenImage.Location = new System.Drawing.Point(0, 28);
            this.OpenImage.Name = "OpenImage";
            this.OpenImage.Size = new System.Drawing.Size(153, 28);
            this.OpenImage.TabIndex = 5;
            this.OpenImage.Text = "Open Image";
            this.OpenImage.UseVisualStyleBackColor = false;
            this.OpenImage.Click += new System.EventHandler(this.OpenImage_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.InactiveCaption;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(496, 31);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(1);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 22);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.report);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.share_btn);
            this.panel1.Controls.Add(this.record_btn);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.color_pic);
            this.panel1.Location = new System.Drawing.Point(3, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1392, 111);
            this.panel1.TabIndex = 7;
            // 
            // report
            // 
            this.report.BackColor = System.Drawing.Color.SteelBlue;
            this.report.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.report.FlatAppearance.BorderSize = 0;
            this.report.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.report.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.report.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.report.ForeColor = System.Drawing.Color.Black;
            this.report.Image = ((System.Drawing.Image)(resources.GetObject("report.Image")));
            this.report.Location = new System.Drawing.Point(472, 6);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(50, 51);
            this.report.TabIndex = 12;
            this.report.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.report.UseVisualStyleBackColor = false;
            this.report.Click += new System.EventHandler(this.report_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(3, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 77);
            this.button3.TabIndex = 11;
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // share_btn
            // 
            this.share_btn.BackColor = System.Drawing.Color.SteelBlue;
            this.share_btn.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.share_btn.FlatAppearance.BorderSize = 0;
            this.share_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.share_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.share_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.share_btn.ForeColor = System.Drawing.Color.Black;
            this.share_btn.Image = ((System.Drawing.Image)(resources.GetObject("share_btn.Image")));
            this.share_btn.Location = new System.Drawing.Point(528, 6);
            this.share_btn.Name = "share_btn";
            this.share_btn.Size = new System.Drawing.Size(50, 51);
            this.share_btn.TabIndex = 11;
            this.share_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.share_btn.UseVisualStyleBackColor = false;
            this.share_btn.Click += new System.EventHandler(this.share_btn_Click);
            // 
            // record_btn
            // 
            this.record_btn.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.record_btn.FlatAppearance.BorderSize = 0;
            this.record_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.record_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.record_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.record_btn.ForeColor = System.Drawing.Color.White;
            this.record_btn.Image = ((System.Drawing.Image)(resources.GetObject("record_btn.Image")));
            this.record_btn.Location = new System.Drawing.Point(595, 6);
            this.record_btn.Name = "record_btn";
            this.record_btn.Size = new System.Drawing.Size(50, 51);
            this.record_btn.TabIndex = 11;
            this.record_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.record_btn.UseVisualStyleBackColor = true;
            this.record_btn.Click += new System.EventHandler(this.record_btn_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(1272, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // color_pic
            // 
            this.color_pic.BackColor = System.Drawing.Color.WhiteSmoke;
            this.color_pic.Location = new System.Drawing.Point(744, 9);
            this.color_pic.Name = "color_pic";
            this.color_pic.Size = new System.Drawing.Size(55, 48);
            this.color_pic.TabIndex = 1;
            this.color_pic.UseVisualStyleBackColor = false;
            // 
            // btn_line
            // 
            this.btn_line.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btn_line.FlatAppearance.BorderSize = 0;
            this.btn_line.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btn_line.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.btn_line.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_line.ForeColor = System.Drawing.Color.White;
            this.btn_line.Image = ((System.Drawing.Image)(resources.GetObject("btn_line.Image")));
            this.btn_line.Location = new System.Drawing.Point(174, 3);
            this.btn_line.Name = "btn_line";
            this.btn_line.Size = new System.Drawing.Size(50, 54);
            this.btn_line.TabIndex = 7;
            this.btn_line.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_line.UseVisualStyleBackColor = true;
            this.btn_line.Click += new System.EventHandler(this.btn_line_Click);
            // 
            // btn_rect
            // 
            this.btn_rect.AutoEllipsis = true;
            this.btn_rect.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btn_rect.FlatAppearance.BorderSize = 0;
            this.btn_rect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btn_rect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.btn_rect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_rect.ForeColor = System.Drawing.Color.White;
            this.btn_rect.Image = ((System.Drawing.Image)(resources.GetObject("btn_rect.Image")));
            this.btn_rect.Location = new System.Drawing.Point(118, 3);
            this.btn_rect.Name = "btn_rect";
            this.btn_rect.Size = new System.Drawing.Size(50, 51);
            this.btn_rect.TabIndex = 6;
            this.btn_rect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_rect.UseVisualStyleBackColor = true;
            this.btn_rect.Click += new System.EventHandler(this.btn_rect_Click);
            // 
            // btn_ellipse
            // 
            this.btn_ellipse.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btn_ellipse.FlatAppearance.BorderSize = 0;
            this.btn_ellipse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btn_ellipse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.btn_ellipse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ellipse.ForeColor = System.Drawing.Color.White;
            this.btn_ellipse.Image = ((System.Drawing.Image)(resources.GetObject("btn_ellipse.Image")));
            this.btn_ellipse.Location = new System.Drawing.Point(62, 3);
            this.btn_ellipse.Name = "btn_ellipse";
            this.btn_ellipse.Size = new System.Drawing.Size(50, 51);
            this.btn_ellipse.TabIndex = 5;
            this.btn_ellipse.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_ellipse.UseVisualStyleBackColor = true;
            this.btn_ellipse.Click += new System.EventHandler(this.btn_ellipse_Click_1);
            // 
            // btn_eraser
            // 
            this.btn_eraser.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btn_eraser.FlatAppearance.BorderSize = 0;
            this.btn_eraser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btn_eraser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.btn_eraser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eraser.ForeColor = System.Drawing.Color.White;
            this.btn_eraser.Image = ((System.Drawing.Image)(resources.GetObject("btn_eraser.Image")));
            this.btn_eraser.Location = new System.Drawing.Point(342, 3);
            this.btn_eraser.Name = "btn_eraser";
            this.btn_eraser.Size = new System.Drawing.Size(49, 51);
            this.btn_eraser.TabIndex = 4;
            this.btn_eraser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_eraser.UseVisualStyleBackColor = true;
            this.btn_eraser.Click += new System.EventHandler(this.btn_eraser_Click);
            // 
            // btn_pencil
            // 
            this.btn_pencil.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btn_pencil.FlatAppearance.BorderSize = 0;
            this.btn_pencil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btn_pencil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.btn_pencil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pencil.ForeColor = System.Drawing.Color.White;
            this.btn_pencil.Image = ((System.Drawing.Image)(resources.GetObject("btn_pencil.Image")));
            this.btn_pencil.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_pencil.Location = new System.Drawing.Point(397, -3);
            this.btn_pencil.Name = "btn_pencil";
            this.btn_pencil.Size = new System.Drawing.Size(63, 70);
            this.btn_pencil.TabIndex = 3;
            this.btn_pencil.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_pencil.UseVisualStyleBackColor = true;
            this.btn_pencil.Click += new System.EventHandler(this.btn_pencil_Click);
            // 
            // btn_fill
            // 
            this.btn_fill.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btn_fill.FlatAppearance.BorderSize = 0;
            this.btn_fill.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btn_fill.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.btn_fill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_fill.ForeColor = System.Drawing.Color.White;
            this.btn_fill.Image = ((System.Drawing.Image)(resources.GetObject("btn_fill.Image")));
            this.btn_fill.Location = new System.Drawing.Point(282, 3);
            this.btn_fill.Name = "btn_fill";
            this.btn_fill.Size = new System.Drawing.Size(54, 54);
            this.btn_fill.TabIndex = 2;
            this.btn_fill.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_fill.UseVisualStyleBackColor = true;
            this.btn_fill.Click += new System.EventHandler(this.btn_fill_Click);
            // 
            // btn_color
            // 
            this.btn_color.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btn_color.FlatAppearance.BorderSize = 0;
            this.btn_color.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btn_color.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.btn_color.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_color.ForeColor = System.Drawing.Color.White;
            this.btn_color.Image = ((System.Drawing.Image)(resources.GetObject("btn_color.Image")));
            this.btn_color.Location = new System.Drawing.Point(230, 3);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(59, 54);
            this.btn_color.TabIndex = 1;
            this.btn_color.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_color.UseVisualStyleBackColor = true;
            this.btn_color.Click += new System.EventHandler(this.btn_color_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CadetBlue;
            this.panel2.Controls.Add(this.text_btn);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.btn_tri);
            this.panel2.Controls.Add(this.btn_line);
            this.panel2.Controls.Add(this.btn_pencil);
            this.panel2.Controls.Add(this.btn_color);
            this.panel2.Controls.Add(this.btn_rect);
            this.panel2.Controls.Add(this.btn_ellipse);
            this.panel2.Controls.Add(this.btn_eraser);
            this.panel2.Controls.Add(this.btn_fill);
            this.panel2.Location = new System.Drawing.Point(808, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(587, 57);
            this.panel2.TabIndex = 8;
            // 
            // text_btn
            // 
            this.text_btn.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.text_btn.FlatAppearance.BorderSize = 0;
            this.text_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.text_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.text_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.text_btn.ForeColor = System.Drawing.Color.White;
            this.text_btn.Image = ((System.Drawing.Image)(resources.GetObject("text_btn.Image")));
            this.text_btn.Location = new System.Drawing.Point(534, 3);
            this.text_btn.Name = "text_btn";
            this.text_btn.Size = new System.Drawing.Size(50, 51);
            this.text_btn.TabIndex = 10;
            this.text_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.text_btn.UseVisualStyleBackColor = true;
            this.text_btn.Click += new System.EventHandler(this.text_btn_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(465, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 51);
            this.button2.TabIndex = 9;
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_tri
            // 
            this.btn_tri.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btn_tri.FlatAppearance.BorderSize = 0;
            this.btn_tri.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btn_tri.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.btn_tri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tri.ForeColor = System.Drawing.Color.White;
            this.btn_tri.Image = ((System.Drawing.Image)(resources.GetObject("btn_tri.Image")));
            this.btn_tri.Location = new System.Drawing.Point(6, 3);
            this.btn_tri.Name = "btn_tri";
            this.btn_tri.Size = new System.Drawing.Size(50, 51);
            this.btn_tri.TabIndex = 8;
            this.btn_tri.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_tri.UseVisualStyleBackColor = true;
            this.btn_tri.Click += new System.EventHandler(this.btn_tri_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.SteelBlue;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PowderBlue;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(416, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 51);
            this.button4.TabIndex = 13;
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1395, 822);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.OpenImage);
            this.Controls.Add(this.ColorizeSelectedArea);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "X-Ray Bae";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button4;

        private System.Windows.Forms.Button report;

        private System.Windows.Forms.Button button3;

        private System.Windows.Forms.Button share_btn;

        private System.Windows.Forms.Button record_btn;

        private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.Button text_btn;

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Button btn_tri;

        private System.Windows.Forms.Button color_pic;

        private System.Windows.Forms.Panel panel2;

        private System.Windows.Forms.Button btn_rect;

        private System.Windows.Forms.Button btn_line;

        private System.Windows.Forms.Button btn_ellipse;

        private System.Windows.Forms.Button btn_eraser;

        private System.Windows.Forms.Button btn_pencil;

        private System.Windows.Forms.Button btn_color;

        private System.Windows.Forms.Button btn_fill;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.ToolStripMenuItem lBFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hBFToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem compareToolStripMenuItem;

        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;

        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;

        private System.Windows.Forms.DateTimePicker dateTimePicker1;

        private System.Windows.Forms.ToolStripMenuItem dateToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;

        private System.Windows.Forms.ToolStripMenuItem heatMapToolStripMenuItem;

        private System.Windows.Forms.Button OpenImage;

        private System.Windows.Forms.Button ColorizeSelectedArea;

        private System.Windows.Forms.ToolStripLabel BrushSize;
        private System.Windows.Forms.ToolStripLabel BrushType;

        private System.Windows.Forms.ToolStripComboBox toolStripComboBox3;

        private System.Windows.Forms.ToolStripComboBox toolStripComboBox2;

        

        private System.Windows.Forms.ToolStrip toolStrip1;

        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paintToolStripMenuItem;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem rotateChannelsToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem hueModifierToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem eraseEditingToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem spareToolStripMenuItem;

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageProccingToolStripMenuItem;

        #endregion
    }
}