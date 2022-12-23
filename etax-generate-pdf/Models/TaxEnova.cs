using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class TaxEnova
{
    public long EnovaId { get; set; }

    public string TaxNumber { get; set; } = null!;

    public DateTime? SkDate { get; set; }

    public byte? IsUsed { get; set; }

    public string? CompanyCode { get; set; }

    public short? Batch { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }
}
