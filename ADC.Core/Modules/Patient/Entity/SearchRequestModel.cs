using ADC.Core.Modules.LabReport.Entity;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ADC.Core.Modules.Patient.Entity
{
    public class SearchRequestModel
    {
        /// <summary>
        /// patiend id 0 will fetch all patients
        /// </summary>
        public int PatientID { get; set; }

        /// <summary>
        /// can be one of the following
        /// BloodCount | LipidPanel | UrineAnalysis
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public LabTestType.TestType TestType { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }
    }
}
