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
    public partial class PasswordForm : Form
    {
        string password;
        public int index;
        public MainForm mainFrm;

        public PasswordForm()
        {
            InitializeComponent();
        }

        private void PasswordForm_Load(object sender, EventArgs e)
        {
            password = "";
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (textBox.Text == password)
            {
                if (index == 0)
                {
                    QuestionsForm frm = new QuestionsForm();
                    frm.Show();
                }
                else if (index == 1)
                {
                    SectionForm frm = new SectionForm();
                    frm.mainFrm = mainFrm;
                    frm.Show();
                }
            }
            else
                MessageBox.Show("Неверный пароль", "Ошибка");

            this.Close();                
        }
    }
}
