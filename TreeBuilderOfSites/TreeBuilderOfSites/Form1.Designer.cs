namespace TreeBuilderOfSites
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SelectByTag = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(12, 12);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(540, 20);
            this.textBoxUrl.TabIndex = 1;
            this.textBoxUrl.Text = "Please input url of site";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 38);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(540, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Build a tree";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(296, 67);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(256, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Please input a tag of node";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.Location = new System.Drawing.Point(12, 166);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(540, 237);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // SelectByTag
            // 
            this.SelectByTag.Location = new System.Drawing.Point(12, 64);
            this.SelectByTag.Name = "SelectByTag";
            this.SelectByTag.Size = new System.Drawing.Size(278, 23);
            this.SelectByTag.TabIndex = 5;
            this.SelectByTag.Text = "Select node by tag";
            this.SelectByTag.UseVisualStyleBackColor = true;
            this.SelectByTag.Click += new System.EventHandler(this.SelectByTag_Click);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView2.Location = new System.Drawing.Point(12, 93);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(540, 67);
            this.listView2.TabIndex = 6;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tag";
            this.columnHeader1.Width = 86;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tag";
            this.columnHeader2.Width = 91;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Url";
            this.columnHeader3.Width = 258;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Parrent";
            this.columnHeader4.Width = 312;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Url";
            this.columnHeader5.Width = 303;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Parrent";
            this.columnHeader6.Width = 374;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 411);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.SelectByTag);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxUrl);
            this.Name = "Form1";
            this.Text = "TreeBuilderOfSites";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button SelectByTag;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}

