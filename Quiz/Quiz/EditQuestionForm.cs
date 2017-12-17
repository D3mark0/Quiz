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
        public string section;
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
            if (qst.R_ans() == 1)
                radioButton1.Checked = true;
            else if (qst.R_ans() == 2)
                radioButton2.Checked = true;
            else if (qst.R_ans() == 3)
                radioButton3.Checked = true;
            else if (qst.R_ans() == 4)
                radioButton4.Checked = true;
        }

        private void EditQuestionForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int r_ans = 0;
            if (radioButton1.Checked)
                r_ans = 1;
            else if (radioButton2.Checked)
                r_ans = 2;
            else if (radioButton3.Checked)
                r_ans = 3;
            else if (radioButton4.Checked)
                r_ans = 4;
            if (edit == false)
            {
                int fCount = Directory.GetFiles("data/" + section, "*.q", SearchOption.AllDirectories).Length;
                fCount++;
                using (Stream stream = File.Open("data/" + section + "/" + fCount.ToString() + ".q", FileMode.Create))
                {
                    String[] answers =
                    {
                    "1. "+textBox1.Text,
                    "2. "+textBox2.Text,
                    "3. "+textBox3.Text,
                    "4. "+textBox4.Text
                };
                    Question qst = new Question(textBoxQuestion.Text, answers, r_ans);
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    bformatter.Serialize(stream, qst);
                }
                this.Close();
            }
            else
            {
                File.Delete("data/" + section + "/" + indexOfQst.ToString() + ".q");
                using (Stream stream = File.Open("data/" + section + "/" + indexOfQst.ToString() + ".q", FileMode.Create))
                {
                    String[] answers =
                    {
                    "1. "+textBox1.Text,
                    "2. "+textBox2.Text,
                    "3. "+textBox3.Text,
                    "4. "+textBox4.Text
                };
                    Question qst = new Question(textBoxQuestion.Text, answers, r_ans);
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
