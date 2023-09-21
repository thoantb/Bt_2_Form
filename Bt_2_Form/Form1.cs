using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bt_2_Form
{
    public partial class Form1 : Form
    {
        //private string id, name, fa;
        //private float score;
        public Form1 form1;
        public Form2 form2;
        private DataTable dataTable;
        public Form1()
        {
            InitializeComponent();
            form1 = this;
        }
        //public Form1(string StudentId, string FullName, string Faculty , float Score)
        //{
          //  InitializeComponent();
            //this.id = StudentId;
           // this.name = FullName;
           // this.fa = Faculty;
           // this.score = Score;
        //}


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<Form2>().Count() == 1)
                Application.OpenForms.OfType<Form2>().First().Close();
            form2 = new Form2(this);
            form2.Show(this);
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Enter_1(object sender, EventArgs e)
        {
            int n = 0;
            dgvStudent.Rows.Clear();
            for (int i = 0; i < form2.students.Count; i++)
            {
                if (form2.students[i].name.Contains(toolStripTextBox1.Text))
                {
                    n = dgvStudent.Rows.Add();
                    dgvStudent.Rows[n].Cells[0].Value = Convert.ToString(n);
                    dgvStudent.Rows[n].Cells[1].Value = form2.students[i].id;
                    dgvStudent.Rows[n].Cells[2].Value = form2.students[i].name;
                    dgvStudent.Rows[n].Cells[3].Value = form2.students[i].fac;
                    dgvStudent.Rows[n].Cells[4].Value = form2.students[i].score;
                    n++;
                }
            }
        }
    }
}
