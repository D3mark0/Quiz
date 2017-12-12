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
    public partial class QuestionsForm : Form
    {
        Question tmp = new Question("", new String[4], 1);
        string ovp;
        public QuestionsForm()
        {
            InitializeComponent();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            buttonDelete.Enabled = false;
            buttonAdd.Enabled = false;
            buttonEdit.Enabled = false;
            /*if (e.Node.Name == "1" || e.Node.Name == "2" || e.Node.Name == "3" || e.Node.Name== "4")
            {
                textBoxQuestion.Text = "";
                textBoxAnswers.Text = "";
                buttonAdd.Enabled = true;
                ovp = e.Node.Name;
            }*/
            if(e.Node.Text.Contains("Вопрос"))
            {
                String parentName = e.Node.Parent.Name;
                int index = e.Node.Index + 1;
                tmp = LoadQuestion(parentName, index);
                buttonEdit.Enabled = true;
                buttonDelete.Enabled = true;
            }
            else
            {
                buttonAdd.Enabled = true;
                ovp = e.Node.Name;
                textBoxQuestion.Text = "";
                textBoxAnswers.Text = "";
            }
        }

        private void treeView1_Leave(object sender, EventArgs e)
        {
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            buttonAdd.Enabled = false;
            EditQuestionForm frm = new EditQuestionForm();
            frm.ovp = ovp;
            frm.parentFrm = this;
            frm.Show();
        }

        private void QuestionsForm_Load(object sender, EventArgs e)
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
            RefreshTree();
        }

        public void RefreshFiles(int index)
        {
            DirectoryInfo d = new DirectoryInfo("data/"+index.ToString());
            FileInfo[] Files = d.GetFiles("*.q");
            for(int i = 0; i< Files.Count();i++)
            {
                try
                {
                    File.Move("data/"+index.ToString()+"/" + Files[i].Name, "data/" + index.ToString() + "/" + (i+1).ToString() + ".q");
                }
                catch { }
            }
        }

        public void RefreshTree()
        {
            int countOf = Directory.GetDirectories("data/").Length;
            textBoxQuestion.Text = "";
            textBoxAnswers.Text = "";
            for(int i=1;i<=countOf;i++)
            {
                RefreshFiles(i);
                GetDataOf(i);
            }
        }

        public Question LoadQuestion(String parent, int indexOfNode)
        {
            Question tmp;
            String path = "data/"+parent+"/"+indexOfNode.ToString()+".q";
            using (Stream stream = File.Open(path, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                tmp = (Question)bformatter.Deserialize(stream);
            }
            textBoxQuestion.Text = tmp.Text_of();
            textBoxAnswers.Lines = tmp.Ans_wers();
            return tmp;
        }

        public void GetDataOf(int data_index)
        {
            treeView1.Nodes[data_index.ToString()].Nodes.Clear();
            int countOf = Directory.GetFiles("data/"+data_index.ToString(), "*.q", SearchOption.AllDirectories).Length;
            for (int i = 0; i < countOf; i++)
            {
                treeView1.Nodes[data_index.ToString()].Nodes.Add("Вопрос " + (i + 1).ToString());
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            buttonDelete.Enabled = false;
            buttonEdit.Enabled = false;
            String path = "data/" + treeView1.SelectedNode.Parent.Name + "/" + (treeView1.SelectedNode.Index+1).ToString() + ".q";
            File.Delete(path);
            RefreshFiles(Convert.ToInt32(treeView1.SelectedNode.Parent.Name));
            RefreshTree();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            buttonDelete.Enabled = false;
            buttonEdit.Enabled = false;
            EditQuestionForm frm = new EditQuestionForm();
            frm.ovp = ovp;
            frm.SetData(tmp);
            frm.edit = true;
            frm.indexOfQst = treeView1.SelectedNode.Index + 1;
            frm.parentFrm = this;
            frm.Show();
        }
    }
}
