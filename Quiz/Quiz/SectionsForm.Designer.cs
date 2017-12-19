namespace Quiz
{
    partial class SectionsForm
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
            this.buttonAddSection = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonDeleteSection = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonAddTheory = new System.Windows.Forms.Button();
            this.buttonEditTheory = new System.Windows.Forms.Button();
            this.buttonDeleteTheory = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(6, 19);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(263, 446);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.Leave += new System.EventHandler(this.treeView1_Leave);
            // 
            // buttonAddSection
            // 
            this.buttonAddSection.Enabled = false;
            this.buttonAddSection.Location = new System.Drawing.Point(6, 67);
            this.buttonAddSection.Name = "buttonAddSection";
            this.buttonAddSection.Size = new System.Drawing.Size(94, 23);
            this.buttonAddSection.TabIndex = 3;
            this.buttonAddSection.Text = "Добавить";
            this.buttonAddSection.UseVisualStyleBackColor = true;
            this.buttonAddSection.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(321, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonDeleteSection
            // 
            this.buttonDeleteSection.Location = new System.Drawing.Point(233, 67);
            this.buttonDeleteSection.Name = "buttonDeleteSection";
            this.buttonDeleteSection.Size = new System.Drawing.Size(94, 23);
            this.buttonDeleteSection.TabIndex = 5;
            this.buttonDeleteSection.Text = "Удалить";
            this.buttonDeleteSection.UseVisualStyleBackColor = true;
            this.buttonDeleteSection.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.buttonDeleteSection);
            this.groupBox1.Controls.Add(this.buttonAddSection);
            this.groupBox1.Location = new System.Drawing.Point(293, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 107);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Раздел";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Название раздела:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.treeView1);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(275, 471);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Разделы и теория";
            // 
            // buttonAddTheory
            // 
            this.buttonAddTheory.Location = new System.Drawing.Point(6, 19);
            this.buttonAddTheory.Name = "buttonAddTheory";
            this.buttonAddTheory.Size = new System.Drawing.Size(94, 23);
            this.buttonAddTheory.TabIndex = 0;
            this.buttonAddTheory.Text = "Добавить";
            this.buttonAddTheory.UseVisualStyleBackColor = true;
            this.buttonAddTheory.Click += new System.EventHandler(this.buttonAddTheory_Click);
            // 
            // buttonEditTheory
            // 
            this.buttonEditTheory.Location = new System.Drawing.Point(121, 19);
            this.buttonEditTheory.Name = "buttonEditTheory";
            this.buttonEditTheory.Size = new System.Drawing.Size(94, 23);
            this.buttonEditTheory.TabIndex = 1;
            this.buttonEditTheory.Text = "Редактировать";
            this.buttonEditTheory.UseVisualStyleBackColor = true;
            this.buttonEditTheory.Click += new System.EventHandler(this.buttonEditTheory_Click);
            // 
            // buttonDeleteTheory
            // 
            this.buttonDeleteTheory.Location = new System.Drawing.Point(233, 19);
            this.buttonDeleteTheory.Name = "buttonDeleteTheory";
            this.buttonDeleteTheory.Size = new System.Drawing.Size(94, 23);
            this.buttonDeleteTheory.TabIndex = 2;
            this.buttonDeleteTheory.Text = "Удалить";
            this.buttonDeleteTheory.UseVisualStyleBackColor = true;
            this.buttonDeleteTheory.Click += new System.EventHandler(this.buttonDeleteTheory_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonDeleteTheory);
            this.groupBox2.Controls.Add(this.buttonEditTheory);
            this.groupBox2.Controls.Add(this.buttonAddTheory);
            this.groupBox2.Location = new System.Drawing.Point(293, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(333, 54);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Теория";
            // 
            // SectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 487);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SectionForm";
            this.Text = "Теория";
            this.Load += new System.EventHandler(this.SectionForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button buttonAddSection;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonDeleteSection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonAddTheory;
        private System.Windows.Forms.Button buttonEditTheory;
        private System.Windows.Forms.Button buttonDeleteTheory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
    }
}