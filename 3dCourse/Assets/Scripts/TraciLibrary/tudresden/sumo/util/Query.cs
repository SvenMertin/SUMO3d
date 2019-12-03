using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using TraciConnector.Protocol;
using TraciConnector.Tudresden.Sumo.Conf;

namespace TraciConnector.Tudresden.Sumo.Util
{
    public abstract class Query
    {
        private NetworkStream outStream;
        private NetworkStream inStream;

        public Query(Socket sock)
        {
            outStream = new NetworkStream(sock);
            inStream = new NetworkStream(sock);            
        }

        protected virtual ResponseMessage DoQuery(RequestMessage msg)
        {
            msg.WriteTo(GetOutStream());
            return new ResponseMessage(inStream);
        }

        protected virtual ResponseMessage QueryAndVerify(RequestMessage reqMsg)
        {
            reqMsg.WriteTo(GetOutStream());
            ResponseMessage respMsg = new ResponseMessage(inStream);
            List<Command> commands = reqMsg.Commands();
            List<ResponseContainer> responses = respMsg.Responses();
            if (commands.Count() > responses.Count())
                throw new TraCIException("not enough responses received");
            for (int i = 0; i < commands.Count(); i++)
            {
                Command cmd = commands[i];
                ResponseContainer responsePair = responses[i];
                StatusResponse statusResp = responsePair.GetStatus();
                Verify("command and status IDs match", cmd.Id(), statusResp.Id());
                if (statusResp.Result() != Constants.RTYPE_OK)
                    throw new TraCIException("SUMO error for command " + statusResp.Id() + ": " + statusResp.Description());
            }

            return respMsg;
            
             
        }

        protected virtual ResponseContainer DoQuerySingle(Command request)
        {
            RequestMessage msg = new RequestMessage();
            msg.Append(request);
            ResponseMessage resp = DoQuery(msg);
            resp.Responses().GetEnumerator().MoveNext();
            return resp.Responses().GetEnumerator().Current;
            //return resp.Responses().Iterator().Next();
        }

        protected virtual ResponseContainer QueryAndVerifySingle(Command request)
        {
            RequestMessage msg = new RequestMessage();
            msg.Append(request);
            ResponseMessage resp = QueryAndVerify(msg);
            //return resp.Responses().Iterator().Next();
            List<ResponseContainer>.Enumerator rcEnum = resp.Responses().GetEnumerator();
            rcEnum.MoveNext();
            return rcEnum.Current;
        }

        protected static string VerifyGetVarResponse(Command resp, int commandID, int variable, string objectID)
        {
            Verify("response code", commandID, resp.Id());
            Verify("variable ID", variable, (int)resp.Content().ReadUnsignedByte());
            string respObjectID = resp.Content().ReadStringASCII();
            if (objectID != null)
            {
                Verify("object ID", objectID, respObjectID);
            }

            return respObjectID;
        }

        protected static void Verify(string description, Object expected, Object actual)
        {
            if (!actual.Equals(expected))
                throw new TraCIException.UnexpectedData(description, expected, actual);
        }

        protected static void Verify(string description, int expected, short actual)
        {
            Verify(description, expected, (int)actual);
        }

        protected static void Verify(string description, int expected, byte actual)
        {
            Verify(description, expected, (int)actual);
        }

        public virtual NetworkStream GetOutStream()
        {
            return this.outStream;
        }
    }
}