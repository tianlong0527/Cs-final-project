using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personal_note
{
    public partial class Form1 : Form
    {
        private int year = 2024;
        private int month = 12;
        public Form1()
        {
            InitializeComponent();
            InitializeDate();
            InitializeMonth();
        }

        private void InitializeDate()
        {
            // initialize dates
            for (int i = 1; i <= 35; i++)
            {
                RichTextBox rtb = this.Controls["richTextBox" + i] as RichTextBox;
                if (rtb is RichTextBox)
                {
                    rtb.SelectionAlignment = HorizontalAlignment.Right;
                    rtb.AppendText(i.ToString() + " ");
                    rtb.ReadOnly = true;
                    rtb.TabIndex = 0;
                    rtb.Cursor = Cursors.Default;
                    rtb.BorderStyle = BorderStyle.Fixed3D;
                    rtb.BackColor = Color.Black;
                    rtb.ForeColor = Color.White;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                TextBox tb = this.Controls["textBox" + i] as TextBox;
                if (tb is TextBox)
                {
                    tb.ReadOnly = true;
                    tb.BackColor = Color.Black;
                    tb.BorderStyle = BorderStyle.None;
                    tb.Cursor = Cursors.Default;
                    tb.ForeColor = Color.White;
                }
            }
        }

        private void InitializeMonth()
        {
            Month.Text = $"{year}/{month}";
        }
    }
}
