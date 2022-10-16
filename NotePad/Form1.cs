using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NotePad
{
    public partial class Form1 : Form
    {
       
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog();
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            openFileDialog1.ShowDialog();

            //Reads the text file

            System.IO.StreamReader OpenFile = new
            System.IO.StreamReader(openFileDialog1.FileName);

            //Displays the text file in the textBox

            richTextBox1.Text = OpenFile.ReadToEnd();

            //Closes the proccess

            OpenFile.Close();

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(openFileDialog1.FileName);

            //Writes the text to the file

            SaveFile.WriteLine(richTextBox1.Text);

            //Closes the proccess

            SaveFile.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open the saveFileDialog
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.ShowDialog();

            //Determines the text file to save to

            System.IO.StreamWriter SaveFile = new
            System.IO.StreamWriter(saveFileDialog1.FileName);

            //Writes the text to the file

            SaveFile.WriteLine(richTextBox1.Text);

            //Closes the proccess

            SaveFile.Close();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            PrintDialog pDlg = new PrintDialog();
            PrintDocument pDoc = new PrintDocument();
            pDoc.DocumentName = "Print Document";
            pDlg.Document = pDoc;
            pDlg.AllowSelection = true;
            pDlg.AllowSomePages = true;
            if (pDlg.ShowDialog() == DialogResult.OK)
            {
                pDoc.Print();
            }
            else
            {
                MessageBox.Show("Print Cancelled");
            }
        }
        private void prntDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, new Font("Times New Roman", 14, FontStyle.Regular), Brushes.Black, new PointF(100, 100));
        }
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument prntDoc = new System.Drawing.Printing.PrintDocument();
            PrintPreviewDialog preview = new PrintPreviewDialog();
            prntDoc.PrintPage += new
            System.Drawing.Printing.PrintPageEventHandler(prntDoc_PrintPage);
            preview.Document = prntDoc;
            if (preview.ShowDialog(this) == DialogResult.OK)
            {
                prntDoc.Print();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {

                richTextBox1.ForeColor = colorDialog1.Color;
            }

        }

        private void timeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text=string.Format("{0:HH:mm:ss tt}", DateTime.Now);
        }

        private void dateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text= DateTime.Now.ToString("d/M/yyyy");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(richTextBox1.Text.Length>0)
            {
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
            }
            else
            {
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
            }
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(wordWrapToolStripMenuItem.Checked==true)
            {
                wordWrapToolStripMenuItem.Checked =false;
                richTextBox1.WordWrap = false;
            }
            else
            {
                wordWrapToolStripMenuItem.Checked = true;
                richTextBox1.WordWrap = true;
            }
        }

        private void highlightTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionBackColor = Color.Yellow;
        }
    }
}
