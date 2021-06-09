using ADC.Core.Modules.LabReport.Entity;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ADC.Core.Modules.Patient.Entity
{
    public class SearchResponseModel
    {
        public string ReportDate { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public LabTestType.TestType TestType { get; set; }
        public DateTime TestTime { get; set; }
        public DateTime EnteredTime { get; set; }
        public string PhysicianName { get; set; }
        public string VerifiedBy { get; set; }
        public string Result { get; set; }

        public PatientDetails PatientInfo { get; set; }
    }

    public class PatientDetails
    {
        public string PatientName { get; set; }
        public string DOB { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
