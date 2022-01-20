using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Interfaces
{
    [ServiceContract(
        SessionMode = SessionMode.Required,
        CallbackContract = typeof(IexcCallback))]
    public interface IexcService
    {
        [OperationContract]
        void SendMessage(string user, string msg);

        [OperationContract]
        bool Subcribe();

        [OperationContract]
        bool UnSubcribe();

    }
}
