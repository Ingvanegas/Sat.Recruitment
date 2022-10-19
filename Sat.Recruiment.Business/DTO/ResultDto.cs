using Sat.Recruiment.IBusiness.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruiment.Business.DTO
{
    public class ResultDto: IResultDto
    {
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
        public string Result { get; set; }
    }
}
