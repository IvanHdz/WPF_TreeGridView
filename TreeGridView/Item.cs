using TreeGridView.Common;

namespace TreeGridView
{
    public class Item : TreeGridElement
    {
        public int Value { get; private set; }
        public string Name { get; private set; }

        public Item(string name, int value, bool hasChildren)
        {
            // Initialize the item
            Name = name;
            Value = value;
            HasChildren = hasChildren;
        }
    }
}