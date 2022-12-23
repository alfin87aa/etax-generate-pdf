using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class SettingTax
{
    public int? TaxId { get; set; }

    public string? TaxName { get; set; }

    public int? TaxPercen { get; set; }

    public DateTime? TaxStart { get; set; }

    public DateTime? TaxEnd { get; set; }
}
