using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Build.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace MvcWebUI.Models
{
    public class ShippingDetail
    {
        [Required]
        public string FirstName { get; set; }
        [Microsoft.Build.Framework.Required]
        public string LastName{ get; set; }
        [Microsoft.Build.Framework.Required]
        [DataType(DataType.EmailAddress)]
        public string Email{ get; set; }
        [Microsoft.Build.Framework.Required]
        public string City{ get; set; }
        [Microsoft.Build.Framework.Required]
        public string Adress{ get; set; }
        [Microsoft.Build.Framework.Required]
        public int Age { get; set; }


    }
}
