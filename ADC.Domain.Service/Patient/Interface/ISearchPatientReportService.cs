using ADC.Core.Modules.Patient.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ADC.Domain.Service.Patient.Interface
{
    public interface ISearchPatientReportService
    {
        Task<List<SearchResponseModel>> SearchPatientReport(SearchRequestModel model);
    }
}
