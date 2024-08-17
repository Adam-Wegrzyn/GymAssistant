using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Common.DTO
{
    public class LogDTO: BaseDto
    {
        bool IsCompleted { get; set; }
        TimeOnly Duration { get; set; }
    }
}
