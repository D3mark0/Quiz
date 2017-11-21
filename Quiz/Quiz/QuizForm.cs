﻿using System;
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
        int timeLeft;
        
        public QuizForm()
        {
            InitializeComponent();
        }

        private void QuizForm_Load(object sender, EventArgs e)
        {
            timeLeft = (1 * 1 * 2);
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
