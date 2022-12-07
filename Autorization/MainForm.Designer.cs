
namespace Autorization
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxNameProject = new System.Windows.Forms.TextBox();
            this.textBoxITN = new System.Windows.Forms.TextBox();
            this.labelNameProject = new System.Windows.Forms.Label();
            this.labelITN = new System.Windows.Forms.Label();
            this.labelJob = new System.Windows.Forms.Label();
            this.textBoxJob = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTheme = new System.Windows.Forms.Label();
            this.WhiteThemeButton = new System.Windows.Forms.Button();
            this.DarkThemeButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBoxTime = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MainMenuLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.программуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.формуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаСотрудниковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаКлиентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаПродажToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаЦенToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.печатьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.выводВMicrosoftExcelВыбраннойТаблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Controls.Add(this.textBoxNameProject);
            this.panel1.Controls.Add(this.textBoxITN);
            this.panel1.Controls.Add(this.labelNameProject);
            this.panel1.Controls.Add(this.labelITN);
            this.panel1.Controls.Add(this.labelJob);
            this.panel1.Controls.Add(this.textBoxJob);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelTheme);
            this.panel1.Controls.Add(this.WhiteThemeButton);
            this.panel1.Controls.Add(this.DarkThemeButton);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 561);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // textBoxNameProject
            // 
            this.textBoxNameProject.Location = new System.Drawing.Point(291, 451);
            this.textBoxNameProject.Name = "textBoxNameProject";
            this.textBoxNameProject.Size = new System.Drawing.Size(100, 20);
            this.textBoxNameProject.TabIndex = 48;
            this.textBoxNameProject.Visible = false;
            this.textBoxNameProject.TextChanged += new System.EventHandler(this.textBoxNameProject_TextChanged);
            // 
            // textBoxITN
            // 
            this.textBoxITN.Location = new System.Drawing.Point(291, 451);
            this.textBoxITN.Name = "textBoxITN";
            this.textBoxITN.Size = new System.Drawing.Size(100, 20);
            this.textBoxITN.TabIndex = 47;
            this.textBoxITN.Visible = false;
            this.textBoxITN.TextChanged += new System.EventHandler(this.textBoxITN_TextChanged);
            // 
            // labelNameProject
            // 
            this.labelNameProject.AutoSize = true;
            this.labelNameProject.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameProject.Location = new System.Drawing.Point(12, 451);
            this.labelNameProject.Name = "labelNameProject";
            this.labelNameProject.Size = new System.Drawing.Size(220, 20);
            this.labelNameProject.TabIndex = 46;
            this.labelNameProject.Text = "Введите название проекта:";
            this.labelNameProject.Visible = false;
            // 
            // labelITN
            // 
            this.labelITN.AutoSize = true;
            this.labelITN.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelITN.Location = new System.Drawing.Point(8, 451);
            this.labelITN.Name = "labelITN";
            this.labelITN.Size = new System.Drawing.Size(277, 20);
            this.labelITN.TabIndex = 45;
            this.labelITN.Text = "Введите ИНН компании заказчика:";
            this.labelITN.Visible = false;
            // 
            // labelJob
            // 
            this.labelJob.AutoSize = true;
            this.labelJob.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJob.Location = new System.Drawing.Point(8, 449);
            this.labelJob.Name = "labelJob";
            this.labelJob.Size = new System.Drawing.Size(239, 20);
            this.labelJob.TabIndex = 44;
            this.labelJob.Text = "Введите название должности:";
            this.labelJob.Visible = false;
            // 
            // textBoxJob
            // 
            this.textBoxJob.Location = new System.Drawing.Point(291, 451);
            this.textBoxJob.Name = "textBoxJob";
            this.textBoxJob.Size = new System.Drawing.Size(100, 20);
            this.textBoxJob.TabIndex = 43;
            this.textBoxJob.Visible = false;
            this.textBoxJob.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(158, 522);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 32);
            this.label2.TabIndex = 42;
            this.label2.Text = "?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 533);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 19);
            this.label1.TabIndex = 41;
            this.label1.Text = "Обязательная памятка";
            // 
            // labelTheme
            // 
            this.labelTheme.AutoSize = true;
            this.labelTheme.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTheme.Location = new System.Drawing.Point(688, 533);
            this.labelTheme.Name = "labelTheme";
            this.labelTheme.Size = new System.Drawing.Size(122, 16);
            this.labelTheme.TabIndex = 14;
            this.labelTheme.Text = "Светлая тема вкл.";
            // 
            // WhiteThemeButton
            // 
            this.WhiteThemeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WhiteThemeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WhiteThemeButton.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhiteThemeButton.Location = new System.Drawing.Point(816, 499);
            this.WhiteThemeButton.Name = "WhiteThemeButton";
            this.WhiteThemeButton.Size = new System.Drawing.Size(130, 23);
            this.WhiteThemeButton.TabIndex = 10;
            this.WhiteThemeButton.Text = "СВЕТЛАЯ ТЕМА";
            this.WhiteThemeButton.UseVisualStyleBackColor = true;
            this.WhiteThemeButton.Click += new System.EventHandler(this.WhiteThemeButton_Click);
            // 
            // DarkThemeButton
            // 
            this.DarkThemeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DarkThemeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DarkThemeButton.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DarkThemeButton.Location = new System.Drawing.Point(816, 528);
            this.DarkThemeButton.Name = "DarkThemeButton";
            this.DarkThemeButton.Size = new System.Drawing.Size(130, 23);
            this.DarkThemeButton.TabIndex = 9;
            this.DarkThemeButton.Text = "ТЕМНАЯ ТЕМА";
            this.DarkThemeButton.UseVisualStyleBackColor = true;
            this.DarkThemeButton.Click += new System.EventHandler(this.DarkThemeButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Lavender;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 106);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(934, 329);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            this.dataGridView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseMove);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.richTextBoxTime);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.MainMenuLabel);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(958, 100);
            this.panel2.TabIndex = 0;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            // 
            // richTextBoxTime
            // 
            this.richTextBoxTime.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.richTextBoxTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.richTextBoxTime.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxTime.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBoxTime.Location = new System.Drawing.Point(12, 37);
            this.richTextBoxTime.Name = "richTextBoxTime";
            this.richTextBoxTime.Size = new System.Drawing.Size(157, 28);
            this.richTextBoxTime.TabIndex = 33;
            this.richTextBoxTime.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(923, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 31);
            this.label4.TabIndex = 4;
            this.label4.Text = "X";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // MainMenuLabel
            // 
            this.MainMenuLabel.AutoSize = true;
            this.MainMenuLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainMenuLabel.Font = new System.Drawing.Font("Mongolian Baiti", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.MainMenuLabel.Location = new System.Drawing.Point(297, 37);
            this.MainMenuLabel.Name = "MainMenuLabel";
            this.MainMenuLabel.Size = new System.Drawing.Size(380, 52);
            this.MainMenuLabel.TabIndex = 3;
            this.MainMenuLabel.Text = "ГЛАВНОЕ МЕНЮ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьToolStripMenuItem,
            this.изменитьДанныеToolStripMenuItem,
            this.показатьДанныеToolStripMenuItem,
            this.печатьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(956, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.программуToolStripMenuItem,
            this.формуToolStripMenuItem});
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.закрытьToolStripMenuItem.Text = "Выход";
            // 
            // программуToolStripMenuItem
            // 
            this.программуToolStripMenuItem.Name = "программуToolStripMenuItem";
            this.программуToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.программуToolStripMenuItem.Text = "Из программы";
            this.программуToolStripMenuItem.Click += new System.EventHandler(this.программуToolStripMenuItem_Click);
            // 
            // формуToolStripMenuItem
            // 
            this.формуToolStripMenuItem.Name = "формуToolStripMenuItem";
            this.формуToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.формуToolStripMenuItem.Text = "Из аккаунта";
            this.формуToolStripMenuItem.Click += new System.EventHandler(this.формуToolStripMenuItem_Click);
            // 
            // изменитьДанныеToolStripMenuItem
            // 
            this.изменитьДанныеToolStripMenuItem.Name = "изменитьДанныеToolStripMenuItem";
            this.изменитьДанныеToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.изменитьДанныеToolStripMenuItem.Text = "Изменить данные";
            this.изменитьДанныеToolStripMenuItem.Click += new System.EventHandler(this.изменитьДанныеToolStripMenuItem_Click);
            // 
            // показатьДанныеToolStripMenuItem
            // 
            this.показатьДанныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.таблицаСотрудниковToolStripMenuItem,
            this.таблицаКлиентовToolStripMenuItem,
            this.таблицаЗаказовToolStripMenuItem,
            this.таблицаПродажToolStripMenuItem,
            this.таблицаЦенToolStripMenuItem});
            this.показатьДанныеToolStripMenuItem.Name = "показатьДанныеToolStripMenuItem";
            this.показатьДанныеToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.показатьДанныеToolStripMenuItem.Text = "Показать данные";
            // 
            // таблицаСотрудниковToolStripMenuItem
            // 
            this.таблицаСотрудниковToolStripMenuItem.Name = "таблицаСотрудниковToolStripMenuItem";
            this.таблицаСотрудниковToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.таблицаСотрудниковToolStripMenuItem.Text = "Таблица сотрудников";
            this.таблицаСотрудниковToolStripMenuItem.Click += new System.EventHandler(this.таблицаСотрудниковToolStripMenuItem_Click);
            // 
            // таблицаКлиентовToolStripMenuItem
            // 
            this.таблицаКлиентовToolStripMenuItem.Name = "таблицаКлиентовToolStripMenuItem";
            this.таблицаКлиентовToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.таблицаКлиентовToolStripMenuItem.Text = "Таблица заказчиков";
            this.таблицаКлиентовToolStripMenuItem.Click += new System.EventHandler(this.таблицаКлиентовToolStripMenuItem_Click);
            // 
            // таблицаЗаказовToolStripMenuItem
            // 
            this.таблицаЗаказовToolStripMenuItem.Name = "таблицаЗаказовToolStripMenuItem";
            this.таблицаЗаказовToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.таблицаЗаказовToolStripMenuItem.Text = "Таблица заказов";
            this.таблицаЗаказовToolStripMenuItem.Click += new System.EventHandler(this.таблицаЗаказовToolStripMenuItem_Click);
            // 
            // таблицаПродажToolStripMenuItem
            // 
            this.таблицаПродажToolStripMenuItem.Name = "таблицаПродажToolStripMenuItem";
            this.таблицаПродажToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.таблицаПродажToolStripMenuItem.Text = "Таблица покупок";
            this.таблицаПродажToolStripMenuItem.Click += new System.EventHandler(this.таблицаПродажToolStripMenuItem_Click);
            // 
            // таблицаЦенToolStripMenuItem
            // 
            this.таблицаЦенToolStripMenuItem.Name = "таблицаЦенToolStripMenuItem";
            this.таблицаЦенToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.таблицаЦенToolStripMenuItem.Text = "Таблица продаж";
            this.таблицаЦенToolStripMenuItem.Click += new System.EventHandler(this.таблицаЦенToolStripMenuItem_Click);
            // 
            // печатьToolStripMenuItem
            // 
            this.печатьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.печатьToolStripMenuItem1,
            this.выводВMicrosoftExcelВыбраннойТаблицыToolStripMenuItem});
            this.печатьToolStripMenuItem.Name = "печатьToolStripMenuItem";
            this.печатьToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.печатьToolStripMenuItem.Text = "Настройки";
            // 
            // печатьToolStripMenuItem1
            // 
            this.печатьToolStripMenuItem1.Name = "печатьToolStripMenuItem1";
            this.печатьToolStripMenuItem1.Size = new System.Drawing.Size(321, 22);
            this.печатьToolStripMenuItem1.Text = "Вывод в Microsoft Word выбранной таблицы";
            this.печатьToolStripMenuItem1.Click += new System.EventHandler(this.печатьToolStripMenuItem1_Click);
            // 
            // выводВMicrosoftExcelВыбраннойТаблицыToolStripMenuItem
            // 
            this.выводВMicrosoftExcelВыбраннойТаблицыToolStripMenuItem.Name = "выводВMicrosoftExcelВыбраннойТаблицыToolStripMenuItem";
            this.выводВMicrosoftExcelВыбраннойТаблицыToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
            this.выводВMicrosoftExcelВыбраннойТаблицыToolStripMenuItem.Text = "Вывод в Microsoft Excel выбранной таблицы";
            this.выводВMicrosoftExcelВыбраннойТаблицыToolStripMenuItem.Click += new System.EventHandler(this.выводВMicrosoftExcelВыбраннойТаблицыToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 561);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem программуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem формуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицаСотрудниковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицаКлиентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицаЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицаПродажToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таблицаЦенToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label MainMenuLabel;
        private System.Windows.Forms.Button WhiteThemeButton;
        private System.Windows.Forms.Button DarkThemeButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label labelTheme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolStripMenuItem печатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem печатьToolStripMenuItem1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem выводВMicrosoftExcelВыбраннойТаблицыToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxJob;
        private System.Windows.Forms.Label labelITN;
        private System.Windows.Forms.Label labelJob;
        private System.Windows.Forms.Label labelNameProject;
        private System.Windows.Forms.TextBox textBoxNameProject;
        private System.Windows.Forms.TextBox textBoxITN;
        private System.Windows.Forms.RichTextBox richTextBoxTime;
        private System.Windows.Forms.Timer timer3;
    }
}