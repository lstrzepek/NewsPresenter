using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EtherSoftware.NewsPresenter.Common;

namespace EtherSoftware.NewsPresenter.View.Component {
    /// <summary>
    /// Interaction logic for SubscribeWindow.xaml
    /// </summary>
    public partial class SubscribeWindow : Window {
        public SubscribeWindow() {
            InitializeComponent();
        }

        public string Source {
            get {
                return this.sourceValue.Text;
            }
        }

        public Category Category
        {
            get {
                return this.categoriesCombo.SelectedValue as Category;
            }
        }

        public void AddCategory(Category category)
        {
            this.categoriesCombo.Items.Add(category);
        }

        public void SetCategories(IList<Category> categories) {
            foreach (var cat in categories) {
                this.categoriesCombo.Items.Add(cat);
            }
        }

        public void SelectCategory(Category category)
        {
            if(this.categoriesCombo.Items.Contains(category))
            this.categoriesCombo.SelectedItem = category;
        }

        public void ClearCategories() {
            this.categoriesCombo.Items.Clear();
        }

        private void subscribeButton_Click(object publisher, RoutedEventArgs e) {
            this.Close();
        }

        private void cancelButton_Click(object publisher, RoutedEventArgs e) {
            this.Close();
        }

        private void categoriesCombo_SelectionChanged(object publisher, SelectionChangedEventArgs e) {
            if (this.sourceValue.Text.Length > 0 && this.categoriesCombo.SelectedValue != null)
                this.subscribeButton.IsEnabled = true;
            else
                this.subscribeButton.IsEnabled = false;
        }

        private void sourceValue_TextChanged(object publisher, TextChangedEventArgs e) {
            if (this.sourceValue.Text.Length > 0 && this.categoriesCombo.SelectedValue != null)
                this.subscribeButton.IsEnabled = true;
            else
                this.subscribeButton.IsEnabled = false;
        }
    }
}
