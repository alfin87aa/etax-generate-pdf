using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class VatInLeadtime
{
    public long LeadTimeId { get; set; }

    public string? TaxNumber { get; set; }

    public DateTime? Scan1Date { get; set; }

    public DateTime? Scan2Date { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }
}
