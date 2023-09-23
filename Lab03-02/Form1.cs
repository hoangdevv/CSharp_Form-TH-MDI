using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboFont();
            comboSize();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Đặt giá trị mặc định ban đầu cho ComboBox Font là "Tahoma"
            comboBoxFont.SelectedItem = "Tahoma";

            // Đặt giá trị mặc định ban đầu cho ComboBox Size là 14
            comboBoxSize.SelectedItem = 14;

            //gộp 2 thuộc tính new file
            toolStripNewFile.Click += newFile_Click;
            toolStripNewFileButton.Click += newFile_Click;

            //gộp 2 thuộc tính lưu file
            toolStripSaveFile.Click += saveFile_Click;
            toolStripSaveFileButton.Click += saveFile_Click;

            
        }
        public string path = "";

        private void toolStripDinhDang_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if(fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox.Font = fontDlg.Font;
                richTextBox.ForeColor = fontDlg.Color;
            }
        }

        public void comboFont()
        {
            // Tạo dữ liệu cho ComboBox Font
            foreach (FontFamily items in new InstalledFontCollection().Families)
            {
                comboBoxFont.Items.Add(items.Name);
            }
        }

        public void comboSize()
        {
            // Tạo dữ liệu cho ComboBox Size
            for (int i = 8; i <= 72; i++)
            {
                comboBoxSize.Items.Add(i);
            }

        }

        private void comboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string selectedFontName = comboBoxFont.SelectedItem.ToString();
            //float selectedFontSize = float.Parse(comboBoxSize.ToString());

            //// Tạo font mới với font name và font size đã chọn
            //Font selectedFont = new Font(selectedFontName, selectedFontSize);

            //// Thiết lập font cho Label (lblSample là tên của Label)
            //richTextBox.Font = selectedFont;
        }

        private void newFile_Click(object sender, EventArgs e)
        {
            richTextBox.Clear();
            richTextBox.Font = new Font("Tahoma", 14, FontStyle.Regular); // set
            comboBoxFont.SelectedItem = "Tahoma"; // mac dinh lai
            comboBoxSize.SelectedItem = "14"; //mac dinh lai
            path = "";
        }


        private void saveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDLG = new SaveFileDialog();
            saveDLG.Title = "Save text Files";
            saveDLG.InitialDirectory = @"C:\";      

            saveDLG.DefaultExt = "doc";
            saveDLG.Filter = "DOC file|*.doc";
            saveDLG.FilterIndex = 2;

            saveDLG.CheckPathExists = true;
            saveDLG.RestoreDirectory = true;
            if(saveDLG.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SaveFile(saveDLG.FileName, RichTextBoxStreamType.PlainText);
                MessageBox.Show("Lưu file thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolStripOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDLG = new OpenFileDialog();
            openFileDLG.Filter = "DOC file|*.doc";
            if(openFileDLG.ShowDialog() == DialogResult.OK)
            {
                richTextBox.LoadFile(openFileDLG.FileName, RichTextBoxStreamType.PlainText);
                path = openFileDLG.FileName;
            }
        }

        //Bold : in dam
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //if (richTextBox.SelectionFont.Bold)
            //{
            //    richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, richTextBox.SelectionFont.Style & ~FontStyle.Bold);
            //    toolStripButtonBold.BackColor = Color.White;
            //}
            //else
            //{
            //    richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, richTextBox.SelectionFont.Style | FontStyle.Bold);
            //    toolStripButtonBold.BackColor = Color.LightBlue;

            //}
            if (richTextBox.SelectionFont != null)
            {
                //FontStyle currentStyle = richTextBox.SelectionFont.Style;
                FontStyle newStyle = richTextBox.SelectionFont.Style ^ FontStyle.Bold; // Xor với FontStyle.Bold để chuyển đổi giữa in đậm và không in đậm
                richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, newStyle);

                toolStripButtonBold.BackColor = newStyle.HasFlag(FontStyle.Bold) ? Color.LightBlue : SystemColors.Control;

            }

        }

        //Italic : in nghieng
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //if (richTextBox.SelectionFont.Bold)
            //{
            //    richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, richTextBox.SelectionFont.Style & ~FontStyle.Italic);
            //    toolStripButtonItalic.BackColor = Color.White;
            //}
            //else
            //{
            //    richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, richTextBox.SelectionFont.Style | FontStyle.Italic);
            //    toolStripButtonItalic.BackColor = Color.LightBlue;

            //}
            if (richTextBox.SelectionFont != null)
            {
                //FontStyle currentStyle = richTextBox.SelectionFont.Style;
                FontStyle newStyle = richTextBox.SelectionFont.Style ^ FontStyle.Italic; // Xor với FontStyle.Bold để chuyển đổi giữa in đậm và không in đậm
                richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, newStyle);

                toolStripButtonItalic.BackColor = newStyle.HasFlag(FontStyle.Italic) ? Color.LightBlue : SystemColors.Control;

            }
        }

        //Underline: gach chan
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //if (richTextBox.SelectionFont.Bold)
            //{
            //    richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, richTextBox.SelectionFont.Style & ~FontStyle.Regular);
            //    toolStripButtonRegular.BackColor = Color.White;
            //}
            //else
            //{
            //    richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, richTextBox.SelectionFont.Style | FontStyle.Regular);
            //    toolStripButtonRegular.BackColor = Color.LightBlue;

            //}
            if (richTextBox.SelectionFont != null)
            {
                //FontStyle currentStyle = richTextBox.SelectionFont.Style;
                FontStyle newStyle = richTextBox.SelectionFont.Style ^ FontStyle.Underline; // Xor với FontStyle.Underline để chuyển đổi giữa gạch chân và không gạch chân
                richTextBox.SelectionFont = new Font(richTextBox.SelectionFont, newStyle);

                toolStripButtonUnderline.BackColor = newStyle.HasFlag(FontStyle.Underline) ? Color.LightBlue : SystemColors.Control;

            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
