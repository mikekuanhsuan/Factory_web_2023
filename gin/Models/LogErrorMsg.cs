using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class LogErrorMsg
    {
        public DateTime Ddtime { get; set; }
        public string? MsgLog { get; set; }
        public string? ErrorMessage { get; set; }
        public bool? IsCheck { get; set; }
    }
}
