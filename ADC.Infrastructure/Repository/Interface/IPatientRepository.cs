using ADC.Core.Modules.Patient.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADC.Infrastructure.Repository.Interface
{
    public interface IPatientRepository
    {
        Task<PatientInformation> Get( int patientId);
        
        Task<string> Add(PatientInformation patient);

        Task<string> Update(PatientInformation patient);
        
        Task<string> Delete(int patientId);

        Task<List<SearchResponseModel>> SearchLabReport(SearchRequestModel model);

        #region Test Method
        string WriteToCache(string key, string value);
        #endregion
    }
}
