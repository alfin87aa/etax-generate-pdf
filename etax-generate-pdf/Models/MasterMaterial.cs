using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class MasterMaterial
{
    public long MaterialId { get; set; }

    public string? MaterialCode { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public string? CompanyCode { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }
}
