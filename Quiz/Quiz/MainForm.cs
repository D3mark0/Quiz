using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Quiz
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void GetDataOf()
        {
            treeView1.Nodes.Clear();
            int countOf = Directory.GetDirectories("data/").Length;
            for (int i = 1; i <= countOf; i++)
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader("data/" + i.ToString() + "/name.txt");
                line = file.ReadLine();
                file.Close();
                treeView1.Nodes.Add(i.ToString(),line);
            }
            treeView1.Nodes.Add("test", "Тестирование");
            for (int i = 1; i <= countOf; i++)
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader("data/" + i.ToString() + "/name.txt");
                line = file.ReadLine();
                file.Close();
                treeView1.Nodes["test"].Nodes.Add("test"+i.ToString(),line);
            }
            treeView1.Nodes["test"].Nodes.Add("testall","Полное тестирование");
            treeView1.Nodes.Add("questions", "Вопросы");
            treeView1.Nodes.Add("section", "Разделы");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*if(!Directory.Exists("data"))
                Directory.CreateDirectory("data");
            if (!Directory.Exists("data/1"))
                Directory.CreateDirectory("data/1");
            if (!Directory.Exists("data/2"))
                Directory.CreateDirectory("data/2");
            if (!Directory.Exists("data/3"))
                Directory.CreateDirectory("data/3");
            if (!Directory.Exists("data/4"))
                Directory.CreateDirectory("data/4");*/
            GetDataOf();
            
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name == "questions")
            {
                PasswordForm frm = new PasswordForm();
                frm.Show();
            }
            else if (e.Node.Name.Contains("test") && e.Node.Name != "test" && e.Node.Name !="testall")
            {
                QuizForm frm = new QuizForm();
                frm.section = Convert.ToInt32(e.Node.Name.Substring(4, e.Node.Name.Length - 4));
                frm.Show();
            }
            else if (e.Node.Name == "testall")
            {
                QuizForm frm = new QuizForm();
                frm.section = -1;
                frm.Show();
            }
            else if (e.Node.Name == "section")
            {
                SectionForm frm = new SectionForm();
                frm.Show();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
