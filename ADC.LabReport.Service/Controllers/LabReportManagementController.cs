using ADC.Domain.Service.LabReport.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ADC.LabReport.Service.Controllers
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
        public async Task<ApiResponse> GetLabReport(int id)
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
        ADC.Core.Modules.LabReport.Entity.LabReport model)
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

        // PUT api/<LebReportManagementController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LebReportManagementController>/5
        [HttpDelete("{id}")]
        public async Task<ApiResponse> Delete(int id)
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
