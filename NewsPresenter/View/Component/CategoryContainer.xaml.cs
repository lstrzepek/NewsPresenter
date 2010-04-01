using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using EtherSoftware.NewsPresenter.Common;

namespace EtherSoftware.NewsPresenter.View.Component {
    /// <summary>
    /// Interaction logic for CategoryList.xaml
    /// </summary>
    public partial class CategoryContainer : UserControl {
        public CategoryContainer() {
            InitializeComponent();
            categories = new Dictionary<string, CategoryItem>();
        }

        public void AddCategory(string categoryName) {
            if (!this.categories.Keys.Contains(categoryName)) {
                var category = new CategoryItem();
                category.CategoryName = categoryName;
                category.SelectedPublisherChanged += new SelectedPublisherChangedEventHandler(category_SelectedPublisherChanged);
                categories.Add(categoryName, category);
                this.categoryList.Children.Add(category);
            }
        }

        public void AddCategories(IEnumerable<Category> categories) {
            foreach (var category in categories) {
                AddCategory(category.Name);
            }
            
        }

        public void RenameCategory(string categoryName, string newName) {
            if (this.categories.Keys.Contains(categoryName)) {
                var category = this.categories[categoryName];
                category.CategoryName = newName;
                category.SelectedPublisherChanged += new SelectedPublisherChangedEventHandler(category_SelectedPublisherChanged);
                this.categories.Remove(categoryName);
                this.categories.Add(newName, category);
            }
        }

        public void RemoveCategory(string categoryName) {
            if (this.categories.Keys.Contains(categoryName)) {
                var category = this.categories[categoryName];
                this.categoryList.Children.Remove(category);
                this.categories.Remove(categoryName);
            }
        }

        public void AddToCategory(string categoryName, Publisher publisher) {
            if (this.categories.Keys.Contains(categoryName)) {
                var category = this.categories[categoryName];
                category.AddPublisher(publisher);
            }
        }

        public IList<string> GetCategories() {
            return categories.Keys.ToList();
        }

        public event SelectionChangedEventHandler SelectionChanged;

        private void category_SelectedPublisherChanged(CategoryItem obj, Publisher sndr) {
            if (SelectionChanged != null)
                SelectionChanged(obj, sndr);
        }

        private IDictionary<string, CategoryItem> categories;
    }
    public delegate void SelectionChangedEventHandler(CategoryItem category, Publisher publisher);
}
