﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EtherSoftware.NewsPresenter.Common;

namespace EtherSoftware.NewsPresenter.View.Component
{
    /// <summary>
    /// Interaction logic for Category.xaml
    /// </summary>
    public partial class CategoryItem : UserControl
    {
        public CategoryItem()
        {
            InitializeComponent();
            this.publishersList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(publishersList_SelectionChanged);
            publishers = new List<Publisher>();
        }

        public string CategoryName
        {
            get
            {
                return this.categoryExpander.Header as string;
            }
        }

        public Category Category
        {
            get
            {
                return this.category;
            }

            set
            {
                this.category = value;
                this.categoryExpander.Header = category.Name;
                if (category.Publishers != null) {
                    AddPublishers(category.Publishers);
                }
            }
        }

        public void AddPublisher(Publisher publisher)
        {
            this.publishers.Add(publisher);
            this.publishersList.Items.Add(publisher);
        }

        public void AddPublishers(IList<Publisher> publishers)
        {
            foreach (var publisher in publishers) {
                AddPublisher(publisher);
            }
        }

        public event SelectedPublisherChangedEventHandler SelectedPublisherChanged;

        private void publishersList_SelectionChanged(object publisher, SelectionChangedEventArgs e)
        {
            if (SelectedPublisherChanged != null)
                SelectedPublisherChanged(this, e.AddedItems[0] as Publisher);
        }

        private IList<Publisher> publishers;
        private Category category;
    }
    public delegate void SelectedPublisherChangedEventHandler(CategoryItem obj, Publisher sndr);
}
