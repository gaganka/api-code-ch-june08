using ADC.Core.Modules.Patient.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADC.Domain.Service.Patient.Interface
{
    public interface IPatientDataService
    {
        Task<List<PatientInformation>> Get();

        Task<PatientInformation> Get(int patientId);

        Task<string> Add(PatientInformation model);

        Task<string> Update(PatientInformation model);

        Task<string> Delete(int patientId);
    }
}
