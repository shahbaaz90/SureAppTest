using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using MediCareWebService;

namespace SureAppTest.Common.Services
{
    public class MediCareService : IMediCareService
    {
        MediCareSupplierSoapClient mediCareWebServiceClient;
        readonly EndpointAddress endpoint;
        readonly BasicHttpBinding binding;

        public MediCareService()
        {
            binding = CreateBasicHttpBinding();
            endpoint = new EndpointAddress(SharedConfig.MediCareSupplierEndpoint);

            mediCareWebServiceClient = new MediCareSupplierSoapClient(binding, endpoint);
        }

        public async Task<IEnumerable<SupplierData>> GetSupplierByCity(string cityName)
        {
           var res = await mediCareWebServiceClient.GetSupplierByCityAsync(
               new GetSupplierByCityRequest(cityName));

            return res?.SupplierDataLists?.SupplierDatas;
        }

        private BasicHttpBinding CreateBasicHttpBinding()
        {
            BasicHttpBinding binding = new BasicHttpBinding
            {
                Name = "basicHttpBinding",
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647
            };

            TimeSpan timeout = new TimeSpan(0, 0, 30);
            binding.SendTimeout = timeout;
            binding.OpenTimeout = timeout;
            binding.ReceiveTimeout = timeout;
            return binding;
        }
    }
}
