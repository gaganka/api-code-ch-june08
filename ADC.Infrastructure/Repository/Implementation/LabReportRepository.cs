using ADC.Core.Modules.LabReport.Entity;
using ADC.Infrastructure.CacheStorage;
using ADC.Infrastructure.Repository.Interface;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADC.Infrastructure.Repository.Implementation
{
    /// <summary>
    /// Repository class for read write operations
    /// into inmemory cache
    /// </summary>
    public class LabReportRepository : ILabReportRepository
    {
        private readonly IMemoryCache _memoryCache;
        public LabReportRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<string> Add(LabReport model)
        {
            string status = "SUCCESS";

            try
            {
                List<LabReport> labReportList =
                    _memoryCache.Get<List<LabReport>>(ApllicationCacheFacade.LABREPORT);

                //setup cache key and item 
                if (labReportList == null)
                {
                    labReportList = new List<LabReport>();
                }

                labReportList.Add(model);

                _memoryCache.Set<List<LabReport>>(ApllicationCacheFacade.LABREPORT, labReportList,
                    DateTimeOffset.Now.AddDays(2));
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while trying to add lab report data", ex);
            }

            return status;
        }

        public async Task<string> Delete(int reportId)
        {
            try
            {
                var labReportList = _memoryCache.Get<List<LabReport>>(
                    ApllicationCacheFacade.LABREPORT);

                if (labReportList != null && labReportList.Count > 0)
                {
                    var labReportRow = labReportList.FirstOrDefault(p => p.ID == reportId);

                    if (labReportRow != null)
                    {
                        labReportList.Remove(labReportRow);
                        _memoryCache.Set<List<LabReport>>(ApllicationCacheFacade.LABREPORT,
                            labReportList);
                    }
                    else
                    {
                        throw new Exception("Lab Report record not found");
                    }
                }
                else
                {
                    throw new Exception("Lab Report repository does not exist");
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return "SUCCESS - Lab Report record deleted";
        }

        public async Task<LabReport> Get(int reportId)
        {
            try
            {
                var labReportList = _memoryCache.Get<List<LabReport>>(
                    ApllicationCacheFacade.LABREPORT);

                if (labReportList != null && labReportList.Count > 0)
                {
                    var labReportRow = labReportList.FirstOrDefault(p => p.ID == reportId);

                    if (labReportRow != null)
                    {
                        return labReportRow;
                    }
                    else
                    {
                        throw new Exception("Lab Report record not found");
                    }
                }
                else
                {
                    throw new Exception("Lab Report repository does not exist");
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error occured while trying to read lab report data", ex);
            }
        }

        public async Task<string> Update(LabReport model)
        {
            string status = "SUCCESS";
            try
            {
                List<LabReport> labReportList =
                    _memoryCache.Get<List<LabReport>>(ApllicationCacheFacade.LABREPORT);

                //setup cache key and item 
                if (labReportList != null && labReportList.Count > 0)
                {
                    var labReport = labReportList.FirstOrDefault(l => l.ID == model.ID);
                    if(labReport != null)
                    {
                        if (labReport.IsMailed)
                        {
                            throw new Exception("record not availble for editing");
                        }
                        else
                        {
                            labReport.IsMailed = model.IsMailed;
                            labReport.PhysicianName = model.PhysicianName;                            
                            labReport.VerifiedBy = model.VerifiedBy;
                            labReport.TestType = model.TestType;

                            labReport.Result = model.Result;
                            labReport.ReportDate = model.ReportDate;
                            labReport.TestTime = model.TestTime;
                            labReport.EnteredTime = model.EnteredTime;
                        }
                    }
                    else
                    {
                        throw new Exception("Lab Report record not found");
                    }
                }
                else
                {
                    throw new Exception("Lab Report repository does not exist");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error occured while trying to modify lab report data", ex); ;
            }

            return status;
        }
    }
}
