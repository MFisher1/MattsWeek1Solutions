using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BloodBank.Models
{
    public class BloodBankValidationController : Controller
    {
        //
        // GET: /BloodBankValidation/

        [MetadataType(typeof(BloodBankValidation))]
        public partial class BloodBank
        {
        }

        public class BloodBankValidation
        {
            [Required]
            public string BloodBankName { get; set; }
            [Required]
            public string BloodBankAddress { get; set; }
            [Required]
            public string BloodBankContactNumber { get; set; }
        }

    }
}
