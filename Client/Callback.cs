using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Client
{
    class Callback : IexcCallback
    {
        Client _client;

        public Callback ( Client client)
        {
            _client = client;
        }

        public void OnNewMessage(string user, string msg)
        {
            _client.LogPeerMessage(user + "says:" + Environment.NewLine + msg);
        }
    }
}
