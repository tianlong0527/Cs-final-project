using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace personal_note
{
    public partial class Note : Form
    {
        bool isTitleEmpty = true, isNoteEmpty = true,isStore = true;
        int storeStar;
        internal DiaryNode diaryNode;
        List<string> list = new List<string>();
        List<PictureBox> pictureBoxes = new List<PictureBox>();

        List<string> quesion = new List<string>{ "早安，平安健康", "打麻將時，湊齊Pi就胡牌了!",
            "為什麼日本雞蛋喜歡一粒一粒?\n因為他們不喜歡盒蛋" ,"為什麼美國要在日本投下原子彈?\n因為他們有招核天皇",
            "料理鼠王把他畢生的研究成果紀錄在一本書上，那本書叫做鼠王筆記本","白冰冰確診會變什麼?\n自冰冰",
            "為什麼多啦A夢和大雄知道二戰日本會輸\n因為他們是胖子與小男孩","期末加油!",
            "皮卡丘跳遠\n皮卡乒乓乒乓乒乓丘丘丘丘兵","有一天我幫我家的貓換比較細的貓砂\n結果牠很不爽的跟我說：這沙小"};
        public Note(int year, int month, int day)
        {
            InitializeComponent();
            InitialPBox();
            this.diaryNode = new DiaryNode(year, month, day);
            storeStar = diaryNode.star;
            rtbDate.Text = $"{year}年 {month}月 {day}日";
            Random random = new Random();
            rtbNote.Text = quesion[random.Next(0, quesion.Count)];
        }

        public Note(DiaryNode diaryNode)
        {
            InitializeComponent();
            InitialPBox();
            this.diaryNode = diaryNode;
            showStar(diaryNode.star - 1);
            rtbTitle.Text = diaryNode.title;
            rtbTitle.ForeColor = Color.White;
            rtbNote.Text = diaryNode.content;
            rtbNote.ForeColor = Color.White;
            isNoteEmpty = false;
            isTitleEmpty = false;
            foreach(string str in diaryNode.tag){
                lblTagText.Text += str + " ";
            }
            rtbDate.Text = $"{diaryNode.year}年 {diaryNode.month}月 {diaryNode.day}日";
        }

        private void InitialPBox()
        {
            pictureBoxes.Add(pBox1);
            pictureBoxes.Add(pBox2);
            pictureBoxes.Add(pBox3);
            pictureBoxes.Add(pBox4);
            pictureBoxes.Add(pBox5);
        }
        private void rtbTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // 禁止 Enter 键的输入
                e.Handled = true;          // 防止其他事件触发
            }

            if (isTitleEmpty) rtbTitle.Text = "";
            isTitleEmpty = false;
            rtbTitle.ForeColor = Color.White;
            if (e.KeyCode == Keys.Back && rtbTitle.Text.Length <= 1)
            {
                isTitleEmpty = true;
                rtbTitle.Text = "Title";
                rtbTitle.ForeColor = Color.Gray;
            }
        }

        private void Note_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!isStore)
            {
                DialogResult result = MessageBox.Show("是否存儲內容?", "儲存", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Save();
                }
                else if (result == DialogResult.No) Console.WriteLine("不要儲存");
                else if (result == DialogResult.Cancel)
                {
                    Console.WriteLine("取消離開");
                    e.Cancel = true;
                }
            }

            Form1.mainForm.updateCalendar();
            //DiaryTree.showTree(DiaryTree.root);
            //Console.WriteLine("結束遍歷");
        }



        private void rtbTitle_TextChanged(object sender, EventArgs e)
        {
            isStore = false;
            //Console.WriteLine(diaryNode.title);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(btnAdd.Text.Equals("Add"))
            {
                rtbAdd.Visible = true;
                lblTagText.Visible = false;
                btnAdd.Text = "Ensure";
            }else if (btnAdd.Text.Equals("Ensure"))
            {
                isStore = false;
                lblTagText.Text += rtbAdd.Text + ", ";
                lblTagText.Visible = true;
                rtbAdd.Visible = false;
                list.Add(rtbAdd.Text);
                rtbAdd.Text = "";
                btnAdd.Text = "Add";
            }
        }

        private void rtbNote_TextChanged(object sender, EventArgs e)
        {
            isStore = false;
            //Console.WriteLine(diaryNode.content);
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (isNoteEmpty) rtbNote.Text = "";
            isNoteEmpty = false;
            rtbNote.ForeColor = Color.White;
            if (e.KeyCode == Keys.Back && rtbNote.Text.Length <= 1)
            {
                Random random = new Random();
                isNoteEmpty = true;
                rtbNote.Text = quesion[random.Next(0, quesion.Count)];
                rtbNote.ForeColor = Color.Gray;
            }
        }

        private void pBox_Click(object sender, EventArgs e)
        {
            for(int i = 0;i < 5;i++)
            {
                if ((PictureBox)sender == pictureBoxes[i])
                {
                    showStar(i);
                    break;  
                }
            }
        }

        private void showStar(int num)
        {
            if (diaryNode.star != num + 1) isStore = false;
            storeStar = num + 1;
            int i = 0;
            for (; i <= num; i++)
            {
                pictureBoxes[i].Image = Image.FromFile("../../Image/yellowStar.png");
            }
            //i++;

            for (; i < 5; i++)
            {
                pictureBoxes[i].Image = Image.FromFile("../../Image/star.png");
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // 判斷是否按下 Ctrl + S
            if (keyData == (Keys.Control | Keys.S))
            {
                isStore = true;
                //如果是新開的，就要新增
                Save();
                //SaveFormData(); // 執行保存動作
                return true;    // 表示該按鍵組合已處理
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Save()
        {
            diaryNode.title = rtbTitle.Text;
            diaryNode.content = rtbNote.Text;
            diaryNode.star = storeStar;
            foreach(string str in list)
            {
                diaryNode.tag.Add(str);
            }
            list.Clear();

            if (!diaryNode.old) DiaryTree.AddDiary(diaryNode);
            diaryNode.old = true;
            DiaryTree.SaveDiary(diaryNode);
            diaryNode.showDiaryNode();
            Console.WriteLine("已儲存");
        }

    }
}
