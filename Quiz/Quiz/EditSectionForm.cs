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
    public partial class EditSectionForm : Form
    {
        public SectionForm parentFrm;
        public bool edit = false;
        public int indexOfTheory;
        public string section;
        public EditSectionForm()
        {
            InitializeComponent();
        }

        public void SetData(Theory t)
        {
            textBoxName.Text = t.Name();
            richTextBox1.Text = t.Text();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (edit == false)
            {
                int fCount = Directory.GetFiles("data/" + section, "*.t", SearchOption.AllDirectories).Length;
                fCount++;
                using (Stream stream = File.Open("data/" + section + "/" + fCount.ToString() + ".t", FileMode.Create))
                {
                    Theory t = new Theory(textBoxName.Text, richTextBox1.Text);
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    bformatter.Serialize(stream, t);
                }
                this.Close();
            }
            else
            {
                File.Delete("data/" + section + "/" + indexOfTheory.ToString() + ".t");
                using (Stream stream = File.Open("data/" + section + "/" + indexOfTheory.ToString() + ".t", FileMode.Create))
                {
                    Theory t = new Theory(textBoxName.Text, richTextBox1.Text);
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    bformatter.Serialize(stream, t);
                }
                this.Close();
            }
        }

        private void EditSectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parentFrm.GetDataOf();
        }
    }
}
