﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser: IdentityUser<int>
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? District { get; set; }

        public string? city { get; set; }

        public string? ImageUrl { get; set; }

        public int? ConfirmCode { get; set; }

        public List<CustomerAccount> CustomerAccounts { get; set; }
    }
}
