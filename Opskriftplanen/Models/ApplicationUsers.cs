﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opskriftplanen.Models
{
    public class ApplicationUsers : IdentityUser
    {
        public string Name { get; set; }
    }
}
