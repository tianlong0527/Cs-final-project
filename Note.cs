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
    public partial class Note : Form
    {
        bool isTitleEmpty = true,isTagEmpty = true,isNoteEmpty = true;
        public Note()
        {
            InitializeComponent();
        }

        private void rtbTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (isTitleEmpty) rtbTitle.Text = "";
            isTitleEmpty = false;
            if (e.KeyCode == Keys.Back && rtbTitle.Text.Length <= 1) 
            {
                isTitleEmpty = true;
                rtbTitle.Text = "Title";
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (isNoteEmpty) rtbNote.Text = "";
            isNoteEmpty = false;
            if (e.KeyCode == Keys.Back && rtbNote.Text.Length <= 1)
            {
                isNoteEmpty = true;
                rtbNote.Text = "Let's write note";
            }
        }

        private void rtbTag_KeyDown(object sender, KeyEventArgs e)
        {
            if (isTagEmpty) rtbTag.Text = "";
            isTagEmpty = false;
            if (e.KeyCode == Keys.Back && rtbTag.Text.Length <= 1)
            {
                isTagEmpty = true;
                rtbTag.Text = "Empty";
            }
        }
    }
}
