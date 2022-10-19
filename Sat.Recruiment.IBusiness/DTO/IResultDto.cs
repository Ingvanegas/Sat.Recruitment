using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruiment.IBusiness.DTO
{
    public  interface IResultDto
    {
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
        public string Result { get; set; }
    }
}
