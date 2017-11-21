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
    public partial class QuizForm : Form
    {
        public int ovp = 1;
        int timeLeft;
        int questionNumbers = 2;

        public QuizForm()
        {
            InitializeComponent();
        }

        public int GetCount(int data_index)
        {
            return Directory.GetFiles("data/" + data_index.ToString(), "*.q", SearchOption.AllDirectories).Length;
        }

        private void QuizForm_Load(object sender, EventArgs e)
        {
            int ovp_count1 = GetCount(1);
            int ovp_count2 = GetCount(2);
            int ovp_count3 = GetCount(3);
            int ovp_count4 = GetCount(4);
            int[] ovp1_numbers = GetNumbers(questionNumbers, ovp_count1);
            int[] ovp2_numbers = GetNumbers(questionNumbers, ovp_count2);
            int[] ovp3_numbers = GetNumbers(questionNumbers, ovp_count3);
            int[] ovp4_numbers = GetNumbers(questionNumbers, ovp_count4);

            timeLeft = (questionNumbers*4 * 60 * 2);
        }

        public int [] GetNumbers(int n, int count)
        {
            int[] temp = new int[n];
            Random rand = new Random();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = rand.Next(1, count);//где а - минимальное значение b максимальное можешь разницу поставить 20 как тебе нужно
            }
            return temp;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                labelTime.Text = (timeLeft / 60).ToString() + " минут " + (timeLeft % 60).ToString() + " секунд";
            }
            else
            {
                timer1.Stop();
                labelTime.Text = "время вышло";
                Close();
                MessageBox.Show("Время тестирования закончилось", "Конец тестирования");
            }
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
        public string Text_of()
        {
            return textof;
        }

        public string[] Ans_wers()
        {
            return answers;
        }
    }
}
