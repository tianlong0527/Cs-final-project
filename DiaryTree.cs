using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace personal_note
{
    internal class DiaryTree
    {
        int year,month,day;
        List<DiaryNode> nodes;
        DiaryTree sibling;
        DiaryTree child;

        public DiaryTree(int year,int month,int day) 
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.nodes = new List<DiaryNode>(); 
            this.sibling = null;
            this.child = null;
        }

        public void AddDiary(DiaryNode diaryNode)
        {
            DiaryTree yearNode = searchYear(diaryNode.year, this);
            DiaryTree monthNode = searchMonth(diaryNode.month, yearNode);
            DiaryTree dayNode = searchDay(diaryNode.day, monthNode);
            dayNode.nodes.Add(diaryNode);
            Console.WriteLine($"新增成功: {diaryNode.year}年{diaryNode.month}月{diaryNode.day} \n");
        }

        public DiaryTree searchYear(int year,DiaryTree diaryTree)
        {
            DiaryTree copTree = null;  //第一次一定是root，所以不會發生空指標
            while(diaryTree!= null)
            {
                if(diaryTree.year == year)
                {
                    return diaryTree;
                }
                copTree = diaryTree;
                diaryTree = diaryTree.sibling;
            }

            DiaryTree diaryTree1 = new DiaryTree(year,-1,-1);
            copTree.sibling = diaryTree1;
            return diaryTree1;
        }

        public DiaryTree searchMonth(int month, DiaryTree yearNode)
        {
            DiaryTree copTree = yearNode.child;
            if(copTree == null)                  //代表yearNode的child是null，要新增一個給他
            {
                DiaryTree diaryTree = new DiaryTree(-1, month, -1);
                yearNode.child = diaryTree;
                return diaryTree;
            }

            yearNode = yearNode.child;
            while (yearNode != null)
            {
                if (yearNode.month == month)
                {
                    return yearNode;
                }
                copTree = yearNode;
                yearNode = yearNode.sibling;
            }

            DiaryTree diaryTree1 = new DiaryTree(-1, month, -1);
            copTree.sibling = diaryTree1;
            return diaryTree1;
        }

        public DiaryTree searchDay(int day, DiaryTree monthNode)
        {
            DiaryTree copTree = monthNode.child;
            if (copTree == null)                  //代表monthNode的child是null，要新增一個給他
            {
                DiaryTree diaryTree = new DiaryTree(-1, -1, day);
                monthNode.child = diaryTree;
                return diaryTree;
            }

            monthNode = monthNode.child;
            while (monthNode != null)
            {
                if (monthNode.day == day)
                {
                    return monthNode;
                }
                copTree = monthNode;
                monthNode = monthNode.sibling;
            }

            DiaryTree diaryTree1 = new DiaryTree(-1, -1, day);
            copTree.sibling = diaryTree1;
            return diaryTree1;
        }



        //限定root使用
        public void DeleteDiary(DiaryNode diaryNode)
        {
            DiaryNode diaryNode1 = SearchDiary(diaryNode.year,diaryNode.month,diaryNode.day,diaryNode.title);
            if(diaryNode1 == null)
            {
                Console.WriteLine("找不到");
                return;
            }
            DiaryTree yearNode = searchYear(diaryNode.year, this);
            DiaryTree monthNode = searchMonth(diaryNode.month, yearNode);
            DiaryTree dayNode = searchDay(diaryNode.day, monthNode);
            dayNode.nodes.Remove(diaryNode);
            Console.WriteLine($"刪除成功: {diaryNode.month}月{diaryNode.day} \n");
        }

        public void ModifyDiary(string date, string content)
        {
            // Modify diary in the tree
        }

        //限定root使用
        public DiaryNode SearchDiary(int year,int month,int day,string title)
        {
            DiaryTree diaryTree = this;

            //尋找年
            while(diaryTree != null && diaryTree.year != year)
            {
                diaryTree = diaryTree.sibling;
            }
            if (diaryTree == null) return null;

            //尋找月
            diaryTree = diaryTree.child;
            while (diaryTree != null && diaryTree.month != month)
            {
                diaryTree = diaryTree.sibling;
            }
            if (diaryTree == null) return null;

            //尋找日
            diaryTree = diaryTree.child;
            while (diaryTree != null && diaryTree.day != day)
            {
                diaryTree = diaryTree.sibling;
            }
            if (diaryTree == null) return null;

            //尋找符合的title
            for(int i = 0;i < diaryTree.nodes.Count(); i++)
            {
                if (diaryTree.nodes[i].title == title) return diaryTree.nodes[i];
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

        public void showTree()
        {
            ;
        }
    }

    internal class DiaryNode
    {
        public int month,day,year;
        public string title;
        public List<String> tag;
        //bool old;
        public string content;

        public DiaryNode(int year,int month,int day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.tag = new List<String>();
            title = "嗨";
            content = "嗨嗨";
        }
    }
}
