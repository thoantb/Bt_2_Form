using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bt_2_Form
{
    public partial class Form2 : Form
    {
        static int stt = 0;
        public Form2()
        {
            InitializeComponent();
        }
        public Form1 frm1;

        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.frm1 = form1;
        }
        public class Student
        {
            public string id, name, fac;
            public float score;

            public Student() { }

            public Student(string id, string name, string fac, float score)
            {
                this.id = id;
                this.name = name;
                this.fac = fac;
                this.score = score;
            }
        }
        public List<Student> students = new List<Student>();

        private void Form2_Load(object sender, EventArgs e)
        {
            cbFaculty.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStudentId.Text == "" || txtFullName.Text == "" | txtAverageScore.Text == "")
                {
                    throw new Exception("Vui long nhap du thong tin sinh vien");
                }
                int select = checkId(txtStudentId.Text);
                if(float.Parse(txtAverageScore.Text) < 0 || float.Parse(txtAverageScore.Text) > 10)
                {
                    throw new Exception("Vui long nhap diem tu 0 -> 10");
                }
                if(select == -1)
                {
                    select = frm1.dgvStudent.Rows.Add();
                    Insert(select);
                }
                else
                {
                    Insert(select);
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private int checkId(string mssv)
        {
            Student student = new Student();
            student.id = txtStudentId.Text;
            student.name = txtFullName.Text;
            student.score = float.Parse(txtAverageScore.Text);
            student.fac = cbFaculty.Text;
            for(int i = 0; i < students.Count;i++)
            {
                if(student.id == students[i].id)
                {
                    students[i].id = student.id;
                    students[i].name = student.name;
                    students[i].fac = student.fac;
                    students[i].score = student.score;
                    return i;
                }
            }
            students.Add(student);
            stt++;
            return -1;
            
        }
        void Insert(int select)
        {
            frm1.dgvStudent.Rows[select].Cells[0].Value = Convert.ToString(stt);
            frm1.dgvStudent.Rows[select].Cells[1].Value = txtStudentId.Text;
            frm1.dgvStudent.Rows[select].Cells[2].Value = txtFullName.Text;
            frm1.dgvStudent.Rows[select].Cells[3].Value = cbFaculty.SelectedItem.ToString();
            frm1.dgvStudent.Rows[select].Cells[4].Value = txtAverageScore.Text;
    
        }
    }
}
