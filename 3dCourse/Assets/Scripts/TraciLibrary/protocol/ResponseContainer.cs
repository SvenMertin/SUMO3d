using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TraciConnector.Protocol
{
    public class ResponseContainer
    {
        private readonly StatusResponse status;
        private readonly Command response;
        private readonly List<Command> subResponses;
        public ResponseContainer(StatusResponse status, Command response, List<Command> subResponses)
        {
            this.status = status;
            this.response = response;
            this.subResponses = subResponses;
        }

        public ResponseContainer(StatusResponse status, Command response): this (status, response, null)
        {
        }

        public virtual StatusResponse GetStatus()
        {
            return status;
        }

        public virtual Command GetResponse()
        {
            return response;
        }

        public virtual List<Command> GetSubResponses()
        {
            return subResponses;
        }
    }
}