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
                QuestionsForm frm = new QuestionsForm();
                frm.Show();
            }
        }
    }
}
