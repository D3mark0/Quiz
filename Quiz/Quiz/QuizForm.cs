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
        int countOf = Directory.GetDirectories("data/").Length;
        public int section = 5;
        int timeLeft;
        int questionNumbers = 10;
        Question[] qstArray;

        int[][] section_numbers;
        int globalCount = 0;
        int resultCount = 0;
        int answer = 0;

        public QuizForm()
        {
            InitializeComponent();
        }

        public int GetCount(int data_index)
        {
            return Directory.GetFiles("data/" + data_index.ToString(), "*.q", SearchOption.AllDirectories).Length;
        }

        public Question LoadQuestion(String parent, int indexOfNode)
        {
            Question tmp;
            String path = "data/" + parent + "/" + indexOfNode.ToString() + ".q";
            using (Stream stream = File.Open(path, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                tmp = (Question)bformatter.Deserialize(stream);
            }
            return tmp;
        }

        public void SetQuestionsArray()
        {
            int count = 0;
            for (int i=1;i<=countOf;i++)
            {
                int tmp = 0;
                if (section_numbers[i-1] != null)
                {
                    while (tmp < section_numbers[i-1].Length)
                    {
                        Question tmpQst = LoadQuestion(i.ToString(), section_numbers[i-1][tmp]);
                        tmp++;
                        qstArray[count] = tmpQst;
                        count++;
                    }
                }
            }
        }


        public void NextQuestion()
        {
            if (questionNumbers > globalCount)
            {
                textBoxQuestion.Text = qstArray[globalCount].Text_of();
                radioButton1.Text = qstArray[globalCount].Ans_wers()[0].Remove(0, 3);
                radioButton2.Text = qstArray[globalCount].Ans_wers()[1].Remove(0, 3);
                radioButton3.Text = qstArray[globalCount].Ans_wers()[2].Remove(0, 3);
                radioButton4.Text = qstArray[globalCount].Ans_wers()[3].Remove(0, 3);
            }

            else
            {
                ResultForm frm = new ResultForm();
                frm.section = section;
                frm.result = resultCount;
                frm.total = questionNumbers;

                Close();
                MessageBox.Show("Тестирование завершено", "Конец тестирования", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frm.Show();
            }
        }
        private void QuizForm_Load(object sender, EventArgs e)
        {       
            section_numbers = new int[countOf][];
            timeLeft = (questionNumbers * 1 * 60 );

            try
            {
                if (section == -1)
                {
                    questionNumbers = 5;
                    for(int i=1;i<=countOf;i++)
                        section_numbers[i-1] = GetNumbers(questionNumbers, GetCount(i));
                    timeLeft = (questionNumbers * countOf * 60);
                    questionNumbers = questionNumbers * countOf;
                }
                else
                {
                    section_numbers[section-1] = GetNumbers(questionNumbers, GetCount(section));
                }

                qstArray = new Question[questionNumbers];
                SetQuestionsArray();
                NextQuestion();
            }
            catch
            {
                Close();
                MessageBox.Show("Вопросов для тестирования недостаточно!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int [] GetNumbers(int n, int count)
        {
            var tmp = Enumerable.Range(1, n).RandomizeUniquely();
            return tmp.ToArray();
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
                

                ResultForm frm = new ResultForm();
                frm.section = section;
                frm.result = resultCount;
                frm.total = questionNumbers;

                MessageBox.Show("Время тестирования закончилось", "Конец тестирования", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frm.Show();

                Close();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (qstArray[globalCount].R_ans() == answer)
                resultCount++;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            buttonNext.Enabled = false;

            globalCount++;
            NextQuestion();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            buttonNext.Enabled = true;
            answer = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            buttonNext.Enabled = true;
            answer = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            buttonNext.Enabled = true;
            answer = 3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            buttonNext.Enabled = true;
            answer = 4;
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

    static class EnumerableExtensions
    {

        static Random random = new Random();

        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
        {
            var list = source.ToList();
            for (var k = 0; k < list.Count; k += 1)
            {
                var j = random.Next(k, list.Count);
                Swap(list, k, j);
            }
            return list;
        }

        public static IEnumerable<T> RandomizeUniquely<T>(this IEnumerable<T> source)
        {
            while (true)
            {
                var randomized = source.Randomize();
                var isNotUnique = source
                  .Zip(randomized, (a, b) => Equals(a, b))
                  .Any(equal => equal);
                if (!isNotUnique)
                    return randomized;
            }
        }

        static void Swap<T>(IList<T> list, Int32 i, Int32 j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

    }
}
