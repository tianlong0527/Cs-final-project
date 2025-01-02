using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace personal_note
{
    public partial class Form1 : Form
    {
        public static Form1 mainForm;
        public Color colorBackGround = Color.Black;
        public Color colorText = Color.White;
        public Color colorLabel = Color.DimGray;

        private List<RichTextBox> dates = new List<RichTextBox>();
        private List<TextBox> week = new List<TextBox>();
        private List<Label> notesTitle = new List<Label>();
        private List<Color> colors = new List<Color>();
        private Label Month = new Label();
        private Button nextMonth, lastMonth;
        private int year = 2024;
        private int month = 12;
        private int monthStartDay = 0;
        private int lastMonthDays, currentMonthDays;
        private int hourForDiary = 20;
        private int minuteForDiary = 0;
        private int secondForDiary = 0;
        private static DateTime firstDayOfMonth, now;
        private DayOfWeek firstDayOfWeek;
        private DiaryTreeNode yearNode;
        private DiaryTreeNode monthNode;
        private Timer detect;
        private Color colorTextChosen = Color.Black;
        private Color colorChosen = Color.Chartreuse;
        private int colorIndex = 0;
        public Form1()
        {
            mainForm = this;
            InitializeComponent();
            InitializeCalendar();
            InitializeMonth();
            InitializeButton();
            InitializeDiary();
            InitializeTimer();
            InitializeColors();
            DiaryTree.BuildTreeFromFiles();
            updateCalendar();
            detect.Start();
        }

        private void InitializeCalendar()
        {
            setCurrent();
            // Initialize dates
            for (int i = 0; i < 42; i++)
            {
                int date = i - monthStartDay + 1;
                RichTextBox rtb = new RichTextBox();
                rtb.Size = new Size(80, 90);
                rtb.Location = new Point(40 + 80 * (i % 7), 100 + 90 * (i / 7));
                rtb.BackColor = colorBackGround;
                rtb.ForeColor = colorText;
                rtb.BorderStyle = BorderStyle.Fixed3D;
                rtb.Font = new Font("Arial", 10);
                rtb.SelectionAlignment = HorizontalAlignment.Right;
                rtb.Cursor = Cursors.Arrow;

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
                tb.BackColor = colorBackGround;
                tb.ForeColor = colorText;
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
                tb.Cursor = Cursors.Arrow;
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
            Month.ForeColor = colorText;
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
                BackColor = colorBackGround,
                ForeColor = colorText,
                Font = new Font("標楷體", 8),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            nextMonth.Click += nextMonth_Click;

            lastMonth = new Button()
            {
                Location = new Point(458, 56),
                Size = new Size(20, 20),
                Text = "<",
                BackColor = colorBackGround,
                ForeColor = colorText,
                Font = new Font("標楷體", 8),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
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

        private void InitializeTimer()
        {
            detect = new Timer();
            detect.Interval = 1000;
            detect.Tick += new EventHandler(detect_Tick);
            detect.Start();
        }

        private void InitializeColors()
        { // rtb/tb BackColor, ForeColor, lbl BackColor, lbl SForeColor, lbl SBackColor
            colors.AddRange(new List<Color> { Color.Black, Color.White, Color.DimGray, Color.Black, Color.Chartreuse });
            colors.AddRange(new List<Color> { Color.White, Color.Black, Color.LightBlue, Color.Black, Color.LightGreen });
            colors.AddRange(new List<Color> { ColorTranslator.FromHtml("#FFEAD0"), Color.Black, ColorTranslator.FromHtml("#B3E5FC"), Color.Black, ColorTranslator.FromHtml("#A7D7C5") });
            colors.AddRange(new List<Color> { ColorTranslator.FromHtml("#BDD5EA"), Color.Black, ColorTranslator.FromHtml("#5EDCFF"), Color.Black, ColorTranslator.FromHtml("#A5D0A8") });
            colors.AddRange(new List<Color> { ColorTranslator.FromHtml("#B2FFF1"), Color.Black, ColorTranslator.FromHtml("#2EC0F9"), Color.Black, ColorTranslator.FromHtml("#57A773") });
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

        private void detect_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            if (now.Hour == hourForDiary && now.Minute == minuteForDiary && now.Second == secondForDiary)
            {
                MessageBox.Show("It's time to write diary!");
            }
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

        public void updateCalendar()
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
            for (int i = 0; i < 42; i++)
            {
                dates[i].Clear();
                int date = i - monthStartDay + 1;
                dates[i].ForeColor = colorText;
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

        public void buildNotesTitleLabel()
        {
            // traverse all the days in the current month and build the labels
            for (int date = 1; date <= currentMonthDays; date++)
            {
                int rtbIndex = date + monthStartDay - 1;
                //Console.WriteLine(rtbIndex);
                RichTextBox rtb = dates[rtbIndex];
                int x = rtb.Location.X + 5;
                int y = rtb.Location.Y + 20;
                DiaryTreeNode dayNode = DiaryTree.searchDay(date, monthNode);
                foreach (DiaryNode diaryNode in dayNode.nodes)
                {
                    diaryNode.label = new Label()
                    {
                        Size = new Size(70, 20),
                        ForeColor = colorText,
                        BackColor = colorLabel,
                        Font = new Font("微軟正黑體", 9),
                        Text = diaryNode.title,
                        Cursor = Cursors.Hand
                    };
                    diaryNode.label.Location = new Point(x, y + diaryNode.index * 22);
                    diaryNode.label.Tag = diaryNode;
                    diaryNode.label.Visible = true;
                    diaryNode.label.MouseClick += label_MouseClick;
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

        private void label_MouseClick(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;
            DiaryNode diaryNode = label.Tag as DiaryNode; // the diaryNode that the label belongs to
            if (e.Button == MouseButtons.Left)
            {
                Note note = new Note(diaryNode);
                note.Show();
            }
            else if (e.Button == MouseButtons.Right)
            {
                DialogResult result = MessageBox.Show("是否刪除日記?", "刪除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DiaryTree.DeleteDiary(diaryNode);
                    foreach (Label l in notesTitle)
                    {
                        this.Controls.Remove(l);
                    }
                    notesTitle.Clear();
                    buildNotesTitleLabel();
                }
            }
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
            for (int date = 1; date <= currentMonthDays; date++)
            {
                DiaryTreeNode dayNode = DiaryTree.searchDay(date, monthNode);
                foreach (DiaryNode diaryNode in dayNode.nodes)
                {
                    if (diaryNode.index >= 3 && diaryNode.label != null)
                    {
                        diaryNode.label.Visible = false;
                    }
                    else if (diaryNode.label != null)
                    {
                        diaryNode.label.Visible = true;
                    }
                }
            }
        }

        private void changeColor(int i)
        {
            if (i == 1) // up
            {
                colorIndex++;
                if (colorIndex == colors.Count / 5)
                {
                    colorIndex = 0;
                }
            }
            else // down
            {
                colorIndex--;
                if (colorIndex == -1)
                {
                    colorIndex = colors.Count / 5 - 1;
                }
            }
            colorBackGround = colors[colorIndex * 5];
            colorText = colors[colorIndex * 5 + 1];
            colorLabel = colors[colorIndex * 5 + 2];
            colorTextChosen = colors[colorIndex * 5 + 3];
            colorChosen = colors[colorIndex * 5 + 4];
            foreach (RichTextBox rtb in dates)
            {
                rtb.BackColor = colorBackGround;
                if (rtb.ForeColor != Color.Gray) rtb.ForeColor = colorText;
            }
            foreach (TextBox tb in week)
            {
                tb.BackColor = colorBackGround;
                tb.ForeColor = colorText;
            }
            foreach (Label l in notesTitle)
            {
                l.BackColor = colorLabel;
                l.ForeColor = colorText;
            }
            Month.ForeColor = colorText;
            nextMonth.BackColor = colorBackGround;
            nextMonth.ForeColor = colorText;
            lastMonth.BackColor = colorBackGround;
            lastMonth.ForeColor = colorText;
            this.BackColor = colorBackGround;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // 判斷是否按下 Ctrl + S
            if (keyData == (Keys.Control | Keys.F))
            {
                Search search = new Search();
                search.Show();
                return true;    // 表示該按鍵組合已處理
            }
            // 判斷是否按下 Ctrl + G
            if (keyData == (Keys.Control | Keys.G))
            {
                List<float> stars = new List<float>();
                stars = DiaryTree.get30daysStar(year, month, 31);
                Graphic graphic = new Graphic(stars);
                graphic.Show();
            }
            // 判斷是否按下上鍵
            if (keyData == Keys.Up)
            {
                Console.WriteLine("Up");
                changeColor(1);
                return true;
            }
            // 判斷是否按下下鍵
            if (keyData == Keys.Down)
            {
                Console.WriteLine("Down");
                changeColor(0);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public static void showSearchedDiary(List<DiaryNode> list)
        {
            foreach (Label l in mainForm.notesTitle)
            {
                l.BackColor = mainForm.colorLabel;
                l.ForeColor = mainForm.colorText;
            }
            foreach (DiaryNode node in list)
            {
                node.label.BackColor = mainForm.colorChosen;
                node.label.ForeColor = mainForm.colorTextChosen;
            }
        }

        public void turnToDate(int year, int month)
        {
            this.year = year;
            this.month = month;
            updateCalendar();
        }

        public int GetYear()
        {
            return year;
        }

        public int GetMonth()
        {
            return month;
        }

    }
}
