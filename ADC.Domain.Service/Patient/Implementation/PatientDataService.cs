using ADC.Core.Modules.Patient.Entity;
using ADC.Domain.Service.Patient.Interface;
using ADC.Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADC.Domain.Service.Patient.Implementation
{
    public class PatientDataService : IPatientDataService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientDataService(IPatientRepository patientRepository) 
        {
            _patientRepository = patientRepository;
        }

        public async Task<string> Add(PatientInformation model)
        {
            return await _patientRepository.Add(model);
        }

        public Task<List<PatientInformation>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<PatientInformation> Get(int patientId)
        {
            return await _patientRepository.Get(patientId);
        }

        public async Task<string> Update(PatientInformation model)
        {
            return await _patientRepository.Update(model);
        }

        public async Task<string> Delete(int patientId)
        {
            return await _patientRepository.Delete(patientId);
        }
    }
}
