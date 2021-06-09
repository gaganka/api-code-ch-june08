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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ADC.PatientManagement.Service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly IPatientDataService _patientDataService;
        private readonly ILogger<PatientController> _logger;

        public PatientController(IPatientDataService patientDataService,
            ILogger<PatientController> logger)
        {
            _patientDataService = patientDataService;
            _logger = logger;
        }

        // GET: api/<PatientController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("GetPatient/{id}")]
        [HttpGet]
        public async Task<ApiResponse> Get(int id, 
            [FromHeader(Name = "ApiKey")][Required] string requiredHeader)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                response.Data = await _patientDataService.Get(id);
                response.Success = true;
                response.ResponseCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                response.Success = false;
                response.ErrorDetails = ex.Message + " " + 
                    ex.InnerException?.Message ?? string.Empty;
                response.ResponseCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }

        [Route("Add")]
        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] PatientInformation model,
            [FromHeader(Name = "ApiKey")][Required] string requiredHeader)
        {
            ApiResponse response = new ApiResponse();

            //Perform model validation
            if (!ModelState.IsValid)
            {
                response.Data = ModelState;
                response.Success = false;
                response.ErrorDetails = "Missing mandatory fileds";
                response.ResponseCode = System.Net.HttpStatusCode.BadRequest;
                return response;
            }

            try
            {
                response.Data = await _patientDataService.Add(model);
                response.Success = true;
                response.ResponseCode = System.Net.HttpStatusCode.OK;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex,null);
                response.Success = false;
                response.ErrorDetails = ex.Message + " " 
                    + ex.InnerException?.Message ?? string.Empty; 
                response.ResponseCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }

        // PUT api/<PatientController>/5
        [Route("Update")]
        [HttpPut]
        public async Task<ApiResponse> Update([FromBody] PatientInformation model,
            [FromHeader(Name = "ApiKey")][Required] string requiredHeader)
        {
            ApiResponse response = new ApiResponse();

            //Perform model validation
            if (!ModelState.IsValid)
            {
                response.Data = ModelState;
                response.Success = false;
                response.ErrorDetails = "Missing mandatory fileds";
                response.ResponseCode = System.Net.HttpStatusCode.BadRequest;
                return response;
            }

            try
            {
                response.Data = await _patientDataService.Update(model);
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

        // DELETE api/<PatientController>/5
        [HttpDelete("{id}")]
        public async Task<ApiResponse> Delete(int id,
            [FromHeader(Name = "ApiKey")][Required] string requiredHeader)
        {
            ApiResponse response = new ApiResponse();

            try
            {
                response.Data = await _patientDataService.Delete(id);
                response.Success = true;
                response.ResponseCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                response.Success = false;
                response.ErrorDetails = ex.Message + " " + 
                    ex.InnerException?.Message ?? string.Empty;
                response.ResponseCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
    }
}
