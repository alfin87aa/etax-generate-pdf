using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class LogSap
{
    public Guid LogImportSapId { get; set; }

    public string? FullPath { get; set; }

    public string? FileName { get; set; }

    public string? CompanyCode { get; set; }

    /// <summary>
    /// success
    /// failed
    /// success with retry
    /// </summary>
    public int? StatusId { get; set; }

    public string? Note { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }
}
