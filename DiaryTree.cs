using System;
using System.Linq;
using Newtonsoft.Json;
using System.IO;


namespace personal_note
{
    internal class DiaryTree
    {
        public static DiaryTreeNode root = new DiaryTreeNode(0, 0, 0);
        public static void BuildTreeFromFiles()
        {
            // if data folder is empty, return
            if (!Directory.Exists(@"./../../data/"))
            {
                Directory.CreateDirectory(@"./../../data/");
                return;
            }
            string[] files = Directory.GetFiles(@"./../../data/");
            foreach (string file in files)
            {
                LoadDiary(file);
            }
        }

        public static void AddDiary(DiaryNode diaryNode)
        {
            DiaryTreeNode yearNode = searchYear(diaryNode.year, root);
            //Console.WriteLine($"add {yearNode.year}/{yearNode.month}/{yearNode.day}\n");
            DiaryTreeNode monthNode = searchMonth(diaryNode.month, yearNode);
            //Console.WriteLine(yearNode.child == monthNode);
            //Console.WriteLine($"add {monthNode.year}/{monthNode.month}/{monthNode.day}\n");
            DiaryTreeNode dayNode = searchDay(diaryNode.day, monthNode);
            //Console.WriteLine($"add {dayNode.year}/{dayNode.month}/{dayNode.day}\n");
            dayNode.nodes.Add(diaryNode);
            diaryNode.index = dayNode.nodes.Count() - 1;
            Console.WriteLine($"新增成功: {diaryNode.year}年{diaryNode.month}月{diaryNode.day} \n");
        }

        public static DiaryTreeNode searchYear(int year, DiaryTreeNode DiaryTreeNode)
        {
            DiaryTreeNode copTree = null;  //第一次一定是root，所以不會發生空指標
            while (DiaryTreeNode != null)
            {
                if (DiaryTreeNode.year == year)
                {
                    return DiaryTreeNode;
                }
                copTree = DiaryTreeNode;
                DiaryTreeNode = DiaryTreeNode.sibling;
            }

            DiaryTreeNode DiaryTreeNode1 = new DiaryTreeNode(year, 0, 0);
            copTree.sibling = DiaryTreeNode1;
            return DiaryTreeNode1;
        }

        public static DiaryTreeNode searchMonth(int month, DiaryTreeNode yearNode)
        {
            DiaryTreeNode copTree = yearNode.child;
            if (copTree == null)                  //代表yearNode的child是null，要新增一個給他
            {
                DiaryTreeNode DiaryTreeNode = new DiaryTreeNode(0, month, 0);
                yearNode.child = DiaryTreeNode;
                return DiaryTreeNode;
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

            DiaryTreeNode DiaryTreeNode1 = new DiaryTreeNode(0, month, 0);
            copTree.sibling = DiaryTreeNode1;
            return DiaryTreeNode1;
        }

        public static DiaryTreeNode searchDay(int day, DiaryTreeNode monthNode)
        {
            DiaryTreeNode copTree = monthNode.child;
            if (copTree == null)                  //代表monthNode的child是null，要新增一個給他
            {
                DiaryTreeNode DiaryTreeNode = new DiaryTreeNode(0, 0, day);
                monthNode.child = DiaryTreeNode;
                return DiaryTreeNode;
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

            DiaryTreeNode DiaryTreeNode1 = new DiaryTreeNode(-1, -1, day);
            copTree.sibling = DiaryTreeNode1;
            return DiaryTreeNode1;
        }



        //限定root使用
        public static void DeleteDiary(DiaryNode diaryNode)
        {
            DiaryNode diaryNode1 = SearchDiary(diaryNode.year, diaryNode.month, diaryNode.day, diaryNode.title);
            if (diaryNode1 == null)
            {
                Console.WriteLine("找不到");
                return;
            }
            DiaryTreeNode yearNode = searchYear(diaryNode.year, root);
            DiaryTreeNode monthNode = searchMonth(diaryNode.month, yearNode);
            DiaryTreeNode dayNode = searchDay(diaryNode.day, monthNode);
            dayNode.nodes.Remove(diaryNode);
            Console.WriteLine($"刪除成功: {diaryNode.month}月{diaryNode.day} \n");
        }

        public static void ModifyDiary(string date, string content)
        {
            // Modify diary in the tree
        }

        public static void SaveDiary(DiaryNode diaryNode)
        {
            // Save diary to the file
            string fileName = $"{diaryNode.year}-{diaryNode.month}-{diaryNode.day}-{diaryNode.index}.json";
            StreamWriter sw = File.CreateText($"../../data/{fileName}");
            sw.Write(JsonConvert.SerializeObject(diaryNode, Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
            sw.Close();
        }

        public static void LoadDiary(string fileName)
        {
            // Load diary from the file
            // string fileName = $"{diaryNode.year}-{diaryNode.month}-{diaryNode.day}-{diaryNode.index}.json";
            if (File.Exists(fileName))
            {
                using (StreamReader sr = File.OpenText(fileName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    DiaryNode diaryNode = (DiaryNode)serializer.Deserialize(sr, typeof(DiaryNode));
                    if (diaryNode != null)
                    {
                        AddDiary(diaryNode);
                        // TODO: check if the diary is already in the tree
                    }
                }
            }
        }

        //限定root使用
        public static DiaryNode SearchDiary(int year, int month, int day, string title)
        {
            DiaryTreeNode DiaryTreeNode = root;

            //尋找年
            while (DiaryTreeNode != null && DiaryTreeNode.year != year)
            {
                DiaryTreeNode = DiaryTreeNode.sibling;
            }
            if (DiaryTreeNode == null) return null;

            //尋找月
            DiaryTreeNode = DiaryTreeNode.child;
            while (DiaryTreeNode != null && DiaryTreeNode.month != month)
            {
                DiaryTreeNode = DiaryTreeNode.sibling;
            }
            if (DiaryTreeNode == null) return null;

            //尋找日
            DiaryTreeNode = DiaryTreeNode.child;
            while (DiaryTreeNode != null && DiaryTreeNode.day != day)
            {
                DiaryTreeNode = DiaryTreeNode.sibling;
            }
            if (DiaryTreeNode == null) return null;

            //尋找符合的title
            for (int i = 0; i < DiaryTreeNode.nodes.Count(); i++)
            {
                if (DiaryTreeNode.nodes[i].title == title) return DiaryTreeNode.nodes[i];
            }
            return null;
        }


        public static void showTree(DiaryTreeNode diaryTree)
        {
            if(diaryTree == null) return;

            //Console.WriteLine($"{diaryTree.year}/{diaryTree.month}/{diaryTree.day}\n");
            if(diaryTree.day != 0)
            {
                for(int i = 0; i < diaryTree.nodes.Count();i++)
                {
                    diaryTree.nodes[i].showDiaryNode();
                }
            }
            else
            {
                showTree(diaryTree.sibling);
                showTree(diaryTree.child);
            }
        }
    }
}
