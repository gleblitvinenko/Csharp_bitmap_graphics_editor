namespace Csharp_bitmap_graphics_editor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            button12 = new Button();
            button11 = new Button();
            button10 = new Button();
            button9 = new Button();
            button8 = new Button();
            button7 = new Button();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            panel2 = new Panel();
            label1 = new Label();
            trackBar1 = new TrackBar();
            colorDialog1 = new ColorDialog();
            saveFileDialog1 = new SaveFileDialog();
            panel3 = new Panel();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            clearToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            pasteCTRLVToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            panel3.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 422);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(button12);
            panel1.Controls.Add(button11);
            panel1.Controls.Add(button10);
            panel1.Controls.Add(button9);
            panel1.Controls.Add(button8);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(201, 125);
            panel1.TabIndex = 3;
            // 
            // button12
            // 
            button12.BackColor = Color.White;
            button12.Location = new Point(150, 48);
            button12.Name = "button12";
            button12.Size = new Size(30, 30);
            button12.TabIndex = 9;
            button12.UseVisualStyleBackColor = false;
            button12.Click += button12_Click;
            // 
            // button11
            // 
            button11.BackColor = Color.Black;
            button11.FlatStyle = FlatStyle.Flat;
            button11.Location = new Point(114, 48);
            button11.Name = "button11";
            button11.Size = new Size(30, 30);
            button11.TabIndex = 8;
            button11.UseVisualStyleBackColor = false;
            button11.Click += button3_Click;
            // 
            // button10
            // 
            button10.BackColor = Color.Blue;
            button10.FlatStyle = FlatStyle.Flat;
            button10.Location = new Point(78, 48);
            button10.Name = "button10";
            button10.Size = new Size(30, 30);
            button10.TabIndex = 7;
            button10.UseVisualStyleBackColor = false;
            button10.Click += button3_Click;
            // 
            // button9
            // 
            button9.BackColor = Color.Cyan;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Location = new Point(42, 48);
            button9.Name = "button9";
            button9.Size = new Size(30, 30);
            button9.TabIndex = 6;
            button9.UseVisualStyleBackColor = false;
            button9.Click += button3_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.Lime;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Location = new Point(6, 48);
            button8.Name = "button8";
            button8.Size = new Size(30, 30);
            button8.TabIndex = 5;
            button8.UseVisualStyleBackColor = false;
            button8.Click += button3_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(192, 0, 192);
            button7.FlatStyle = FlatStyle.Flat;
            button7.Location = new Point(150, 12);
            button7.Name = "button7";
            button7.Size = new Size(30, 30);
            button7.TabIndex = 4;
            button7.UseVisualStyleBackColor = false;
            button7.Click += button3_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.Yellow;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Location = new Point(114, 12);
            button6.Name = "button6";
            button6.Size = new Size(30, 30);
            button6.TabIndex = 3;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button3_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(255, 128, 0);
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new Point(78, 12);
            button5.Name = "button5";
            button5.Size = new Size(30, 30);
            button5.TabIndex = 2;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Red;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(42, 12);
            button4.Name = "button4";
            button4.Size = new Size(30, 30);
            button4.TabIndex = 1;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button3_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(6, 12);
            button3.Name = "button3";
            button3.Size = new Size(30, 30);
            button3.TabIndex = 0;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(trackBar1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 125);
            panel2.Name = "panel2";
            panel2.Size = new Size(201, 102);
            panel2.TabIndex = 4;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(201, 43);
            label1.TabIndex = 1;
            label1.Text = "Brush thickness";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // trackBar1
            // 
            trackBar1.Dock = DockStyle.Bottom;
            trackBar1.Location = new Point(0, 46);
            trackBar1.Maximum = 20;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(201, 56);
            trackBar1.TabIndex = 0;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel2);
            panel3.Controls.Add(panel1);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(599, 28);
            panel3.Name = "panel3";
            panel3.Size = new Size(201, 422);
            panel3.TabIndex = 5;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, clearToolStripMenuItem, toolStripMenuItem1, undoToolStripMenuItem, redoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(123, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += button1_Click;
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new Size(57, 24);
            clearToolStripMenuItem.Text = "Clear";
            clearToolStripMenuItem.Click += button2_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { pasteCTRLVToolStripMenuItem, copyToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(89, 24);
            toolStripMenuItem1.Text = "ClipBoard";
            // 
            // pasteCTRLVToolStripMenuItem
            // 
            pasteCTRLVToolStripMenuItem.Name = "pasteCTRLVToolStripMenuItem";
            pasteCTRLVToolStripMenuItem.ShortcutKeyDisplayString = "CTRL + V";
            pasteCTRLVToolStripMenuItem.Size = new Size(195, 26);
            pasteCTRLVToolStripMenuItem.Text = "Paste";
            pasteCTRLVToolStripMenuItem.ToolTipText = "CTRL + V";
            pasteCTRLVToolStripMenuItem.Click += pasteCTRLVToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeyDisplayString = "CTRL + C";
            copyToolStripMenuItem.Size = new Size(195, 26);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.ToolTipText = "CTRL + C";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.Size = new Size(59, 24);
            undoToolStripMenuItem.Text = "Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.Size = new Size(58, 24);
            redoToolStripMenuItem.Text = "Redo";
            redoToolStripMenuItem.Click += redoToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel3);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Bitmap grachics editor v1.0.0";
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            panel3.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private Button button3;
        private Button button12;
        private Button button11;
        private Button button10;
        private Button button9;
        private Button button8;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Panel panel2;
        private Label label1;
        private TrackBar trackBar1;
        private ColorDialog colorDialog1;
        private SaveFileDialog saveFileDialog1;
        private Panel panel3;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem pasteCTRLVToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
    }
}