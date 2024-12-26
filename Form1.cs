using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace personal_note
{
    public partial class Form1 : Form
    {
        private List<RichTextBox> dates = new List<RichTextBox>();
        private List<TextBox> week = new List<TextBox>();
        private List<Label> notesTitle = new List<Label>();
        private Label Month = new Label();
        private Button nextMonth, lastMonth;
        private int year = 2024;
        private int month = 12;
        private int monthStartDay = 0;
        private int lastMonthDays, currentMonthDays;
        private static DateTime firstDayOfMonth, now;
        private DayOfWeek firstDayOfWeek;
        private DiaryTreeNode yearNode;
        private DiaryTreeNode monthNode;
        public Form1()
        {
            InitializeComponent();
            InitializeCalendar();
            InitializeMonth();
            InitializeButton();
            InitializeDiary();
            DiaryTree.BuildTreeFromFiles();
        }

        private void InitializeCalendar()
        {
            setCurrent();
            // Initialize dates
            for (int i = 0; i < 35; i++)
            {
                int date = i - monthStartDay + 1;
                RichTextBox rtb = new RichTextBox();
                rtb.Size = new Size(80, 90);
                rtb.Location = new Point(40 + 80 * (i % 7), 100 + 90 * (i / 7));
                rtb.BackColor = Color.Black;
                rtb.ForeColor = Color.White;
                rtb.BorderStyle = BorderStyle.Fixed3D;
                rtb.Font = new Font("Arial", 10);
                rtb.SelectionAlignment = HorizontalAlignment.Right;
                rtb.Cursor = Cursors.Hand;

                if (date <= 0)
                {
                    date = lastMonthDays + date;
                    rtb.ForeColor = Color.Gray;
                }
                else if (date > currentMonthDays)
                {
                    date = date - currentMonthDays;
                    rtb.ForeColor = Color.Gray;
                }
                rtb.AppendText(date.ToString());
                rtb.ReadOnly = true;
                rtb.Click += richTextBox_Click;
                rtb.DoubleClick += richTextBox_DoubleClick;
                dates.Add(rtb);
                yearNode = DiaryTree.searchYear(year, DiaryTree.root);
                monthNode = DiaryTree.searchMonth(month, yearNode);
                this.Controls.Add(rtb);
            }

            // Initialize the days of week
            for (int i = 0; i < 7; i++)
            {
                TextBox tb = new TextBox();
                tb.Size = new Size(80, 30);
                tb.Font = new Font("微軟正黑體", 10);
                tb.Location = new Point(40 + 80 * i, 78);
                tb.BackColor = Color.Black;
                tb.ForeColor = Color.White;
                tb.BorderStyle = BorderStyle.FixedSingle;
                tb.TextAlign = HorizontalAlignment.Center;
                switch (i)
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

        private void Rtb_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
            nextMonth.Click += nextMonth_Click;

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
            lastMonth.Click += lastMonth_Click;

            this.Controls.Add(nextMonth);
            this.Controls.Add(lastMonth);
        }

        private void InitializeDiary()
        {
            DiaryTreeNode diaryTree = new DiaryTreeNode(2024, 12, 22);
            //diaryTree.LoadDiary();
            //for (int i = 0; i < 35; i++)
            //{
            //    string date = $"{year}/{month}/{i + 1}";
            //    string content = diaryTree.SearchDiary(date);
            //    dates[i].Text = content;
            //}
        }

        private void richTextBox_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = sender as RichTextBox;
            if (rtb.ForeColor == Color.Gray)
            {
                if (int.Parse(rtb.Text) < 8)
                {
                    month++;
                    if (month == 13)
                    {
                        month = 1;
                        year++;
                    }
                    updateCalendar();
                }
                else if (int.Parse(rtb.Text) > 24)
                {
                    month--;
                    if (month == 0)
                    {
                        month = 12;
                        year--;
                    }
                    updateCalendar();
                }
            }

            showFullLabel(int.Parse(rtb.Text));
        }

        private void richTextBox_DoubleClick(object sender, EventArgs e)
        {
            RichTextBox rtb = sender as RichTextBox;
            if (rtb.ForeColor == Color.Gray)
            {
                if (int.Parse(rtb.Text) < 8)
                {
                    month++;
                    if (month == 13)
                    {
                        month = 1;
                        year++;
                    }
                    updateCalendar();
                }
                else if (int.Parse(rtb.Text) > 24)
                {
                    month--;
                    if (month == 0)
                    {
                        month = 12;
                        year--;
                    }
                    updateCalendar();
                }
            }
            Note note = new Note(year, month, int.Parse(rtb.Text));
            note.Show();
        }

        private void setCurrent()
        {
            // initialize current year and month
            now = DateTime.Now;
            year = now.Year;
            month = now.Month;
            setDay();
            int previousMonth = month - 1;
            int previousYear = year;
            if (previousMonth == 0)
            {
                previousMonth = 12;
                previousYear--;
            }
            lastMonthDays = DateTime.DaysInMonth(previousYear, previousMonth);
            currentMonthDays = DateTime.DaysInMonth(year, month);
        }

        private void setDay()
        {
            firstDayOfMonth = new DateTime(year, month, 1);
            firstDayOfWeek = firstDayOfMonth.DayOfWeek;

            switch (firstDayOfWeek)
            {
                case DayOfWeek.Sunday:
                    monthStartDay = 0;
                    break;
                case DayOfWeek.Monday:
                    monthStartDay = 1;
                    break;
                case DayOfWeek.Tuesday:
                    monthStartDay = 2;
                    break;
                case DayOfWeek.Wednesday:
                    monthStartDay = 3;
                    break;
                case DayOfWeek.Thursday:
                    monthStartDay = 4;
                    break;
                case DayOfWeek.Friday:
                    monthStartDay = 5;
                    break;
                case DayOfWeek.Saturday:
                    monthStartDay = 6;
                    break;
            }
        }

        private void nextMonth_Click(object sender, EventArgs e)
        {
            // Console.WriteLine("nextMonth_Click");
            month++;
            if (month == 13)
            {
                month = 1;
                year++;
            }
            updateCalendar();
        }

        private void lastMonth_Click(object sender, EventArgs e)
        {
            // Console.WriteLine("lastMonth_Click");
            month--;
            if (month == 0)
            {
                month = 12;
                year--;
            }
            updateCalendar();
        }

        private void updateCalendar()
        {
            setDay();
            yearNode = DiaryTree.searchYear(year, DiaryTree.root);
            monthNode = DiaryTree.searchMonth(month, yearNode);
            int previousMonth = month - 1;
            int previousYear = year;
            if (previousMonth == 0)
            {
                previousMonth = 12;
                previousYear--;
            }
            lastMonthDays = DateTime.DaysInMonth(previousYear, previousMonth);
            currentMonthDays = DateTime.DaysInMonth(year, month);
            Month.Text = $"{year}/{month}";
            for (int i = 0; i < 35; i++)
            {
                dates[i].Clear();
                int date = i - monthStartDay + 1;
                dates[i].ForeColor = Color.White;
                if (date <= 0)
                {
                    date = lastMonthDays + date;
                    dates[i].ForeColor = Color.Gray;
                }
                else if (date > currentMonthDays)
                {
                    date = date - currentMonthDays;
                    dates[i].ForeColor = Color.Gray;
                }
                dates[i].AppendText(date.ToString());
            }

            foreach (Label l in notesTitle)
            {
                this.Controls.Remove(l);
            }
            notesTitle.Clear();
            buildNotesTitleLabel();
        }

        private void buildNotesTitleLabel()
        {
            // traverse all the days in the current month and build the labels
            int date = 1;
            for (date = 1; date <= currentMonthDays; date++)
            {
                int rtbIndex = date + monthStartDay - 1;
                RichTextBox rtb = dates[rtbIndex];
                int x = rtb.Location.X + 5;
                int y = rtb.Location.Y + 20;
                DiaryTreeNode dayNode = DiaryTree.searchDay(date, monthNode);
                foreach (DiaryNode diaryNode in dayNode.nodes)
                {
                    diaryNode.label.Location = new Point(x, y + diaryNode.index * 20);
                    diaryNode.label.Tag = diaryNode;
                    diaryNode.label.Visible = true;
                    diaryNode.label.Click += label_click;
                    notesTitle.Add(diaryNode.label);
                    if (diaryNode.index >= 3)
                    {
                        diaryNode.label.Visible = false;
                    }
                    this.Controls.Add(diaryNode.label);
                    diaryNode.label.BringToFront();
                }
            }
        }

        private void label_click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            DiaryNode diaryNode = label.Tag as DiaryNode; // the diaryNode that the label belongs to
        }

        private void showFullLabel(int date)
        {
            resetLabel();
            DiaryTreeNode dayNode = DiaryTree.searchDay(date, monthNode);
            // show the labels that are hudden due to lack of space
            foreach (DiaryNode diaryNode in dayNode.nodes)
            {
                diaryNode.label.Visible = true;
            }
            // hide the labels below the current day
            for (int i = date + 7; i < 32; i += 7)
            {
                DiaryTreeNode tmp = DiaryTree.searchDay(i, monthNode);
                foreach (DiaryNode dn in tmp.nodes)
                {
                    dn.label.Visible = false;
                }
            }
        }

        private void resetLabel()
        {
            // reset the visibility of the labels
            int date = 1;
            for (date = 1; date <= currentMonthDays; date++)
            {
                DiaryTreeNode dayNode = DiaryTree.searchDay(date, monthNode);
                foreach (DiaryNode diaryNode in dayNode.nodes)
                {
                    if (diaryNode.index >= 3)
                    {
                        diaryNode.label.Visible = false;
                    }
                    else
                    {
                        diaryNode.label.Visible = true;
                    }
                }
            }
        }

    }
}
