using ADC.Core.Modules.Patient.Entity;
using ADC.Domain.Service.Patient.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ADC.PatientManagement.Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PatientReportController : ControllerBase
    {
        private readonly ISearchPatientReportService _searchPatientReportService;
        private readonly ILogger<PatientReportController> _logger;

        public PatientReportController(ISearchPatientReportService searchPatientReportService,
            ILogger<PatientReportController> logger)
        {
            _searchPatientReportService = searchPatientReportService;
            _logger = logger;
        }

        [Route("GetReport")]
        [HttpPost]
        public async Task<ApiResponse>GetReport([FromBody] SearchRequestModel model,
            [FromHeader(Name = "ApiKey")][Required] string requiredHeader)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                response.Data = await _searchPatientReportService.SearchPatientReport(model);
                response.Success = true;
                response.ResponseCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                response.Success = false;
                response.ErrorDetails = ex.Message + " " + ex.InnerException?.Message ?? string.Empty;
                response.ResponseCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
    }
}
