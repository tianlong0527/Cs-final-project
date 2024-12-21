using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace personal_note
{
    internal class DiaryTree
    {
        int year;
        public List<List<List<DiaryNode>>> root = new List<List<List<DiaryNode>>>();
        public DiaryTree(int year) 
        {
            this.year = year;
            for (int i = 0; i < 13; i++)
            {
                root.Add(new List<List<DiaryNode>>());
                for (int j = 0; j < 32; j++)
                {
                    root[i].Add(new List<DiaryNode>());
                }
            }
        }

        public void AddDiary(DiaryNode diaryNode)
        {
            root[diaryNode.month][diaryNode.day].Add(diaryNode);
            Console.WriteLine($"新增成功: {diaryNode.month}月{diaryNode.day} \n");
        }

        public void DeleteDiary(DiaryNode diaryNode)
        {
            root[diaryNode.month][diaryNode.day].Remove(diaryNode);
            Console.WriteLine($"新增成功: {diaryNode.month}月{diaryNode.day} \n");
        }

        public void ModifyDiary(string date, string content)
        {
            // Modify diary in the tree
        }

        public DiaryNode SearchDiary(int month,int day,string stitle)
        {
            for(int i = 0;i < root[month][day].Count;i++)
            {
                if (root[month][day][i].title.Equals(stitle)) return root[month][day][i];
            }
            return null;
        }

        public void SaveDiary()
        {
            // Save diary to the file
        }

        public void LoadDiary()
        {
            // Load diary from the file
        }
    }

    internal class DiaryNode
    {
        public int month,day;
        public string title;
        public List<String> tag;
        bool old;
        public string content;

        public DiaryNode(int month,int day)
        {
            this.month = month;
            this.day = day;
        }
    }
}
