﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbContextExample.Model
{
    public class Employees
    {
        public int Id { get; set; }

        public int Salary { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
   
}
