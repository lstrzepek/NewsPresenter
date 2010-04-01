using System.Collections.Generic;
using System.Windows.Controls;
using EtherSoftware.NewsPresenter.Common;

namespace EtherSoftware.NewsPresenter.View.Component {
    /// <summary>
    /// Interaction logic for NewsViewContainer.xaml
    /// </summary>
    public partial class NewsViewContainer : UserControl {
        public NewsViewContainer() {
            InitializeComponent();
            views = new Dictionary<Publisher, NewsView>();
        }

        public void ShowView(Publisher publisher) {
            if (views.ContainsKey(publisher)) {
                this.newsContainer.SelectedItem = views[publisher];
            } else {
                AddView(publisher);
            }
        }

        private void AddView(Publisher publisher) {
            var news = new NewsView(publisher);
            news.Header = publisher.Name;
            views.Add(publisher, news);
            this.newsContainer.SelectedIndex = this.newsContainer.Items.Add(news);
        }

        private IDictionary<Publisher, NewsView> views;
    }
}
