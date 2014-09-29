using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BloodBank.Models
{
    
        [MetadataType(typeof(PatientValidation))]
        public partial class Patient
        {
        }

        public class PatientValidation
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string PatientBloodGroup { get; set; }
            [Required]
            public string PatientDisease { get; set; }
        }
    
}