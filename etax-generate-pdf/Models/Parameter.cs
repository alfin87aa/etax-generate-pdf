using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class Parameter
{
    public int ParameterId { get; set; }

    public string? KeyParam { get; set; }

    public string? Description { get; set; }

    public string? Value1 { get; set; }

    public string? Value2 { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? RowStatus { get; set; }
}
