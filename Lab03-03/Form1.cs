using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            //gộp 2 thuộc tính add person
            toolStripButtonAddPerson.Click += addPerson_Click;
            ToolStripMenuItemAddPerson.Click += addPerson_Click;
        }

        public void addPerson_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        public bool KiemTraSV(string MSSV)
        {
            foreach (DataGridViewRow row in dataGridViewSV.Rows)
            {
                if(row.Cells[0].Value != null && row.Cells[0].Value.ToString() == MSSV)
                {
                    return true;
                }
            }
            return false;
        }

        public void InsertOrUpdateData( string mssv, string name,string khoa, string dtb)
        {
            dataGridViewSV.Rows[0].Cells[0].Value = mssv;
            dataGridViewSV.Rows[1].Cells[1].Value = name;
            dataGridViewSV.Rows[2].Cells[2].Value = khoa;

            dataGridViewSV.Rows[3].Cells[3].Value = dtb;
        }
    }
}
