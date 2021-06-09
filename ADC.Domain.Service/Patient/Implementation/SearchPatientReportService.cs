using ADC.Core.Modules.Patient.Entity;
using ADC.Domain.Service.Patient.Interface;
using ADC.Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADC.Domain.Service.Patient.Implementation
{
    public class SearchPatientReportService : ISearchPatientReportService
    {
        private readonly IPatientRepository _patientRepository;

        public SearchPatientReportService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<List<SearchResponseModel>> SearchPatientReport(SearchRequestModel model)
        {
            return await _patientRepository.SearchLabReport(model);
        }
    }
}
