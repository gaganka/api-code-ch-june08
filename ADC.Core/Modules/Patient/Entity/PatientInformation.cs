using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ADC.Core.Modules.Patient.Entity
{
    //The domain entity class
    public class PatientInformation
    {
        [JsonProperty("id")]
        [Range(1, Int32.MaxValue)]
        public int ID { get; set; }
        public string PatientCode { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [JsonProperty("dob")]
        [Required(ErrorMessage = "Date of birth is required.")]
        public string DOB { get; set; }

        [Required(ErrorMessage = "gender is required.")]
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
    }
}
