using ADC.Domain.Service.LabReport.Interface;
using ADC.Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ADC.Domain.Service.LabReport.Implementation
{
    public class LabReportDataService : ILabReportDataService
    {
        private readonly ILabReportRepository _labReportRepository;
        public LabReportDataService(ILabReportRepository labReportRepository)
        {
            _labReportRepository = labReportRepository;
        }
        public async Task<string> Add(Core.Modules.LabReport.Entity.LabReport model)
        {
            return await _labReportRepository.Add(model);
        }

        public async Task<string> Delete(int reportId)
        {
            return await _labReportRepository.Delete(reportId);
        }

        public Task<List<Core.Modules.LabReport.Entity.LabReport>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<Core.Modules.LabReport.Entity.LabReport> Get(int reportId)
        {
            return await _labReportRepository.Get(reportId);
        }

        public async Task<string> Update(Core.Modules.LabReport.Entity.LabReport model)
        {
            return await _labReportRepository.Update(model);
        }
    }
}
