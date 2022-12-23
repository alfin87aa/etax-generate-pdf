using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class TaxEnofaSummary
{
    public long SumarryEnofaId { get; set; }

    public DateTime? SkDate { get; set; }

    public int? Batch { get; set; }

    public string? FirstRange { get; set; }

    public string? LastRange { get; set; }

    public string? LastUsedTaxnumber { get; set; }

    public int? Total { get; set; }

    public int? Available { get; set; }

    public string? CompanyCode { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }
}
