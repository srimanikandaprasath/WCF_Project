using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Interfaces;
using System.ServiceModel;

namespace ServerLib
{
    [ServiceBehavior(
        Name = "ServerSvc",
        InstanceContextMode = InstanceContextMode.Single)]
    class ServerSvc : IexcService
    {
        Dictionary<string, IexcCallback> _subcribers = null;

        ServerControl _serverCtrl = null;
        public ServerSvc(ServerControl serverCtrl)
        {
            _serverCtrl = serverCtrl;
            _subcribers = new Dictionary<string, IexcCallback>();
        }

        public void SendMessage(string user, string msg)
        {
            OperationContext ctx = OperationContext.Current;

            foreach(var subscriber in _subcribers)
            {
                try
                {
                    if (ctx.SessionId == subscriber.Key)
                        continue;
                    
                    if(null != subscriber.Value)
                    {
                        Thread thread = new Thread(delegate ()
                        {
                            subscriber.Value.OnNewMessage(user, msg);
                        });
                    }
                }
                catch(Exception ex)
                {
                    continue;
                }
            }
            _serverCtrl.LogMessage("Message from " + user + ":" + msg);
        }

        public bool Subcribe()
        {
            try
            {
                OperationContext ctx = OperationContext.Current;
                IexcCallback callback = ctx.GetCallbackChannel<IexcCallback>();

                if (!_subcribers.ContainsKey(ctx.SessionId))
                {
                    _subcribers.Add(ctx.SessionId, callback);
                    _serverCtrl.LogMessage("New user connected:" + ctx.SessionId);
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool UnSubcribe()
        {
            try
            {
                OperationContext ctx = OperationContext.Current;
                if (!_subcribers.ContainsKey(ctx.SessionId))
                    return false;

                _subcribers.Remove(ctx.SessionId);
                _serverCtrl.LogMessage("User disconnected. Id:" + ctx.SessionId);

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
           
        }
    }
}
