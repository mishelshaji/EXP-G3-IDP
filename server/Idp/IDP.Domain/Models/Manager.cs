﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idp.Domain.Models
{
    public class Manager
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int EmployeeId { get; set; }
    }
}
