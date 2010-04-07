using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using EtherSoftware.NewsPresenter.Common;
using System;

namespace EtherSoftware.NewsPresenter.View.Component
{
    /// <summary>
    /// Interaction logic for CategoryList.xaml
    /// </summary>
    public partial class CategoryContainer : UserControl
    {
        public CategoryContainer()
        {
            InitializeComponent();
            categories = new Dictionary<Guid, CategoryItem>();
        }

        public CategoryItem AddCategory(Category category)
        {
            if (!this.categories.Keys.Contains(category.Id)) {
                var categoryItem = new CategoryItem();
                categoryItem.Category = category;
                categoryItem.SelectedPublisherChanged += new SelectedPublisherChangedEventHandler(category_SelectedPublisherChanged);
                categories.Add(category.Id, categoryItem);
                this.categoryList.Children.Add(categoryItem);
                return categoryItem;
            } else {
                return this.categories[category.Id];
            }
        }

        public void AddCategories(IEnumerable<Category> categories)
        {
            foreach (var category in categories) {
                AddCategory(category);
            }
        }

        public void RenameCategory(Category category)
        {
            if (this.categories.Keys.Contains(category.Id)) {
                var categoryItem = this.categories[category.Id];
                categoryItem.Category = category;
                categoryItem.SelectedPublisherChanged += new SelectedPublisherChangedEventHandler(category_SelectedPublisherChanged);
            }
        }

        public void RemoveCategory(Category category)
        {
            if (this.categories.Keys.Contains(category.Id)) {
                var categoryItem = this.categories[category.Id];
                this.categoryList.Children.Remove(categoryItem);
                this.categories.Remove(category.Id);
            }
        }

        public void AddToCategory(Category category, Publisher publisher)
        {
            if (this.categories.Keys.Contains(category.Id)) {
                var categoryItem = this.categories[category.Id];
                categoryItem.AddPublisher(publisher);
            }
        }

        public IList<Category> GetCategories()
        {
            return (from CategoryItem ci in categories.Values select ci.Category).ToList<Category>();
        }

        public event SelectionChangedEventHandler SelectionChanged;

        private void category_SelectedPublisherChanged(CategoryItem obj, Publisher sndr)
        {
            if (SelectionChanged != null)
                SelectionChanged(obj, sndr);
        }

        private IDictionary<Guid, CategoryItem> categories;
    }
    public delegate void SelectionChangedEventHandler(CategoryItem category, Publisher publisher);
}
