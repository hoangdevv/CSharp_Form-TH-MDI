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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBoxKhoa.SelectedIndex = 0;
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxMSSV.Text == "" || textBoxTenSV.Text == "" || textBoxDTB.Text == "")
                {
                    throw new Exception("Vui lòng nhạp đầy đủ thông tin!");
                }
                Form1 form1 = Application.OpenForms["Form1"] as Form1;
                
                if(form1 != null)
                {
                    // gán selectedRow có tồn tại mssv ko?
                    bool selectedRow = form1.KiemTraSV(textBoxMSSV.Text);
                    if (selectedRow)
                    {
                        MessageBox.Show("Đã tồn tại sinh viên");
                    }
                    else
                    {
                        Form1 form = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                        
                        form.InsertOrUpdateData(textBoxMSSV.Text, textBoxTenSV.Text,comboBoxKhoa.Text, textBoxDTB.Text);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
