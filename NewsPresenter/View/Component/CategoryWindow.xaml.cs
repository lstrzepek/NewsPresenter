using System.Windows;
using System.Windows.Controls;

namespace EtherSoftware.NewsPresenter.View.Component {
    /// <summary>
    /// Interaction logic for CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow : Window {
        public CategoryWindow() {
            InitializeComponent();
            this.nameValue.Focus();
        }

        public string CategoryName {
            get {
                return this.nameValue.Text;
            }
            set {
                this.nameValue.Text = value;
            }
        }

        private void nameValue_TextChanged(object publisher, TextChangedEventArgs e) {
            TextBox tb = (TextBox)publisher;
            if (tb.Text.Length > 0)
                this.okButton.IsEnabled = true;
            else
                this.okButton.IsEnabled = false;
        }

        private void okButton_Click(object publisher, RoutedEventArgs e) {
            this.DialogResult = true;
            this.Close();
        }

        private void cancelButton_Click(object publisher, RoutedEventArgs e) {
            this.DialogResult = false;
            this.Close();
        }
    }
}
