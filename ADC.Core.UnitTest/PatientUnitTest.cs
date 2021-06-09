using ADC.Domain.Service.Patient.Implementation;
using ADC.Domain.Service.Patient.Interface;
using ADC.Infrastructure.Repository.Implementation;
using ADC.Infrastructure.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ADC.Core.UnitTest
{
    [TestClass]
    public class PatientUnitTest
    {
        private readonly IPatientDataService _patientDataService;
        private readonly IPatientRepository _patientRepository;

        public PatientUnitTest()
        {
            var services = new ServiceCollection();
            
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IPatientDataService, PatientDataService>();
            services.AddMemoryCache();

            var serviceProvider = services.BuildServiceProvider();
            _patientDataService = serviceProvider.GetService<IPatientDataService>();
            _patientRepository = serviceProvider.GetService<IPatientRepository>();
        }

        [TestMethod]
        public void CreatePatientCache()
        {
            var status = _patientRepository.WriteToCache("_TestKey", "Test Value");
            Assert.AreEqual(status, "SUCCESS");
        }

        [TestMethod]
        public void GetPatient()
        {
            //Write test case to get patient record
        }

        [TestMethod]
        public void AddPatient()
        {
            //Write test case to add new patient record
        }

        [TestMethod]
        public void UpdatePatient()
        {
            //Write test case to update patient record
        }

        [TestMethod]
        public void DeletePatient()
        {
            //Write test case to delete patient record
        }
    }
}
