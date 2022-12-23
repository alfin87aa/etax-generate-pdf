using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class ScanRecap
{
    public Guid Id { get; set; }

    public string? TaxNumber { get; set; }

    public string? ScanType { get; set; }

    public string? Status { get; set; }

    public string? ErrorMessage { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }
}
