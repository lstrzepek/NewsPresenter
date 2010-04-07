using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherSoftware.NewsPresenter.Common
{
    public class Publisher : IServiceObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Source { get; set; }
        public DateTime AddDate { get; set; }
        public int Rank { get; set; }
        public int Views { get; set; }
        public int Position { get; set; }
        public Category Category { get; set; }
        public IList<Message> Messages { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
