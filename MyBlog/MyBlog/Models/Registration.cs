﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    public class Registration
    {
        [Required]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Confirm Password"), System.Web.Mvc.Compare("Password")]
        public string PasswordConfirm { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, Display(Name = "Avatar")]
        public string ImageUrl { get; set; }


    }
}