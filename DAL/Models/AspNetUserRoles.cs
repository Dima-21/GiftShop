﻿using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class AspNetUserRoles
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public AspNetRoles Role { get; set; }
        public AspNetUsers User { get; set; }
    }
}
