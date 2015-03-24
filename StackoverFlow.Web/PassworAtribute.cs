using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace StackoverFlow.Web
{
    public class PassworAtribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var stringvalue = value.ToString();
            var stringvalue2 = stringvalue.ToLower();
            if (stringvalue.Equals(stringvalue2))
                return false;
            return true;
        }
        
    }
}