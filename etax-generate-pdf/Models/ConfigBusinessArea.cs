using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class ConfigBusinessArea
{
    public int BusinessAreaId { get; set; }

    public string? BusinessArea { get; set; }

    public string? CompanyCode { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }
}
