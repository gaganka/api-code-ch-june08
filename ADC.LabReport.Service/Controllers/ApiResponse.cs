using System.Net;

namespace ADC.LabReport.Service.Controllers
{
    public class ApiResponse
    {
        public HttpStatusCode ResponseCode { get; set; }
        public bool Success { get; set; }
        public string ErrorDetails { get; set; }
        public object Data { get; set; }
    }
}