using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class QuizForm : Form
    {
        public QuizForm()
        {
            InitializeComponent();
        }

        private void QuizForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

    [Serializable]
    public class Question
    {
        String textof;
        String[] answers = new String[4];
        int r_answer;
        public Question(String textof, String[] answers, int r_answer)
        {
            this.textof = textof;
            this.answers = answers;
            this.r_answer = r_answer;
        }
        public int R_ans()
        {
            return r_answer;
        }
    }
}
