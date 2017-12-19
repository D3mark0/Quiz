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
    public partial class SectionsForm : Form
    {

        public MainForm mainFrm;
        public SectionsForm()
        {
            InitializeComponent();
        }

        public void GetDataOf()
        {
            buttonDeleteTheory.Enabled = false;
            buttonAddTheory.Enabled = false;
            buttonEditTheory.Enabled = false;
            buttonDeleteSection.Enabled = false;
            buttonAddSection.Enabled = false;
            buttonEditSection.Enabled = false;
            textBox1.Text = "";

            mainFrm.GetDataOf();
            treeView1.Nodes.Clear();
            int countOfDirectories = Directory.GetDirectories("data/").Length;
            for (int i = 1; i <= countOfDirectories; i++)
            {
                string line;
                StreamReader file = new StreamReader("data/"+i.ToString()+"/name.txt");
                line = file.ReadLine();
                file.Close();
                treeView1.Nodes.Add(i.ToString(), line);

                treeView1.Nodes[i.ToString()].Nodes.Clear();
                int countOfTheories = Directory.GetFiles("data/" + i.ToString(), "*.t", SearchOption.AllDirectories).Length;
                for (int j = 1; j <=countOfTheories; j++)
                {
                    Theory tmp = LoadTheory(i.ToString(), j);
                    treeView1.Nodes[i.ToString()].Nodes.Add(j.ToString() , tmp.Name());
                }
            }
        }

        private void SectionForm_Load(object sender, EventArgs e)
        {
            GetDataOf();
        }

        public Theory LoadTheory(String parent, int indexOfNode)
        {
            Theory tmp;
            String path = "data/" + parent + "/" + indexOfNode.ToString() + ".t";
            using (Stream stream = File.Open(path, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                tmp = (Theory)bformatter.Deserialize(stream);
            }

            return tmp;
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
            buttonAddTheory.Enabled = false;
            textBox1.Text = "";
            buttonEditTheory.Enabled = false;
            buttonDeleteTheory.Enabled = false;
            buttonDeleteSection.Enabled = false;
            buttonEditSection.Enabled = false;
            if(e.Node.Parent == null)
            {
                textBox1.Text = e.Node.Text;
                buttonEditSection.Enabled = true;
                buttonDeleteSection.Enabled = true;
                buttonAddTheory.Enabled = true;
            }
            else
            {
                buttonEditTheory.Enabled = true;
                buttonDeleteTheory.Enabled = true;
            }
        }

        public void RefreshDirs()
        {
            DirectoryInfo d = new DirectoryInfo("data/");
            DirectoryInfo[] dirs = d.GetDirectories();
            for (int i = 0; i < dirs.Count(); i++)
            {
                try
                {
                    Directory.Move("data/" + dirs[i].Name, "data/" + (i + 1).ToString());
                }
                catch { }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            buttonAddSection.Enabled = false;
            if (textBox1.Text != "")
            {
                    buttonAddSection.Enabled = true;
            }
            else
            {
                buttonEditSection.Enabled = false;
                buttonAddSection.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Directory.Delete("data/" + (treeView1.SelectedNode.Index+1),true);
            RefreshDirs();
            GetDataOf();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_Leave(object sender, EventArgs e)
        {
            //buttonDeleteSection.Enabled = false;
        }

        private void buttonEditTheory_Click(object sender, EventArgs e)
        {
            EditSectionForm frm = new EditSectionForm();
            frm.section = treeView1.SelectedNode.Parent.Name;
            frm.SetData(LoadTheory(treeView1.SelectedNode.Parent.Name,treeView1.SelectedNode.Index+1));
            frm.edit = true;
            frm.indexOfTheory = treeView1.SelectedNode.Index + 1;
            frm.parentFrm = this;
            frm.Show();
        }

        private void buttonAddTheory_Click(object sender, EventArgs e)
        {
            EditSectionForm frm = new EditSectionForm();
            frm.section = treeView1.SelectedNode.Name;
            frm.parentFrm = this;
            frm.Show();
        }

        private void buttonDeleteTheory_Click(object sender, EventArgs e)
        {
            String path = "data/" + treeView1.SelectedNode.Parent.Name + "/" + (treeView1.SelectedNode.Index + 1).ToString() + ".t";
            File.Delete(path);
            RefreshDirs();
            GetDataOf();
        }

        private void buttonEditSection_Click(object sender, EventArgs e)
        {
            File.Delete("data/" + treeView1.SelectedNode.Name + "/name.txt");
            File.WriteAllText("data/" + treeView1.SelectedNode.Name + "/name.txt", textBox1.Text);
            GetDataOf();
        }
    }

    [Serializable]
    public class Theory
    {
        String name;
        String text;

        public Theory(String name, String text)
        {
            this.name = name;
            this.text = text;
        }
        public string Name()
        {
            return name;
        }
        public string Text()
        {
            return text;
        }
    }
}
