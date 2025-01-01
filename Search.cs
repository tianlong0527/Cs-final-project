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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void btnDay_Click(object sender, EventArgs e)
        {
            if (rtbDay.Text == "" || rtbYear.Text == "" || rtbMonth.Text == "") return;
            try
            {
                List<DiaryNode> list = DiaryTree.SearchDiary(int.Parse(rtbYear.Text), int.Parse(rtbMonth.Text), int.Parse(rtbDay.Text));

                foreach (DiaryNode node in list)
                {
                    node.showDiaryNode();
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
