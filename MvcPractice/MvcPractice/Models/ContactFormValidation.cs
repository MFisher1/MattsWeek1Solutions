using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Step 1: Import System.ComponentModel.DataAnnotation
using System.ComponentModel.DataAnnotations;

namespace MvcPractice.Models
{
   
      //Step 2 create a partial class for the class we are trying to validate
        [MetadataType(typeof(ContactFormValidation))]
        public partial class ContactForm
        { 
        }

        public class ContactFormValidation
        { 
            //Step 4 Declare Properties of the class you want to validate and set data anotation
            [Required]
            public string Name { get; set; }
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            public string Message { get; set; }

        }

    
}