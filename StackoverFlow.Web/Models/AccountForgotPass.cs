﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StackoverFlow.Web.Models
{
    public class AccountForgotPass
    {
        [Required]
        public string Email { get; set; }
    }
}