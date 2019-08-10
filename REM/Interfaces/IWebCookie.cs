using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;

namespace REM.Interfaces
{
    interface IWebCookie
    {
        void Dump(object init);
        void Timeout();
        void CarrySession();
        void AddSession(object init);
        void EndSession();
    }
}
