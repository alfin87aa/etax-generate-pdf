using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class LogScanPdf
{
    public int Id { get; set; }

    public string? FullPath { get; set; }

    public string? FileName { get; set; }

    public string? CompanyCode { get; set; }

    public string? Status { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedDate { get; set; }
}
