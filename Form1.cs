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
                    rtb.AppendText(i.ToString());
                    rtb.ReadOnly = true;
                    rtb.TabIndex = 0;
                }
            }
        }

        private void InitializeMonth()
        {
            Month.Text = "2024/12";
        }
    }
}
