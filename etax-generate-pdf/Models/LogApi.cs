using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class LogApi
{
    public long LogApiId { get; set; }

    public string? TaxNumber { get; set; }

    public string? CompanyCode { get; set; }

    public string? ParameterJson { get; set; }

    public string? Status { get; set; }

    public string? Message { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public byte? RowStatus { get; set; }
}
