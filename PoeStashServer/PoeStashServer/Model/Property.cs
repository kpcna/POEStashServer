﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoeStashServer.Model
{
    public class Property
    {
        public string name { get; set; }
        public List<object> values { get; set; }
        public int displayMode { get; set; }
    }
}
