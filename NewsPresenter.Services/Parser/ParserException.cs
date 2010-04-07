using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtherSoftware.NewsPresenter.Service.Parser
{
    [global::System.Serializable]
    class ParserException : ApplicationException {
        public ParserException() { }
        public ParserException(string message) : base(message) { }
        public ParserException(string message, Exception inner) : base(message, inner) { }
        protected ParserException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
