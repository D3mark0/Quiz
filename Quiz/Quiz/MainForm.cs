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

        private void Form1_Load(object sender, EventArgs e)
        {
            if(!Directory.Exists("data"))
                Directory.CreateDirectory("data");
            if (!Directory.Exists("data/1"))
                Directory.CreateDirectory("data/1");
            if (!Directory.Exists("data/2"))
                Directory.CreateDirectory("data/2");
            if (!Directory.Exists("data/3"))
                Directory.CreateDirectory("data/3");
            if (!Directory.Exists("data/4"))
                Directory.CreateDirectory("data/4");

            
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Name == "questions")
            {
                PasswordForm frm = new PasswordForm();
                frm.Show();
            }
            else if (e.Node.Name == "test1")
            {
                QuizForm frm = new QuizForm();
                frm.ovp = 1;
                frm.Show();
            }
            else if (e.Node.Name == "test2")
            {
                QuizForm frm = new QuizForm();
                frm.ovp = 2;
                frm.Show();
            }
            else if (e.Node.Name == "test3")
            {
                QuizForm frm = new QuizForm();
                frm.ovp = 3;
                frm.Show();
            }
            else if (e.Node.Name == "test4")
            {
                QuizForm frm = new QuizForm();
                frm.ovp = 4;
                frm.Show();
            }
            else if (e.Node.Name == "testall")
            {
                QuizForm frm = new QuizForm();
                frm.ovp = 5;
                frm.Show();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
