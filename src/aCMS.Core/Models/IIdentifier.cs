﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aCMS.Core.Models
{
    public interface IIdentifier
    {
        int Id { get; set; }
        string Url { get; set; }
    }
}
