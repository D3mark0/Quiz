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
                for (int j = 0; j < countOfTheories; j++)
                {
                    Theory tmp = LoadTheory(i.ToString(), j);
                    treeView1.Nodes[i.ToString()].Nodes.Add(j.ToString() , tmp.Name());
                }
            }
        }

        private void SectionForm_Load(object sender, EventArgs e)
        {
            buttonAddSection.Enabled = false;
            buttonDeleteSection.Enabled = false;
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
            buttonDeleteSection.Enabled = true;
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
            if (textBox1.Text != "")
                buttonAddSection.Enabled = true;
            else
                buttonAddSection.Enabled = false;
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
