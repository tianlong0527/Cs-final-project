using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_note
{
    internal class DiaryTree
    {
        public DiaryTree() { }

        public void AddDiary(string date, string content)
        {
            // Add diary to the tree
        }

        public void DeleteDiary(string date)
        {
            // Delete diary from the tree
        }

        public void ModifyDiary(string date, string content)
        {
            // Modify diary in the tree
        }

        public string SearchDiary(string date)
        {
            // Search diary in the tree
            return "";
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
        public string date;
        public string content;
        // public DiaryNode left;
        // public DiaryNode right;

        public DiaryNode(string date, string content)
        {
            this.date = date;
            this.content = content;
            // left = null;
            // right = null;
        }
    }
}
