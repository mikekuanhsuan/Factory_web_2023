using System;
using System.Collections.Generic;

namespace gin.Models
{
    public partial class DespatchName
    {
        public string ProdId { get; set; } = null!;
        public string? ProdName { get; set; }
        public string? Cpackage { get; set; }
    }
}
