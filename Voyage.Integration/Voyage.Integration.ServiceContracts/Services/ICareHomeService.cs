using System.ServiceModel;
using Voyage.Integration.ServiceContracts.Dtos;

namespace Voyage.Integration.ServiceContracts.Services
{
    [ServiceContract(Namespace="http://tempuri.org")]
    public interface ICareHomeService
    {
        [OperationContract]
        CareHomeDto GetCareHome(int careHomeId);

        [OperationContract]
        int CreateCareHome(CareHomeDto careHome);

        [OperationContract]
        int UpdateCareHome(CareHomeDto careHome);

        [OperationContract]
        bool DeleteCareHome(int careHomeId);
    }
}
