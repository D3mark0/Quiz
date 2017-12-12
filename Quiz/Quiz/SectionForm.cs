using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class SectionForm : Form
    {
        public SectionForm()
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
                System.IO.StreamReader file = new System.IO.StreamReader("data/"+i.ToString()+"/name.txt");
                line = file.ReadLine();
                file.Close();
                treeView1.Nodes.Add(line);
            }
        }

        private void SectionForm_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            GetDataOf();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int fCount = Directory.GetDirectories("data/").Length;
            fCount++;
            Directory.CreateDirectory("data/" + fCount.ToString());
            File.WriteAllText("data/"+fCount.ToString()+"/name.txt", textBox1.Text);
            GetDataOf();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            button2.Enabled = true;
        }

        public void RefreshDirs()
        {
            DirectoryInfo d = new DirectoryInfo("data/");
            DirectoryInfo[] dirs = d.GetDirectories();
            for (int i = 0; i < dirs.Count(); i++)
            {
                try
                {
                    File.Move("data/" + dirs[i].Name, "data/" + (i + 1).ToString());
                }
                catch { }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Directory.Delete("data/" + (treeView1.SelectedNode.Index+1),true);
            RefreshDirs();
            GetDataOf();
        }
    }
}
