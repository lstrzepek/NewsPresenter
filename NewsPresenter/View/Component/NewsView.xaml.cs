using System.Windows.Controls;
using EtherSoftware.NewsPresenter.Common;
using System.Windows;
using System.Collections.Generic;
using System;
using System.Text;

namespace EtherSoftware.NewsPresenter.View.Component {
    /// <summary>
    /// Interaction logic for NewsView.xaml
    /// </summary>
    public partial class NewsView : TabItem {
        public NewsView(Publisher publisher) {
            InitializeComponent();
            this.publisher = publisher;
            this.newsList.SelectionChanged +=
                new System.Windows.Controls.SelectionChangedEventHandler(newsList_SelectionChanged);
            foreach (var message in this.publisher.Messages) {
                ListViewItem item = new ListViewItem();
                item.Content = message;
                if (!message.Viewed)
                    item.FontWeight = FontWeights.Bold;
                this.newsList.Items.Add(item);
            }
        }

        private void newsList_SelectionChanged(object publisher, SelectionChangedEventArgs e) {
            var item = this.newsList.SelectedItem as ListViewItem;
            item.FontWeight = FontWeights.Regular;
            var message = item.Content as Message;
            //this.newsContent.Doc
        }

        private Publisher publisher;
    }
}
