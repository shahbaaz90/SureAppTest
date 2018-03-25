using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediCareWebService;

namespace SureAppTest.Common.Services
{
    public interface IMediCareService
    {
        Task<IEnumerable<SupplierData>> GetSupplierByCity(string cityName);
    }
}
