using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class MasterTaxType
{
    public int TaxTypeId { get; set; }

    public string? Description { get; set; }

    public string? HeaderCode { get; set; }

    public string? MiddleCode { get; set; }

    public string? DetailCode { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }
}
