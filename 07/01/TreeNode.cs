namespace aoc {
    class TreeNode {
        string name;
        bool type;
        int size;
        List<TreeNode> children;

        public TreeNode(string _name, bool _type, int _size) {
            name = _name;
            type = _type;
            size = _size;
            children = new List<TreeNode>();
        }

        public void AddChild(TreeNode child) {
            children.Add(child);
        }
    }

}