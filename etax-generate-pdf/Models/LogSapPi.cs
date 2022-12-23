using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class LogSapPi
{
    public long LogId { get; set; }

    public string? TaxNumber { get; set; }

    /// <summary>
    /// 0: scan 1
    /// 1: upload csv
    /// 2: scan 3
    /// 3:input manual
    /// 4:upload txt  (IPPI)
    /// </summary>
    public byte? Type { get; set; }

    /// <summary>
    /// look master status
    /// </summary>
    public int? Status { get; set; }

    public long? Batch { get; set; }

    public string? Message { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }
}
