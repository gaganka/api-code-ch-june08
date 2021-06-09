using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace ADC.Core.Modules.LabReport.Entity
{
    public static class LabTestType
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TestType
        {
            [EnumMember(Value = "BloodCount")]
            //[EnumMember(Value = "blood_count")]
            BloodCount,
            [EnumMember(Value = "LipidPanel")]
            //[EnumMember(Value = "lipid_panel")]
            LipidPanel,
            [EnumMember(Value = "UrineAnalysis")]
            //[EnumMember(Value = "urine_analysis")]
            UrineAnalysis
        }
    }
}
