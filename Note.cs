﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace personal_note
{
    public partial class Note : Form
    {
        bool isTitleEmpty = true, isNoteEmpty = true,isStore = true;
        internal DiaryNode diaryNode;
        List<string> list = new List<string>();

        List<string> quesion = new List<string>{ "哈哈","測試","嗨嗨" };
        public Note(int year, int month, int day)
        {
            InitializeComponent();
            this.diaryNode = new DiaryNode(year, month, day);
            rtbDate.Text = $"{year}年 {month}月 {day}日";
        }

        public Note(DiaryNode diaryNode)
        {
            InitializeComponent();
            this.diaryNode = diaryNode;
            rtbTitle.Text = diaryNode.title;
            rtbTitle.ForeColor = Color.White;
            rtbNote.Text = diaryNode.content;
            rtbNote.ForeColor = Color.White;
            isNoteEmpty = false;
            isTitleEmpty = false;
            foreach(string str in diaryNode.tag){
                rtbTag.Text += str + ", ";
            }
            rtbDate.Text = $"{diaryNode.year}年 {diaryNode.month}月 {diaryNode.day}日";
        }

        private void rtbTitle_KeyDown(object sender, KeyEventArgs e)
        {
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
                rtbTag.Visible = false;
                btnAdd.Text = "Ensure";
            }else if (btnAdd.Text.Equals("Ensure"))
            {
                isStore = false;
                rtbTag.Text += rtbAdd.Text + ", ";
                rtbTag.Visible = true;
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
