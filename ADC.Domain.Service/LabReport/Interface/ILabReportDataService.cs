using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ADC.Core.Modules.LabReport.Entity ;

namespace ADC.Domain.Service.LabReport.Interface
{
    public interface ILabReportDataService
    {
        Task<List<ADC.Core.Modules.LabReport.Entity.LabReport>> Get();

        Task<ADC.Core.Modules.LabReport.Entity.LabReport> Get(int reportId);

        Task<string> Add(ADC.Core.Modules.LabReport.Entity.LabReport model);

        Task<string> Update(ADC.Core.Modules.LabReport.Entity.LabReport model);

        Task<string> Delete(int reportId);
    }
}
