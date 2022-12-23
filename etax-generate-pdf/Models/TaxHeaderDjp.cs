using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class TaxHeaderDjp
{
    public long TaxHeaderId { get; set; }

    public string TaxNumber { get; set; } = null!;

    public string? CompanyCode { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }
}
