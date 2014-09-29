using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BloodBank.Models
{
    [MetadataType(typeof(DonorValidation))]
    public partial class Donor
    {
    }

    public class DonorValidation
    {
        [Required]
        public string DonorName { get; set; }
        [Required]
        public string DonnorBloodGroup { get; set; }
        [Required]
        public string DonorMedicalReport { get; set; }
        [Required]
        public string DonorAddress { get; set; }
        [Required]
        public Nullable<int> DonorConatactNumber { get; set; }

    }
}