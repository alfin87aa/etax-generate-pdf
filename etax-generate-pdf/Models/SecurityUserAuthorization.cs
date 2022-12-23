using System;
using System.Collections.Generic;

namespace etax_generate_pdf.Models;

public partial class SecurityUserAuthorization
{
    public int UserAuthorizationsId { get; set; }

    public string DomainUsername { get; set; } = null!;

    public string OperationsCode { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public short RowStatus { get; set; }
}
