using System;

namespace EtherSoftware.NewsPresenter.Common
{
    public class Message : IServiceObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime PublishDate { get; set; }
        public string Author { get; set; }
        public string Address { get; set; }
        public bool Viewed { get; set; }
        public Publisher Publisher { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
