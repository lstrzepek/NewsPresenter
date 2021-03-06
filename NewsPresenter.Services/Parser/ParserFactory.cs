﻿using System;

namespace EtherSoftware.NewsPresenter.Service.Parser
{
    sealed class ParserFactory
    {
        public IParser CreateParser(PublisherType type)
        {
            switch (type) {
                case PublisherType.Atom:
                    return new AtomParser.AtomParser();
                case PublisherType.Rss:
                    return new RssParser.RssParser();
                default:
                    throw new ArgumentException("Unhandling parser type: " + type);
            }
        }
        #region Singleton
        private ParserFactory() { }

        private static readonly ParserFactory instance = new ParserFactory();

        public static ParserFactory Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion
    }
}
