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
    public partial class EditQuestionForm : Form
    {
        public QuestionsForm parentFrm;
        public bool edit = false;
        public int indexOfQst;
        public string ovp;
        public EditQuestionForm()
        {
            InitializeComponent();
        }
        
        public void SetData(Question qst)
        {
            textBoxQuestion.Text = qst.Text_of();
            textBox1.Text = qst.Ans_wers()[0].Remove(0,3);
            textBox2.Text = qst.Ans_wers()[1].Remove(0, 3);
            textBox3.Text = qst.Ans_wers()[2].Remove(0, 3);
            textBox4.Text = qst.Ans_wers()[3].Remove(0, 3);
        }

        private void EditQuestionForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (edit == false)
            {
                int fCount = Directory.GetFiles("data/" + ovp, "*.q", SearchOption.AllDirectories).Length;
                fCount++;
                using (Stream stream = File.Open("data/" + ovp + "/" + fCount.ToString() + ".q", FileMode.Create))
                {
                    String[] answers =
                    {
                    "1. "+textBox1.Text,
                    "2. "+textBox2.Text,
                    "3. "+textBox3.Text,
                    "4. "+textBox4.Text
                };
                    Question qst = new Question(textBoxQuestion.Text, answers, 1);
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    bformatter.Serialize(stream, qst);
                }
                this.Close();
            }
            else
            {
                File.Delete("data/" + ovp + "/" + indexOfQst.ToString() + ".q");
                using (Stream stream = File.Open("data/" + ovp + "/" + indexOfQst.ToString() + ".q", FileMode.Create))
                {
                    String[] answers =
                    {
                    "1. "+textBox1.Text,
                    "2. "+textBox2.Text,
                    "3. "+textBox3.Text,
                    "4. "+textBox4.Text
                };
                    Question qst = new Question(textBoxQuestion.Text, answers, 1);
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    bformatter.Serialize(stream, qst);
                }
                this.Close();
            }
        }

        private void EditQuestionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentFrm.RefreshTree();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
