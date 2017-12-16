namespace Quiz
{
    partial class MainForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Раздел 1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Раздел 2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Раздел 3");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Раздел 4");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Полное тестирование");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Тестирование", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Вопросы");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Разделы");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "test1";
            treeNode1.Text = "Раздел 1";
            treeNode2.Name = "test2";
            treeNode2.Text = "Раздел 2";
            treeNode3.Name = "test3";
            treeNode3.Text = "Раздел 3";
            treeNode4.Name = "test4";
            treeNode4.Text = "Раздел 4";
            treeNode5.Name = "testall";
            treeNode5.Text = "Полное тестирование";
            treeNode6.Name = "test";
            treeNode6.Text = "Тестирование";
            treeNode7.Name = "questions";
            treeNode7.Text = "Вопросы";
            treeNode8.Name = "section";
            treeNode8.Text = "Разделы";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8});
            this.treeView1.Size = new System.Drawing.Size(614, 448);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 472);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "ОБЩЕВОЕННАЯ ПОДГОТОВКА";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
    }
}

