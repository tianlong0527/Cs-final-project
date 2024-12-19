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
        private List<RichTextBox> dates = new List<RichTextBox>();
        private List<TextBox> week = new List<TextBox>();
        private Label Month = new Label();
        private Button nextMonth, lastMonth;
        private int year = 2024;
        private int month = 12;
        public Form1()
        {
            InitializeComponent();
            InitializeCalendar();
            InitializeMonth();
            InitializeButton();
            InitializeDiary();
        }

        private void InitializeCalendar()
        {
            // Initialize dates
            for (int i = 0;i < 35;i++)
            {
                RichTextBox rtb = new RichTextBox();
                rtb.Size = new Size(80, 90);
                rtb.Location = new Point(40 + 80 * (i % 7), 100 + 90 * (i / 7));
                rtb.BackColor = Color.Black;
                rtb.ForeColor = Color.White;
                rtb.BorderStyle = BorderStyle.Fixed3D;
                rtb.Font = new Font("Arial", 10);
                rtb.SelectionAlignment = HorizontalAlignment.Right;
                rtb.AppendText((i + 1).ToString());
                rtb.ReadOnly = true;
                rtb.DoubleClick += richTextBox_DoubleClick;
                dates.Add(rtb);
                this.Controls.Add(rtb);
            }

            // Initialize week
            for (int i = 0;i < 7;i++)
            {
                TextBox tb = new TextBox();
                tb.Size = new Size(80, 30);
                tb.Font = new Font("微軟正黑體", 10);
                tb.Location = new Point(40 + 80 * i, 78);
                tb.BackColor = Color.Black;
                tb.ForeColor = Color.White;
                tb.BorderStyle = BorderStyle.FixedSingle;
                tb.TextAlign = HorizontalAlignment.Center;
                switch(i)
                {
                    case 0:
                        tb.Text = "日";
                        break;
                    case 1:
                        tb.Text = "一";
                        break;
                    case 2:
                        tb.Text = "二";
                        break;
                    case 3:
                        tb.Text = "三";
                        break;
                    case 4:
                        tb.Text = "四";
                        break;
                    case 5:
                        tb.Text = "五";
                        break;
                    case 6:
                        tb.Text = "六";
                        break;
                    default:
                        break;
                }
                tb.ReadOnly = true;
                week.Add(tb);
                this.Controls.Add(tb);
            }

        }

        private void InitializeMonth()
        {
            // Initialize Month
            Month.Location = new Point(480, 59);
            Month.Size = new Size(58, 12);
            Month.ForeColor = Color.White;
            Month.Font = new Font("標楷體", 10);
            Month.Text = $"{year}/{month}";
            this.Controls.Add(Month);
            Month.BringToFront();
        }

        private void InitializeButton()
        {
            nextMonth = new Button()
            {
                Location = new Point(538, 56),
                Size = new Size(20, 20),
                Text = ">",
                BackColor = Color.Black,
                ForeColor = Color.White,
                Font = new Font("標楷體", 8),
                FlatStyle = FlatStyle.Flat
            };

            lastMonth = new Button()
            {
                Location = new Point(458, 56),
                Size = new Size(20, 20),
                Text = "<",
                BackColor = Color.Black,
                ForeColor = Color.White,
                Font = new Font("標楷體", 8),
                FlatStyle = FlatStyle.Flat
            };
            this.Controls.Add(nextMonth);
            this.Controls.Add(lastMonth);
        }

        private void InitializeDiary()
        {
            DiaryTree diaryTree = new DiaryTree();
            //diaryTree.LoadDiary();
            //for (int i = 0; i < 35; i++)
            //{
            //    string date = $"{year}/{month}/{i + 1}";
            //    string content = diaryTree.SearchDiary(date);
            //    dates[i].Text = content;
            //}
        }

        private void richTextBox_DoubleClick(object sender, EventArgs e)
        {
            Note note = new Note();
            note.Show();
        }
    }
}
