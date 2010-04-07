using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherSoftware.NewsPresenter.Common
{
    public class Category : IServiceObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public IList<Publisher> Publishers { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
