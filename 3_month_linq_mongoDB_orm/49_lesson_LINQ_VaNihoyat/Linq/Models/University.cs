﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQLess.LinqMethods;

namespace Linq.Models
{
    public class University
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }

        public List<Student> Students { get; set; }
    }
}
