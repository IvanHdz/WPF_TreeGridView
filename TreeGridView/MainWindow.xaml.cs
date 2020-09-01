using System.Windows;
using TreeGridView.Common;

namespace TreeGridView
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int Levels = 3;
        private const int Roots = 100;
        private const int ItemsPerLevel = 5;

        private int value;
        private TreeGridModel model;

        public MainWindow()
        {
            // Initialize the component
            InitializeComponent();

            // Initialize the model
            InitModel();

            // Set the model for the grid
            grid.ItemsSource = model.FlatModel;
        }

        private void InitModel()
        {
            // Create the model
            model = new TreeGridModel();

            // Add a bunch of items at the root
            for (int count = 0; count < Roots; count++)
            {
                // Create the root item
                Item root = new Item(string.Format("Root {0}", count), value++, true);

                // Add children to the root
                AddChildren(root);

                // Add the root to the model
                model.Add(root);
            }
        }

        private int C(Item i)
        {
            int cnt = i.Children.Count;

            foreach (Item child in i.Children)
            {
                cnt += C(child);
            }

            return cnt;
        }

        private void AddChildren(Item item, int level = 0)
        {
            // Determine if the item will have children
            bool hasChildren = (level < Levels);

            // Create children for the item
            for (int count = 0; count < ItemsPerLevel; count++)
            {
                // Create the child
                Item child = new Item(string.Format("Child {0}, Level {1}", count, level), value++, hasChildren);

                // Does the child have children?
                if (hasChildren)
                {
                    // Recursively add children to the child
                    AddChildren(child, (level + 1));
                }

                // Add the child to the item
                item.Children.Add(child);
            }
        }
    }
}