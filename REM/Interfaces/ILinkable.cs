using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REM.Models.Interfaces
{
    interface ILinkable
    {
        int Id { get; set; }
        int PrimaryId { get; set; }
        int SecondaryId { get; set; }
    }
}
