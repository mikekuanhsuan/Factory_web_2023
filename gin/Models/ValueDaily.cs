using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class ValueDaily
    {
        public DateTime DataDateTime { get; set; }
        /// <summary>
        /// FactoryID
        /// </summary>
        public string ServerName { get; set; } = null!;
        public string TagName { get; set; } = null!;
        public decimal? Value { get; set; }
    }
}
