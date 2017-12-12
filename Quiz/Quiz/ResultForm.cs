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
        public int ovp;
        public int result;
        public int total;

        public ResultForm()
        {
            InitializeComponent();
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            if (ovp == 5)
                labelTest.Text = "По всем разделам";
            else
                labelTest.Text = "Раздел " + ovp.ToString();

            labelResult.Text = result.ToString() + " из " + total.ToString();
        }
    }
}
