using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADC.Infrastructure.Repository.Interface
{
    public interface ILabReportRepository
    {
        Task<Core.Modules.LabReport.Entity.LabReport> Get(int reportId);

        Task<string> Add(Core.Modules.LabReport.Entity.LabReport model);

        Task<string> Update(Core.Modules.LabReport.Entity.LabReport model);

        Task<string> Delete(int reportId);
    }
}
