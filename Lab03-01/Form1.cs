using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //loai bỏ việc mất menuStrip
            axWindowsMedia.Dock = DockStyle.Fill;
            this.SizeChanged += Form1_SizeChanged;
        }

        // autoSize
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            // Lấy kích thước cửa sổ mới
            int newWidth = this.ClientSize.Width;
            int newHeight = this.ClientSize.Height;

            // Cập nhật kích thước và vị trí của PictureBox để đảm bảo không bị biến đổi tỷ lệ và lấp đầy cửa sổ
            axWindowsMedia.Size = new Size(newWidth, newHeight);
            axWindowsMedia.Location = new Point(0, 0);
        }

        private void Time_Tick(object sender, EventArgs e)
        {
            toolStripLableDateTime.Text = string.Format
                ($"Hôm nay là ngày {DateTime.Now.ToString("dd/MM/yyyy")} " +
                $"- Bây giờ là {DateTime.Now.ToString("HH/mm/ss tt")}");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "File MP4 | *.mp4";
            if(dlg.ShowDialog() == DialogResult.OK )
            { 
                axWindowsMedia.URL = dlg.FileName;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
