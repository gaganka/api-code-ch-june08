using ADC.Core.Modules.LabReport.Entity;
using ADC.Core.Modules.Patient.Entity;
using ADC.Infrastructure.CacheStorage;
//using ADC.Infrastructure.CacheStorage.Interface;
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
    /// Repository class
    /// </summary>
    public class PatientRepository : IPatientRepository
    {
        private readonly IMemoryCache _memoryCache;

        #region Constructor
        public PatientRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        #endregion

        #region CRUD Methods        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public async Task<string> Add(PatientInformation patient)
        {
            string status = "SUCCESS";

            try
            {
                List<PatientInformation> patientList = 
                    _memoryCache.Get<List<PatientInformation>>(
                        ApllicationCacheFacade.PATIENTINFO);

                //setup cache key and item 
                if(patientList == null)
                {
                    patientList = new List<PatientInformation>();
                }
                else
                {
                    var searhList = patientList.Where(p => p.ID == patient.ID ||
                    p.PatientCode == patient.PatientCode);

                    if(searhList != null && searhList.Count() > 0)
                    {
                        throw new Exception("Patient ID or Code already exist");
                    }
                }

                patientList.Add(patient);

                _memoryCache.Set<List<PatientInformation>>(ApllicationCacheFacade.PATIENTINFO,
                    patientList,
                    DateTimeOffset.Now.AddDays(2));
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while trying to add patient data", ex);
            }

            return status;
        }

        public async Task<PatientInformation> Get(int patientId)
        {
            try
            {
                var patientList = _memoryCache.Get<List<PatientInformation>>(ApllicationCacheFacade.PATIENTINFO);

                if (patientList != null && patientList.Count > 0)
                {
                    var patientRow = patientList.FirstOrDefault(p => p.ID == patientId);

                    if (patientRow != null)
                    {
                        return patientRow;
                    }
                    else
                    {
                        throw new Exception("Patient record not found");
                    }
                }
                else
                {
                    throw new Exception("Patient repository does not exist");
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error occured while trying to read patient data", ex);
            }

        }

        public async Task<string> Update(PatientInformation patient)
        {
            try
            {
                var patientList = _memoryCache.Get<List<PatientInformation>>(ApllicationCacheFacade.PATIENTINFO);

                if (patientList != null && patientList.Count > 0)
                {
                    var patientRow = patientList.FirstOrDefault(p => p.ID == patient.ID);

                    if (patientRow != null)
                    {
                        patientRow.AddressLine1 = patient.AddressLine1;
                        patientRow.AddressLine2 = patient.AddressLine2;
                        patientRow.City = patient.City;
                        patientRow.State = patient.State;
                        patientRow.Phone = patient.Phone;

                        //exception case
                        patientRow.Gender = patient.Gender;
                        patientRow.DOB = patient.DOB;
                        patientRow.FirstName = patient.FirstName;
                        patientRow.LastName = patient.LastName;

                        _memoryCache.Set<List<PatientInformation>>(ApllicationCacheFacade.PATIENTINFO,
                            patientList,
                            DateTimeOffset.Now.AddDays(2));
                    }
                    else
                    {
                        throw new Exception("Patient record not found");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return "SUCCESS";
        }

        public async Task<string> Delete(int patientId)
        {
            try
            {
                var patientList = _memoryCache.Get<List<PatientInformation>>(
                    ApllicationCacheFacade.PATIENTINFO);

                if (patientList != null && patientList.Count > 0)
                {
                    var pitem = patientList.FirstOrDefault(p => p.ID == patientId);

                    if (pitem != null)
                    {
                        patientList.Remove(pitem);
                        _memoryCache.Set<List<PatientInformation>>(
                            ApllicationCacheFacade.PATIENTINFO, 
                            patientList);
                    }
                    else
                    {
                        throw new Exception("Patient record not found");
                    }
                }
                else
                {
                    throw new Exception("Patient repository does not exist");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return "SUCCESS - Patient record deleted";
        }

        #endregion

        #region Search Patient Report

        public async Task<List<SearchResponseModel>> SearchLabReport(SearchRequestModel model)
        {
            List<SearchResponseModel> searchResults = new List<SearchResponseModel>();

            try
            {
                var patientList = _memoryCache.Get<List<PatientInformation>>(
                    ApllicationCacheFacade.PATIENTINFO);
                if (model.PatientID > 0)
                {
                    patientList = patientList.Where(p => p.ID == model.PatientID).ToList();
                }

                var labReportList = _memoryCache.Get<List<LabReport>>(
                    ApllicationCacheFacade.LABREPORT);
                if (labReportList != null && labReportList.Count > 0)
                {
                    labReportList = labReportList.Where(
                        l => (l.PatientID == model.PatientID) &&
                        (l.TestTime >= model.FromDate && l.TestTime <= model.ToDate) &&
                        l.TestType.ToString() == model.TestType.ToString()).ToList();
                }

                if(patientList != null && patientList.Count > 0 
                    && labReportList != null && labReportList.Count > 0)
                {
                    searchResults = (from result in patientList
                                     join report in labReportList on
                                     new { pid = result.ID } equals new { pid = report.PatientID }
                                     select new SearchResponseModel
                                     {
                                         EnteredTime = report.EnteredTime,
                                         PhysicianName = report.PhysicianName,
                                         ReportDate = report.ReportDate,
                                         Result = report.Result,
                                         TestTime = report.TestTime,
                                         TestType = report.TestType,
                                         VerifiedBy = report.VerifiedBy,
                                         PatientInfo = new PatientDetails
                                         {
                                             Address = result.AddressLine1,
                                             DOB = result.DOB,
                                             PatientName = result.FirstName + " " + result.MiddleName ?? string.Empty +
                                             " " + result.LastName,
                                             Phone = result.Phone
                                         }
                                     }).ToList();
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured. " + ex.Message);
            }

            return searchResults;
        }
        #endregion

        #region Test Method
        /// <summary>
        /// test method
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string WriteToCache(string key, string value)
        {
            string status = "SUCCESS";
            try
            {
                _memoryCache.Set<string>(key, value, DateTimeOffset.Now.AddMinutes(1));
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                status = "Error: " + ex.Message;
            }

            return status;
        }
        #endregion
    }
}
