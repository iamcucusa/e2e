using System;

namespace iDareUI.Models
{
    public class Case
    {
        public string CaseID {get;set;}
        public string System {get;set;}
        public string SerialNo {get;set;}
        public string SWVersion {get;set;}
        public string Created {get;set;}
        public string Customer {get;set;}
        public string Country { get; set;}
        public string CreatedBy { get; set;}
        public string Issues { get; set;}

        public static Case GetRandomCase()
        {
            return new Case()
            { 
                CaseID = Guid.NewGuid().ToString(),
                SerialNo = Guid.NewGuid().ToString(),
                Customer = Guid.NewGuid().ToString(),
                Country = Guid.NewGuid().ToString(),
            };
        }
    }
}
