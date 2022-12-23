using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class Config
{
    public string ConfigName { get; set; } = null!;

    public string? AttributeOne { get; set; }

    public string? AtributeTwo { get; set; }

    public string? ValueOne { get; set; }

    public string? ValueTwo { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
