﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Common
{
    public class CConfig
    {
        public CDBConnectionStrings DBConnectionStrings { get; set; }
    }

    public class CDBConnectionStrings
    {
        public string Default { get; set; }
    }

}
