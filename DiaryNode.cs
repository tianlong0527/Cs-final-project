using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace personal_note
{
    internal class DiaryNode
    {
        public int month, day, year;
        public string title;
        public List<String> tag;
        //bool old;
        public string content;
        public Label label;
        public int index;

        public DiaryNode(int year, int month, int day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.tag = new List<String>();
            title = "嗨";
            content = "嗨嗨";
        }

        public void showDiaryNode()
        {
            Console.WriteLine($"year:{year} month:{month} day:{day}");
            for (int i = 0; i < tag.Count; i++)
            {
                Console.Write( tag[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(title + "\n" + content);
        }
    }
}
