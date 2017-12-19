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
    public partial class ResultForm : Form
    {
        public int section;
        public int result;
        public int total;

        public ResultForm()
        {
            InitializeComponent();
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            if (section == -1)
                labelTest.Text = "По всем разделам";
            else
                labelTest.Text = section.ToString();

            labelResult.Text = result.ToString() + " из " + total.ToString();
        }

        private void ResultForm_Shown(object sender, EventArgs e)
        {
            if (section == -1)
                labelTest.Text = "По всем разделам";
            else
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader("data/" + section.ToString() + "/name.txt");
                line = file.ReadLine();
                file.Close();
                labelTest.Text = line;
            }

            labelResult.Text = result.ToString() + " из " + total.ToString();
        }
    }
}
