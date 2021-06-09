using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ADC.Core.Modules.LabReport.Entity
{
    public class LabReport
    {
        [JsonProperty("id")]
        [Range(1,Int32.MaxValue)]
        public int ID { get; set; }
        
        [JsonProperty("patientId")]
        [Range(1, Int32.MaxValue)]
        public int PatientID { get; set; }
        
        [Required(ErrorMessage ="Report date is required")]
        public string ReportDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public LabTestType.TestType TestType { get; set; }
        public DateTime TestTime { get; set; }
        public DateTime EnteredTime { get; set; }

        [Required(ErrorMessage = "Physician name is required")]
        public string PhysicianName { get; set; }

        [Required(ErrorMessage = "Verified by is required")]
        public string VerifiedBy { get; set; }

        [Required(ErrorMessage = "Result text is required")]
        public string Result { get; set; }

        [Required(ErrorMessage = "IsMailed is required")]
        public bool IsMailed { get; set; }

    }
}
