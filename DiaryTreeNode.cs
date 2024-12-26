using System.Collections.Generic;

namespace personal_note
{
    internal class DiaryTreeNode
    {
        public int year, month, day;
        public List<DiaryNode> nodes;
        public DiaryTreeNode sibling;
        public DiaryTreeNode child;

        public DiaryTreeNode(int year, int month, int day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
            this.nodes = new List<DiaryNode>();
            this.sibling = null;
            this.child = null;
        }
    }
}
