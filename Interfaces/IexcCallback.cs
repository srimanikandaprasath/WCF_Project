using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Interfaces
{
    public interface IexcCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnNewMessage(string user, string msg);
    }
}
