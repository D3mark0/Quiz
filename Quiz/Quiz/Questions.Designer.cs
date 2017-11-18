namespace Quiz
{
    partial class Questions
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("ОВП.01. Общевоинские уставы");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("ОВП.02. Строевая подготовка");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("ОВП.03. Огневая подготовка");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("ОВП.04. Топография");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.textBoxQuestion = new System.Windows.Forms.TextBox();
            this.textBoxAnswers = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "1";
            treeNode1.Text = "ОВП.01. Общевоинские уставы";
            treeNode2.Name = "2";
            treeNode2.Text = "ОВП.02. Строевая подготовка";
            treeNode3.Name = "3";
            treeNode3.Text = "ОВП.03. Огневая подготовка";
            treeNode4.Name = "4";
            treeNode4.Text = "ОВП.04. Топография";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.treeView1.Size = new System.Drawing.Size(272, 452);
            this.treeView1.TabIndex = 1;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.Leave += new System.EventHandler(this.treeView1_Leave);
            // 
            // textBoxQuestion
            // 
            this.textBoxQuestion.Location = new System.Drawing.Point(290, 12);
            this.textBoxQuestion.Multiline = true;
            this.textBoxQuestion.Name = "textBoxQuestion";
            this.textBoxQuestion.ReadOnly = true;
            this.textBoxQuestion.Size = new System.Drawing.Size(340, 198);
            this.textBoxQuestion.TabIndex = 0;
            // 
            // textBoxAnswers
            // 
            this.textBoxAnswers.Location = new System.Drawing.Point(290, 216);
            this.textBoxAnswers.Multiline = true;
            this.textBoxAnswers.Name = "textBoxAnswers";
            this.textBoxAnswers.ReadOnly = true;
            this.textBoxAnswers.Size = new System.Drawing.Size(340, 198);
            this.textBoxAnswers.TabIndex = 2;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Enabled = false;
            this.buttonAdd.Location = new System.Drawing.Point(290, 420);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(106, 44);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Добавить вопрос";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Enabled = false;
            this.buttonEdit.Location = new System.Drawing.Point(402, 420);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(116, 44);
            this.buttonEdit.TabIndex = 4;
            this.buttonEdit.Text = "Редактировать вопрос";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(524, 420);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(106, 44);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "Удалить вопрос";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // Questions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 476);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxAnswers);
            this.Controls.Add(this.textBoxQuestion);
            this.Controls.Add(this.treeView1);
            this.Name = "Questions";
            this.Text = "Questions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBoxQuestion;
        private System.Windows.Forms.TextBox textBoxAnswers;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
    }
}