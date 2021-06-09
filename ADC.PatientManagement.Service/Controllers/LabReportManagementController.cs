using ADC.Core.Modules.LabReport.Entity;
using ADC.Domain.Service.LabReport.Interface;
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
    public class LabReportManagementController : ControllerBase
    {
        private readonly ILabReportDataService _labReportDataService;
        private readonly ILogger<LabReportManagementController> _logger;
        public LabReportManagementController(ILabReportDataService labReportDataService,
            ILogger<LabReportManagementController> logger)
        {

            _labReportDataService = labReportDataService;
            _logger = logger;
        }

        // GET: api/<LebReportManagementController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("GetLabReport/{id}")]
        [HttpGet]
        public async Task<ApiResponse> GetLabReport([Required]int id,
            [FromHeader(Name = "ApiKey")][Required] string requiredHeader)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                response.Data = await _labReportDataService.Get(id);
                response.Success = true;
                response.ResponseCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                response.Success = false;
                response.ErrorDetails = ex.Message;
                response.ResponseCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }

        [Route("Add")]
        [HttpPost]
        public async Task<ApiResponse> Add([FromBody]
        ADC.Core.Modules.LabReport.Entity.LabReport model,
            [FromHeader(Name = "ApiKey")][Required] string requiredHeader)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                response.Data = await _labReportDataService.Add(model);
                response.Success = true;
                response.ResponseCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                response.Success = false;
                response.ErrorDetails = ex.Message;
                response.ResponseCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }

        [Route("Update")]
        [HttpPut]
        public async Task<ApiResponse> Put([FromBody] LabReport model,
            [FromHeader(Name = "ApiKey")][Required] string requiredHeader)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                response.Data = await _labReportDataService.Update(model);
                response.Success = true;
                response.ResponseCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                response.Success = false;
                response.ErrorDetails = ex.Message;
                response.ResponseCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }

        // DELETE api/<LebReportManagementController>/5
        [HttpDelete("{id}")]
        public async Task<ApiResponse> Delete([Required]int id,
            [FromHeader(Name = "ApiKey")][Required] string requiredHeader)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                response.Data = await _labReportDataService.Delete(id);
                response.Success = true;
                response.ResponseCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                response.Success = false;
                response.ErrorDetails = ex.Message;
                response.ResponseCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
    }
}
