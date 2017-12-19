using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class ViewForm : Form
    {
        string section = "";
        string theory = "";
        public void SetData(string section, string theory)
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader("data/" + section + "/name.txt");
            line = file.ReadLine();
            this.Text = line;
            file.Close();
            this.section = section;
            this.theory = theory;
            Theory tmp = LoadTheory(section, Convert.ToInt32(theory));
            textBoxName.Text = tmp.Name();
            richTextBox1.Text = tmp.Text();
        }

        public Theory LoadTheory(String parent, int indexOfNode)
        {
            Theory tmp;
            String path = "data/" + parent + "/" + indexOfNode.ToString() + ".t";
            using (Stream stream = File.Open(path, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                tmp = (Theory)bformatter.Deserialize(stream);
            }

            return tmp;
        }
        public ViewForm()
        {
            InitializeComponent();
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(theory)>1)
            {
                theory = (Convert.ToInt32(theory) - 1).ToString();
                SetData(section, theory);
            }
            else if(Convert.ToInt32(section)>1)
            {
                section = (Convert.ToInt32(section) - 1).ToString();
                int countOfTheories = Directory.GetFiles("data/" + section, "*.t", SearchOption.AllDirectories).Length;
                theory = countOfTheories.ToString();
                SetData(section, theory);
            }
            else
            {
                MessageBox.Show("Достигнуто начало теории!", "Предупреждение", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            int countOfTheories = Directory.GetFiles("data/" + section, "*.t", SearchOption.AllDirectories).Length;
            int countOf = Directory.GetDirectories("data/").Length;
            if (Convert.ToInt32(theory) < countOfTheories)
            {
                theory = (Convert.ToInt32(theory) + 1).ToString();
                SetData(section, theory);
            }
            else if (Convert.ToInt32(section) < countOf)
            {
                section = (Convert.ToInt32(section) + 1).ToString();
                theory = 1.ToString();
                SetData(section, theory);
            }
            else
            {
                MessageBox.Show("Достигнут конец теории!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
