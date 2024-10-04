using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utility
{
    public static class RuntimeContext
    {
        public static CConfig Config { get; set; } = new CConfig();


        public static class Current
        {

        }
    }
}
