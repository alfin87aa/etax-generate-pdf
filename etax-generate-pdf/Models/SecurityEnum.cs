using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class SecurityEnum
{
    public int Id { get; set; }

    public string? Enumname { get; set; }

    public string? Enumdesc { get; set; }

    public string? Enumvalue { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public short? Rowstatus { get; set; }
}
