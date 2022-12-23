using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class ServiceLog
{
    public int Id { get; set; }

    public string? ServiceName { get; set; }

    public string? Message { get; set; }

    public string? ErrorMessage { get; set; }

    public int? Status { get; set; }
}
