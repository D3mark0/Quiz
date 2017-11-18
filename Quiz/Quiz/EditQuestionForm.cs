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
        public bool edit = false;
        public string ovp;
        public EditQuestionForm()
        {
            InitializeComponent();
        }
        
        private void EditQuestionForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int fCount = Directory.GetFiles("data/" + ovp, "*.q", SearchOption.AllDirectories).Length;
            fCount++;
            using (Stream stream = File.Open("data/"+ovp+"/"+fCount.ToString()+".q", FileMode.Create))
            {
                String[] answers =
                {
                    textBox1.Text,
                    textBox2.Text,
                    textBox3.Text,
                    textBox4.Text
                };
                Question qst = new Question(textBoxQuestion.Text, answers, Convert.ToInt32(textBoxRightAnswer.Text));
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                bformatter.Serialize(stream, qst);
            }
            this.Close();
        }
    }
}
