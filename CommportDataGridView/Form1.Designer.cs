namespace FaulhaberMotTest_V
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
        	this.components = new System.ComponentModel.Container();
        	this.menuStrip1 = new System.Windows.Forms.MenuStrip();
        	this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
        	this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.statusStrip1 = new System.Windows.Forms.StatusStrip();
        	this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
        	this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
        	this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
        	this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
        	this.timer2 = new System.Windows.Forms.Timer(this.components);
        	this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        	this.tabPage4 = new System.Windows.Forms.TabPage();
        	this.groupBox4 = new System.Windows.Forms.GroupBox();
        	this.txtReceiveV = new System.Windows.Forms.TextBox();
        	this.btnPause = new System.Windows.Forms.Button();
        	this.btnDateiNeu = new System.Windows.Forms.Button();
        	this.dataGridView1 = new System.Windows.Forms.DataGridView();
        	this.label4 = new System.Windows.Forms.Label();
        	this.comboBox2 = new System.Windows.Forms.ComboBox();
        	this.checkBox1 = new System.Windows.Forms.CheckBox();
        	this.label2 = new System.Windows.Forms.Label();
        	this.btnStartDrehzahlVersuch = new System.Windows.Forms.Button();
        	this.tabPage3 = new System.Windows.Forms.TabPage();
        	this.groupBox3 = new System.Windows.Forms.GroupBox();
        	this.comboBox3 = new System.Windows.Forms.ComboBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.btnOpen = new System.Windows.Forms.Button();
        	this.comboBox1 = new System.Windows.Forms.ComboBox();
        	this.tabControl1 = new System.Windows.Forms.TabControl();
        	this.menuStrip1.SuspendLayout();
        	this.statusStrip1.SuspendLayout();
        	this.tabPage4.SuspendLayout();
        	this.groupBox4.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
        	this.tabPage3.SuspendLayout();
        	this.groupBox3.SuspendLayout();
        	this.tabControl1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// menuStrip1
        	// 
        	this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.dateiToolStripMenuItem,
			this.infoToolStripMenuItem});
        	this.menuStrip1.Location = new System.Drawing.Point(0, 0);
        	this.menuStrip1.Name = "menuStrip1";
        	this.menuStrip1.Size = new System.Drawing.Size(784, 24);
        	this.menuStrip1.TabIndex = 0;
        	this.menuStrip1.Text = "menuStrip1";
        	// 
        	// dateiToolStripMenuItem
        	// 
        	this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.loadToolStripMenuItem1,
			this.beendenToolStripMenuItem});
        	this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
        	this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
        	this.dateiToolStripMenuItem.Text = "Datei";
        	// 
        	// loadToolStripMenuItem1
        	// 
        	this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
        	this.loadToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
        	this.loadToolStripMenuItem1.Text = "Load";
        	this.loadToolStripMenuItem1.Click += new System.EventHandler(this.loadToolStripMenuItem1_Click);
        	// 
        	// beendenToolStripMenuItem
        	// 
        	this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
        	this.beendenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
        	this.beendenToolStripMenuItem.Text = "Exit";
        	this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
        	// 
        	// infoToolStripMenuItem
        	// 
        	this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.aboutToolStripMenuItem});
        	this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
        	this.infoToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
        	this.infoToolStripMenuItem.Text = "Hilfe";
        	// 
        	// aboutToolStripMenuItem
        	// 
        	this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        	this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
        	this.aboutToolStripMenuItem.Text = "About";
        	this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
        	// 
        	// statusStrip1
        	// 
        	this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripStatusLabel1,
			this.toolStripStatusLabel2,
			this.toolStripStatusLabel3});
        	this.statusStrip1.Location = new System.Drawing.Point(0, 540);
        	this.statusStrip1.Name = "statusStrip1";
        	this.statusStrip1.Size = new System.Drawing.Size(784, 22);
        	this.statusStrip1.TabIndex = 2;
        	this.statusStrip1.Text = "statusStrip1";
        	// 
        	// toolStripStatusLabel1
        	// 
        	this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
        	this.toolStripStatusLabel1.Size = new System.Drawing.Size(31, 17);
        	this.toolStripStatusLabel1.Text = "Stop";
        	// 
        	// toolStripStatusLabel2
        	// 
        	this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
        	this.toolStripStatusLabel2.Size = new System.Drawing.Size(38, 17);
        	this.toolStripStatusLabel2.Text = "Step=";
        	// 
        	// toolStripStatusLabel3
        	// 
        	this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
        	this.toolStripStatusLabel3.Size = new System.Drawing.Size(13, 17);
        	this.toolStripStatusLabel3.Text = "0";
        	// 
        	// timer2
        	// 
        	this.timer2.Enabled = true;
        	this.timer2.Interval = 1000;
        	this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
        	// 
        	// openFileDialog1
        	// 
        	this.openFileDialog1.FileName = "openFileDialog1";
        	// 
        	// tabPage4
        	// 
        	this.tabPage4.Controls.Add(this.groupBox4);
        	this.tabPage4.Location = new System.Drawing.Point(4, 22);
        	this.tabPage4.Name = "tabPage4";
        	this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage4.Size = new System.Drawing.Size(776, 484);
        	this.tabPage4.TabIndex = 3;
        	this.tabPage4.Text = "Experimental";
        	this.tabPage4.UseVisualStyleBackColor = true;
        	// 
        	// groupBox4
        	// 
        	this.groupBox4.BackColor = System.Drawing.Color.LightGray;
        	this.groupBox4.Controls.Add(this.txtReceiveV);
        	this.groupBox4.Controls.Add(this.btnPause);
        	this.groupBox4.Controls.Add(this.btnDateiNeu);
        	this.groupBox4.Controls.Add(this.dataGridView1);
        	this.groupBox4.Controls.Add(this.label4);
        	this.groupBox4.Controls.Add(this.comboBox2);
        	this.groupBox4.Controls.Add(this.checkBox1);
        	this.groupBox4.Controls.Add(this.label2);
        	this.groupBox4.Controls.Add(this.btnStartDrehzahlVersuch);
        	this.groupBox4.Location = new System.Drawing.Point(8, 6);
        	this.groupBox4.Name = "groupBox4";
        	this.groupBox4.Size = new System.Drawing.Size(762, 472);
        	this.groupBox4.TabIndex = 0;
        	this.groupBox4.TabStop = false;
        	this.groupBox4.Text = "Versuch";
        	// 
        	// txtReceiveV
        	// 
        	this.txtReceiveV.Location = new System.Drawing.Point(480, 99);
        	this.txtReceiveV.Multiline = true;
        	this.txtReceiveV.Name = "txtReceiveV";
        	this.txtReceiveV.Size = new System.Drawing.Size(230, 260);
        	this.txtReceiveV.TabIndex = 19;
        	// 
        	// btnPause
        	// 
        	this.btnPause.Location = new System.Drawing.Point(303, 389);
        	this.btnPause.Name = "btnPause";
        	this.btnPause.Size = new System.Drawing.Size(257, 58);
        	this.btnPause.TabIndex = 18;
        	this.btnPause.Text = "Pause";
        	this.btnPause.UseVisualStyleBackColor = true;
        	this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
        	// 
        	// btnDateiNeu
        	// 
        	this.btnDateiNeu.Location = new System.Drawing.Point(480, 62);
        	this.btnDateiNeu.Name = "btnDateiNeu";
        	this.btnDateiNeu.Size = new System.Drawing.Size(230, 23);
        	this.btnDateiNeu.TabIndex = 17;
        	this.btnDateiNeu.Text = "New";
        	this.btnDateiNeu.UseVisualStyleBackColor = true;
        	this.btnDateiNeu.Click += new System.EventHandler(this.button4_Click);
        	// 
        	// dataGridView1
        	// 
        	this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dataGridView1.Location = new System.Drawing.Point(47, 99);
        	this.dataGridView1.Name = "dataGridView1";
        	this.dataGridView1.Size = new System.Drawing.Size(414, 260);
        	this.dataGridView1.TabIndex = 16;
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(44, 65);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(40, 13);
        	this.label4.TabIndex = 12;
        	this.label4.Text = "Choice";
        	// 
        	// comboBox2
        	// 
        	this.comboBox2.FormattingEnabled = true;
        	this.comboBox2.Location = new System.Drawing.Point(97, 62);
        	this.comboBox2.Name = "comboBox2";
        	this.comboBox2.Size = new System.Drawing.Size(364, 21);
        	this.comboBox2.TabIndex = 11;
        	this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
        	// 
        	// checkBox1
        	// 
        	this.checkBox1.AutoSize = true;
        	this.checkBox1.Location = new System.Drawing.Point(591, 411);
        	this.checkBox1.Name = "checkBox1";
        	this.checkBox1.Size = new System.Drawing.Size(63, 17);
        	this.checkBox1.TabIndex = 10;
        	this.checkBox1.Text = "Endless";
        	this.checkBox1.UseVisualStyleBackColor = true;
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label2.Location = new System.Drawing.Point(43, 25);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(121, 24);
        	this.label2.TabIndex = 5;
        	this.label2.Text = "Experimental";
        	// 
        	// btnStartDrehzahlVersuch
        	// 
        	this.btnStartDrehzahlVersuch.Location = new System.Drawing.Point(47, 389);
        	this.btnStartDrehzahlVersuch.Name = "btnStartDrehzahlVersuch";
        	this.btnStartDrehzahlVersuch.Size = new System.Drawing.Size(250, 58);
        	this.btnStartDrehzahlVersuch.TabIndex = 4;
        	this.btnStartDrehzahlVersuch.Text = "Start";
        	this.btnStartDrehzahlVersuch.UseVisualStyleBackColor = true;
        	this.btnStartDrehzahlVersuch.Click += new System.EventHandler(this.btnStartDrehzahlVersuch_Click);
        	// 
        	// tabPage3
        	// 
        	this.tabPage3.BackColor = System.Drawing.Color.DarkGray;
        	this.tabPage3.Controls.Add(this.groupBox3);
        	this.tabPage3.Location = new System.Drawing.Point(4, 22);
        	this.tabPage3.Name = "tabPage3";
        	this.tabPage3.Size = new System.Drawing.Size(776, 484);
        	this.tabPage3.TabIndex = 2;
        	this.tabPage3.Text = "Setup Commport";
        	// 
        	// groupBox3
        	// 
        	this.groupBox3.BackColor = System.Drawing.Color.LightGray;
        	this.groupBox3.Controls.Add(this.comboBox3);
        	this.groupBox3.Controls.Add(this.label1);
        	this.groupBox3.Controls.Add(this.panel1);
        	this.groupBox3.Controls.Add(this.btnOpen);
        	this.groupBox3.Controls.Add(this.comboBox1);
        	this.groupBox3.Location = new System.Drawing.Point(8, 6);
        	this.groupBox3.Name = "groupBox3";
        	this.groupBox3.Size = new System.Drawing.Size(762, 472);
        	this.groupBox3.TabIndex = 0;
        	this.groupBox3.TabStop = false;
        	this.groupBox3.Text = "Einstellungen";
        	// 
        	// comboBox3
        	// 
        	this.comboBox3.FormattingEnabled = true;
        	this.comboBox3.Items.AddRange(new object[] {
			"1200",
			"2400",
			"4800",
			"9600",
			"19200",
			"38400",
			"57600",
			"115200"});
        	this.comboBox3.Location = new System.Drawing.Point(200, 110);
        	this.comboBox3.Name = "comboBox3";
        	this.comboBox3.Size = new System.Drawing.Size(364, 21);
        	this.comboBox3.TabIndex = 4;
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(200, 169);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(0, 13);
        	this.label1.TabIndex = 3;
        	// 
        	// panel1
        	// 
        	this.panel1.BackColor = System.Drawing.Color.Red;
        	this.panel1.Location = new System.Drawing.Point(200, 185);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(364, 21);
        	this.panel1.TabIndex = 2;
        	// 
        	// btnOpen
        	// 
        	this.btnOpen.Location = new System.Drawing.Point(200, 223);
        	this.btnOpen.Name = "btnOpen";
        	this.btnOpen.Size = new System.Drawing.Size(364, 23);
        	this.btnOpen.TabIndex = 1;
        	this.btnOpen.Text = "Open";
        	this.btnOpen.UseVisualStyleBackColor = true;
        	this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
        	// 
        	// comboBox1
        	// 
        	this.comboBox1.FormattingEnabled = true;
        	this.comboBox1.Location = new System.Drawing.Point(200, 49);
        	this.comboBox1.Name = "comboBox1";
        	this.comboBox1.Size = new System.Drawing.Size(364, 21);
        	this.comboBox1.TabIndex = 0;
        	this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
        	// 
        	// tabControl1
        	// 
        	this.tabControl1.Controls.Add(this.tabPage3);
        	this.tabControl1.Controls.Add(this.tabPage4);
        	this.tabControl1.Location = new System.Drawing.Point(0, 27);
        	this.tabControl1.Name = "tabControl1";
        	this.tabControl1.SelectedIndex = 0;
        	this.tabControl1.Size = new System.Drawing.Size(784, 510);
        	this.tabControl1.TabIndex = 1;
        	// 
        	// Form1
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(784, 562);
        	this.Controls.Add(this.statusStrip1);
        	this.Controls.Add(this.tabControl1);
        	this.Controls.Add(this.menuStrip1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        	this.MainMenuStrip = this.menuStrip1;
        	this.MaximizeBox = false;
        	this.Name = "Form1";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Commport DatagridView";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
        	this.Load += new System.EventHandler(this.Form1_Load);
        	this.menuStrip1.ResumeLayout(false);
        	this.menuStrip1.PerformLayout();
        	this.statusStrip1.ResumeLayout(false);
        	this.statusStrip1.PerformLayout();
        	this.tabPage4.ResumeLayout(false);
        	this.groupBox4.ResumeLayout(false);
        	this.groupBox4.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
        	this.tabPage3.ResumeLayout(false);
        	this.groupBox3.ResumeLayout(false);
        	this.groupBox3.PerformLayout();
        	this.tabControl1.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }
        
        #endregion  
         
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        //private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStartDrehzahlVersuch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDateiNeu;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TextBox txtReceiveV;
    }
}

