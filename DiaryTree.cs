using System;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;


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
            DiaryTreeNode monthNode = searchMonth(diaryNode.month, yearNode);
            DiaryTreeNode dayNode = searchDay(diaryNode.day, monthNode);
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
            List<DiaryNode> diaryNode1s = SearchDiary(diaryNode.year, diaryNode.month, diaryNode.day);

            DiaryNode diaryNode1 = null;
            if (diaryNode1s == null) return;

            for (int i = 0; i < diaryNode1s.Count(); i++)
            {
                if (diaryNode1s[i].title == diaryNode.title)
                {
                    diaryNode1 = diaryNode1s[i];
                    break;
                }
            }

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
            diaryNode.label = null;
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
                    string temp = sr.ReadToEnd();
                    try
                    {
                        //new JsonSerializerSettings()
                        //{
                        //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        //}
                        DiaryNode diaryNode = JsonConvert.DeserializeObject<DiaryNode>(temp);
                        if (diaryNode != null)
                        {
                            AddDiary(diaryNode);
                        }
                    }
                    catch (JsonSerializationException ex)
                    {
                        // Handle the exception, possibly log it or inform the user
                        Console.WriteLine($"Error deserializing file {fileName}: {ex.Message}");
                    }
                }
            }
        }

        //限定root使用
        public static List<DiaryNode> SearchDiary(int year, int month, int day)
        {
            DiaryTreeNode diaryTreeNode = root;

            //尋找年
            while (diaryTreeNode != null && diaryTreeNode.year != year)
            {
                diaryTreeNode = diaryTreeNode.sibling;
            }
            if (diaryTreeNode == null) return null;

            //尋找月
            diaryTreeNode = diaryTreeNode.child;
            while (diaryTreeNode != null && diaryTreeNode.month != month)
            {
                diaryTreeNode = diaryTreeNode.sibling;
            }
            if (diaryTreeNode == null) return null;

            //尋找日
            diaryTreeNode = diaryTreeNode.child;
            while (diaryTreeNode != null && diaryTreeNode.day != day)
            {
                diaryTreeNode = diaryTreeNode.sibling;
            }
            if (diaryTreeNode == null) return null;

            return diaryTreeNode.nodes;
        }

        public static List<DiaryNode> SearchDiaryTag(string tag, int year, int month, int days)
        {
            List<DiaryNode> ret = new List<DiaryNode>();

            for(int i = 1;i <= days;i++)
            {
                foreach(DiaryNode node in SearchDiary(year,month,days))
                {
                    foreach(string str in node.tag)
                    {
                        if(str == tag)
                        {
                            ret.Add(node);
                            break;
                        }
                    }
                }
            }

            return ret;
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
