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
    public partial class QuestionsForm : Form
    {
        string ovp;
        public QuestionsForm()
        {
            InitializeComponent();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Name == "1" || e.Node.Name == "2" || e.Node.Name == "3" || e.Node.Name== "4")
            {
                buttonAdd.Enabled = true;
                ovp = e.Node.Name;
            }
            else
            {
                buttonAdd.Enabled = false;
            }
        }

        private void treeView1_Leave(object sender, EventArgs e)
        {
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            EditQuestionForm frm = new EditQuestionForm();
            frm.ovp = ovp;
            frm.Show();
        }

        private void QuestionsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
